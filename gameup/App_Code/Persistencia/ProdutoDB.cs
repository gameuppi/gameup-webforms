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
    public static DataSet FindAll()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;
        objConexao = Mapped.Connection();

        string query = "select * from produtos";
        objCommand = Mapped.Command(query, objConexao);
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
}