using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de SetorBD
/// </summary>
public class SetorBD
{
    public static DataSet procurarUsuariosSetor(int set_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " 	SELECT ";
        query += " 	    * ";
        query += " 	FROM ";
        query += " 	    USUARIO ";
        query += " 	WHERE ";
        query += " 	    SET_ID = ?SET_ID; ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?SET_ID", set_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static DataSet procurarGerenteSetor(int set_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " 	SELECT ";
        query += " 	    USU_ID ";
        query += " 	FROM ";
        query += " 	    USUARIO ";
        query += " 	WHERE ";
        query += " 	    SET_ID = ?SET_ID ";
        query += " 	    AND TUS_ID = '2' "; // TRUE

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?SET_ID", set_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static DataSet procurarSetoresEmpresa(int emp_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " 	SELECT ";
        query += " 	    SET_ID, ";
        query += " 	    SET_NOME ";
        query += " 	FROM ";
        query += " 	    SETOR ";
        query += " 	WHERE ";
        query += " 	    EMP_ID = ?EMP_ID; ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?EMP_ID", emp_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static string procurarSetoresPorID(int set_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " 	SELECT ";
        query += " 	    SET_ID, ";
        query += " 	    SET_NOME ";
        query += " 	FROM ";
        query += " 	    SETOR ";
        query += " 	WHERE ";
        query += " 	    SET_ID = ?SET_ID; ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?SET_ID", set_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds.Tables[0].Rows[0]["SET_NOME"].ToString();
    }

}