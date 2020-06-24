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

        string query = "select * from produtos where emp_id = ?emp_id";
        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", emp_id));
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

        string query = "select pro.* from movfinanceira mov join produtos pro on pro.pro_id = mov.pro_id where mov.usu_id = ?usu_id limit 4";
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
            objComando.Parameters.Add(Mapped.Parameter("?empresaId", produto.EmpresaId.Emp_id));

            objComando.ExecuteNonQuery();

            objConexao.Dispose();
            objComando.Dispose();

            ok = true;
        } catch (Exception ex)
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
            query += "  produtos (pro_nome, pro_subtitulo, pro_descricao, pro_valormoeda, prod_logo, pro_status, emp_id, usu_id, tip_id) ";
            query += " VALUES( ";
            query += " 	?nome,  ";
            query += " 	?subtitulo,  ";
            query += " 	?descricao,  ";
            query += " 	?preco,  ";
            query += " 	?logoUrl,  ";
            query += " 	?status, ";
            query += " 	?empresaId,  ";
            query += " 	?usuarioId,  ";
            query += " 	categoria ";
            query += " ) ";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?nome", produto.Nome));
            objComando.Parameters.Add(Mapped.Parameter("?subtitulo", produto.Subtitulo));
            objComando.Parameters.Add(Mapped.Parameter("?descricao", produto.Descricao));
            objComando.Parameters.Add(Mapped.Parameter("?preco", produto.Preco));
            objComando.Parameters.Add(Mapped.Parameter("?logoUrl", produto.LogoUrl));
            objComando.Parameters.Add(Mapped.Parameter("?status", produto.Status));
            objComando.Parameters.Add(Mapped.Parameter("?empresaId", produto.EmpresaId.Emp_id));
            objComando.Parameters.Add(Mapped.Parameter("?usuarioId", produto.UsuarioId));
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
}