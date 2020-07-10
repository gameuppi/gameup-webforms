using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descrição resumida de ProdutoDB
/// </summary>
public class ProdutoDB
{
    public static DataSet FindAllEmpresa(int emp_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "select * from produtos p JOIN movestoque mes ON mes.pro_id = p.pro_id where p.emp_id = ?emp_id";
        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", emp_id));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static DataSet BuscarTodosOsProdutosPorEmpresa(int empresaId)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "";
        query += " SELECT ";
        query += " 	pro.pro_id id, ";
        query += " 	pro.pro_nome nome, ";
        query += " 	pro.pro_subtitulo subtitulo, ";
        query += " 	pro.pro_descricao descricao, ";
        query += " 	pro.pro_valormoeda preco, ";
        query += " 	( ";
        query += " 		SELECT  ";
        query += " 			mes_saldo ";
        query += " 		FROM ";
        query += " 			movestoque ";
        query += " 		WHERE ";
        query += " 			pro_id = pro.pro_id ";
        query += " 		ORDER BY ";
        query += " 			mes_id DESC ";
        query += " 		LIMIT 1 ";
        query += " 	) quantidade, ";
        query += " 	CASE WHEN pro.tip_id = 1 THEN 'FISICO' ELSE 'VIRTUAL' END categoria, ";
        query += " 	pro.pro_logo logo_url, ";
        query += " 	pro.pro_status status ";
        query += " FROM ";
        query += " 	produtos pro ";
        query += " WHERE ";
        query += " 	pro.emp_id = ?emp_id; ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", empresaId));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static DataSet BuscarTodosOsProdutosPorEmpresaEStatus(int empresaId, StatusProdutoEnum status)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "";
        query += " SELECT ";
        query += " 	pro.pro_id id, ";
        query += " 	pro.pro_nome nome, ";
        query += " 	pro.pro_subtitulo subtitulo, ";
        query += " 	pro.pro_descricao descricao, ";
        query += " 	pro.pro_valormoeda preco, ";
        query += " 	( ";
        query += " 		SELECT  ";
        query += " 			mes_saldo ";
        query += " 		FROM ";
        query += " 			movestoque ";
        query += " 		WHERE ";
        query += " 			pro_id = pro.pro_id ";
        query += " 		ORDER BY ";
        query += " 			mes_id DESC ";
        query += " 		LIMIT 1 ";
        query += " 	) quantidade, ";
        query += " 	CASE WHEN pro.tip_id = 1 THEN 'FISICO' ELSE 'VIRTUAL' END categoria, ";
        query += " 	pro.pro_logo logo_url, ";
        query += " 	pro.pro_status status ";
        query += " FROM ";
        query += " 	produtos pro ";
        query += " WHERE ";
        query += " 	pro.emp_id = ?emp_id ";
        query += " 	AND pro.pro_status = ?status; ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", empresaId));
        objCommand.Parameters.Add(Mapped.Parameter("?status", status));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static DataSet procurarPorId(int pro_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "select * from produtos where pro_id = ?pro_id";
        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_id", pro_id));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static DataSet procurarEstoquePorId(int pro_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "select * from movestoque where pro_id = ?pro_id";
        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_id", pro_id));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static DataSet procurarMeusProdutos(int usu_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "select pro.* from movfinanceira mov join produtos pro on pro.pro_id = mov.pro_id where mov.usu_id = ?usu_id";
        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static bool FazMovimentacaoFinanceira(Produto pro, Usuario usu)
    {
        bool ok = false;
        int qtd = 1;

        if (usu.Usu_qtdMoeda >= pro.Preco)
        {
            ok = UsuarioDB.UpdateMoedaUsuario(pro.Preco, usu);
            ok = UpdateMovEstoque(pro.Id, qtd);
            ok = InsertMovFinanceira(pro, usu, qtd);
        }
        else
        {
            ok = false;
        }


        return ok;
    }

    public static bool InsertMovimentacaoEstoque(Produto produto, int quantidade)
    {
        bool ok = false;

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;

            objConexao = Mapped.Connection();

            string query = "";
            query += " INSERT INTO  ";
            query += " 	movestoque (mes_dhcriacao, mes_qtdentrada, mes_qtdsaida, mes_saldo, mes_descricao, pro_id, emp_id) ";
            query += " VALUES( ";
            query += " 	?dataCriacao,  ";
            query += " 	?quantidadeEntrada,  ";
            query += " 	0,  ";
            query += " 	?saldo,  ";
            query += " 	'Criação do Produto',  ";
            query += " 	(select max(pro_id) from produtos), ";
            query += " 	?empresaId  ";
            query += " ) ";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?dataCriacao", DateTime.Now));
            objComando.Parameters.Add(Mapped.Parameter("?quantidadeEntrada", quantidade));
            objComando.Parameters.Add(Mapped.Parameter("?saldo", quantidade));
            objComando.Parameters.Add(Mapped.Parameter("?empresaId", produto.Empresa.Emp_id));

            objComando.ExecuteNonQuery();

            objConexao.Dispose();
            objComando.Dispose();

            ok = true;
        }
        catch (Exception ex)
        {
            ok = false;
        }

        return ok;
    }

    public static DataSet ProcurarQtdSaidaProduto(int pro_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "select mes_qtdsaida, mes_saldo from movestoque where pro_id = ?pro_id";
        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_id", pro_id));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static bool UpdateMovEstoque(int pro_id, int qtd)
    {
        bool ok = false;

        int qtdSaida = 0;
        int qtdSaldo = 0;
        DataSet dsQtd = ProcurarQtdSaidaProduto(pro_id);

        qtdSaida = Convert.ToInt32(dsQtd.Tables[0].Rows[0]["mes_qtdsaida"].ToString());
        qtdSaldo = Convert.ToInt32(dsQtd.Tables[0].Rows[0]["mes_saldo"].ToString());

        try
        {
            if (qtdSaida + qtd <= qtdSaldo)
            {
                DataSet ds = new DataSet();
                IDbConnection objConexao;
                IDbCommand objCommand;
                objConexao = Mapped.Connection();

                qtd += qtdSaida;

                string query = "update movestoque SET mes_qtdSaida = ?qtd WHERE pro_id = ?pro_id";

                objCommand = Mapped.Command(query, objConexao);

                objCommand.Parameters.Add(Mapped.Parameter("?qtd", qtd));
                objCommand.Parameters.Add(Mapped.Parameter("?pro_id", pro_id));

                objCommand.ExecuteNonQuery();

                objConexao.Close();
                objConexao.Dispose();
                objCommand.Dispose();

                ok = true;
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.StackTrace);
            ok = false;
        }

        return ok;
    }

    public static bool InsertMovFinanceira(Produto pro, Usuario usu, int qtd)
    {
        bool ok = false;

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;

            objConexao = Mapped.Connection();

            string query = "insert into movfinanceira (mfi_valorProd, mfi_qtdProd, mfi_dHCompra, pro_id, emp_id, usu_id)" +
                           " values(?mfi_valorProd, ?mfi_qtdProd, ?mfi_dHCompra, ?pro_id, ?emp_id, ?usu_id)";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?mfi_valorProd", pro.Preco));
            objComando.Parameters.Add(Mapped.Parameter("?mfi_qtdProd", qtd));
            objComando.Parameters.Add(Mapped.Parameter("?mfi_dHCompra", DateTime.Now));
            objComando.Parameters.Add(Mapped.Parameter("?pro_id", pro.Id));
            objComando.Parameters.Add(Mapped.Parameter("?emp_id", usu.Emp_id));
            objComando.Parameters.Add(Mapped.Parameter("?usu_id", usu.Usu_id));

            objComando.ExecuteNonQuery();

            objConexao.Dispose();
            objComando.Dispose();

            ok = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            ok = false;
        }

        return ok;
    }

    public static bool InsertProduto(Produto produto)
    {
        bool ok = false;

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;

            objConexao = Mapped.Connection();

            string query = "";

            query += " INSERT INTO  ";
            query += "  produtos (pro_nome, pro_subtitulo, pro_descricao, pro_valormoeda, pro_logo, pro_status, emp_id, usu_id, tip_id) ";
            query += " VALUES( ";
            query += " 	?nome,  ";
            query += " 	?subtitulo,  ";
            query += " 	?descricao,  ";
            query += " 	?preco,  ";
            query += " 	?logoUrl,  ";
            query += " 	?status, ";
            query += " 	?empresaId,  ";
            query += " 	?usuarioId,  ";
            query += " 	?categoria ";
            query += " ) ";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?nome", produto.Nome));
            objComando.Parameters.Add(Mapped.Parameter("?subtitulo", produto.Subtitulo));
            objComando.Parameters.Add(Mapped.Parameter("?descricao", produto.Descricao));
            objComando.Parameters.Add(Mapped.Parameter("?preco", produto.Preco));
            objComando.Parameters.Add(Mapped.Parameter("?logoUrl", produto.LogoUrl == null ? "Sem logo" : produto.LogoUrl));
            objComando.Parameters.Add(Mapped.Parameter("?status", produto.Status));
            objComando.Parameters.Add(Mapped.Parameter("?empresaId", produto.Empresa.Emp_id));
            objComando.Parameters.Add(Mapped.Parameter("?usuarioId", produto.Usuario.Usu_id));
            objComando.Parameters.Add(Mapped.Parameter("?categoria", produto.Categoria));

            objComando.ExecuteNonQuery();

            objConexao.Dispose();
            objComando.Dispose();

            ok = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            ok = false;
        }

        return ok;
    }

    public static int BuscarQtdItensAtivos(Usuario usuario)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "";
        query += " SELECT ";
        query += " 	COUNT(pro_id) qtd ";
        query += " FROM ";
        query += " 	produtos ";
        query += " WHERE ";
        query += " 	emp_id = ?emp_id ";
        query += " 	AND pro_status = ?status ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", usuario.Emp_id));
        objCommand.Parameters.Add(Mapped.Parameter("?status", StatusProdutoEnum.DISPONIVEL));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        int qtd = !ds.Tables[0].Rows[0]["qtd"].ToString().Equals("") ? Convert.ToInt32(ds.Tables[0].Rows[0]["qtd"]) : 0;

        return qtd;
    }

    public static int BuscarQtdItensDisponiveis(Usuario usuario)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "";
        query += " SELECT  ";
        query += " 	 SUM(mov.mes_saldo) qtd  ";
        query += " FROM  ";
        query += " 	movestoque mov  ";
        query += " 	JOIN produtos pro ON pro.pro_id = mov.pro_id ";
        query += " WHERE  ";
        query += " 	mov.emp_id = ?emp_id ";
        query += " 	AND mov.mes_id = ( ";
        query += " 		SELECT  ";
        query += " 			MAX(mes_id)  ";
        query += " 		FROM  ";
        query += " 			movestoque  ";
        query += " 		WHERE  ";
        query += " 			emp_id = mov.emp_id ";
        query += " 			AND pro_id = mov.pro_id ";
        query += " 	) ";
        query += " 	AND pro.pro_status = '1' ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", usuario.Emp_id));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        int qtd = !ds.Tables[0].Rows[0]["qtd"].ToString().Equals("") ? Convert.ToInt32(ds.Tables[0].Rows[0]["qtd"]) : 0;

        return qtd;
    }

    public static int BuscarQtdMoedasGastas(Usuario usuario)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "";
        query += " SELECT ";
        query += " 	 SUM(mov.mfi_valorprod * mfi_qtdprod) qtd ";
        query += " FROM ";
        query += " 	movfinanceira mov ";
        query += " WHERE ";
        query += " 	mov.emp_id = ?emp_id ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", usuario.Emp_id));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        int qtd = !ds.Tables[0].Rows[0]["qtd"].ToString().Equals("") ? Convert.ToInt32(ds.Tables[0].Rows[0]["qtd"]) : 0;

        return qtd;
    }

    public static int BuscarQtdItensVendidos(Usuario usuario)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "";
        query += " SELECT ";
        query += " 	 SUM(mov.mfi_qtdprod) qtd ";
        query += " FROM ";
        query += " 	movfinanceira mov ";
        query += " WHERE ";
        query += " 	mov.emp_id = ?emp_id ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", usuario.Emp_id));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        int qtd = !ds.Tables[0].Rows[0]["qtd"].ToString().Equals("") ? Convert.ToInt32(ds.Tables[0].Rows[0]["qtd"]) : 0;

        return qtd;
    }

    public static int BuscarQtdItemMaisVendido(Usuario usuario)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "";
        query += " SELECT ";
        query += " 	SUM(mes_qtdsaida) qtd ";
        query += " FROM ";
        query += " 	movestoque ";
        query += " WHERE ";
        query += " 	emp_id = ?emp_id ";
        query += " GROUP BY ";
        query += " 	pro_id ";
        query += " ORDER BY ";
        query += " 	SUM(mes_qtdsaida) DESC ";
        query += " LIMIT 1 ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", usuario.Emp_id));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        int qtd = !ds.Tables[0].Rows[0]["qtd"].ToString().Equals("") ? Convert.ToInt32(ds.Tables[0].Rows[0]["qtd"]) : 0;

        return qtd;
    }

    public static string BuscarNomeItemMaisVendido(Usuario usuario)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "";
        query += " SELECT ";
        query += " 	pro.pro_nome nome ";
        query += " FROM ";
        query += " 	movestoque mov ";
        query += " 	JOIN produtos pro ON pro.pro_id = mov.pro_id ";
        query += " WHERE ";
        query += " 	mov.emp_id = ?emp_id ";
        query += " GROUP BY ";
        query += " 	mov.pro_id ";
        query += " ORDER BY ";
        query += " 	SUM(mov.mes_qtdsaida) DESC ";
        query += " LIMIT 1 ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", usuario.Emp_id));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        string nome = ds.Tables[0].Rows[0]["nome"].ToString();

        return nome;
    }

    public static DataSet BuscarCompradoresPorIdDoProduto(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "";
        query += " SELECT  ";
        query += " 	usu.usu_nome usu_nome, ";
        query += " 	seto.set_nome set_nome,";
        query += " 	mov.mfi_dhCompra mfi_data";
        query += " FROM ";
        query += " 	movfinanceira mov ";
        query += " 	JOIN usuario usu ON usu.usu_id = mov.usu_id ";
        query += " 	JOIN setor seto ON seto.set_id = usu.set_id ";
        query += " WHERE ";
        query += " 	mov.pro_id = ?pro_id ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_id", id));
        dataAdapter = Mapped.Adapter(objCommand);
        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static void AlterarStatusProduto(int pro_id, StatusProdutoEnum status)
    {
        bool ok = false;
        try
        {
            DataSet ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objCommand;
            objConexao = Mapped.Connection();

            string query = "update produtos SET pro_status = ?status WHERE pro_id = ?pro_id";

            objCommand = Mapped.Command(query, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?status", status));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_id", pro_id));

            objCommand.ExecuteNonQuery();

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            ok = true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.StackTrace);
            ok = false;
        }
    }

}