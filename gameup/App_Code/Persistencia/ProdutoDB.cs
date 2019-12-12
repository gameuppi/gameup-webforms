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

    public static DataSet procurarPorId( int pro_id)
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

    public static bool FazMovimentacaoFinanceira(Produto pro, Usuario usu)
    {
        bool ok = false;
        int qtd = 1;

        ok = UpdateMovEstoque(pro.Pro_id, qtd);
        ok = InsertMovFinanceira(pro, usu, qtd);
        ok = UsuarioDB.UpdateMoedaUsuario(pro.Pro_valorMoeda, usu);

        return ok;
    }

    public static bool UpdateMovEstoque(int pro_id, int qtd)
    {
        bool ok = false;

        try
        {
            DataSet ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objCommand;
            objConexao = Mapped.Connection();

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
            objComando.Parameters.Add(Mapped.Parameter("?mfi_valorProd", pro.Pro_valorMoeda));
            objComando.Parameters.Add(Mapped.Parameter("?mfi_qtdProd", qtd));
            objComando.Parameters.Add(Mapped.Parameter("?mfi_dHCompra", DateTime.Now));
            objComando.Parameters.Add(Mapped.Parameter("?pro_id", pro.Pro_id));
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
}