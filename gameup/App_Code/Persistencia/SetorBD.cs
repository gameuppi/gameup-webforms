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
        query += " 	    SET_NOME, ";
        query += " 	    SET_STATUS ";
        query += " 	FROM ";
        query += " 	    SETOR ";
        query += " 	WHERE ";
        query += " 	    EMP_ID = ?EMP_ID";
        query += " 	AND ";
        query += " 	    SET_STATUS <> '2'; ";

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
        query += " 	    SET_NOME, ";
        query += " 	    SET_STATUS ";
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

    public static DataSet procurarSetoresID(int set_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " 	SELECT ";
        query += " 	    SET_ID, ";
        query += " 	    SET_NOME, ";
        query += " 	    SET_STATUS ";
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

        return ds;
    }

    public static bool InativaSetor(int set_id)
    {
        bool ok = false;
        try
        {
            DataSet ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objCommand;
            objConexao = Mapped.Connection();

            string query = "update setor SET set_status = IF(set_status = 1, 2, 1) WHERE set_id = ?set_id";

            objCommand = Mapped.Command(query, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?set_id", set_id));

            objCommand.ExecuteNonQuery();

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            ok = true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.StackTrace);
        }

        return ok;

    }

    public static bool InsertSetor(Setor setor)
    {
        bool ok = false;

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;

            objConexao = Mapped.Connection();

            string query = "";
            query += "INSERT  ";
            query += "	INTO SETOR( ";
            query += "		SET_NOME,";
            query += "		EMP_ID,";
            query += "		SET_STATUS";
            query += "	) ";
            query += "VALUES ( ";
            query += "		?SET_NOME,";
            query += "		?EMP_ID,";
            query += "		1";
            query += "	); ";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?SET_NOME", setor.Set_nome));
            objComando.Parameters.Add(Mapped.Parameter("?EMP_ID", setor.Emp_id.Emp_id));


            objComando.ExecuteNonQuery();

            objConexao.Dispose();
            objComando.Dispose();

            ok = true;
        }
        catch (Exception e)
        {
            Console.Write(e);
        }

        return ok;
    }



    //1 capitura info mes atual 
    public static DataSet ContarXpPontoMoedaPorData1Setor(int set_id, int menos)
    {

        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " SELECT ";
        query += "     SUM(mis.mis_qtd_exp) 'qtd_exp',";
        query += "     SUM(mis.mis_qtd_pontos) 'qtd_pontos',";
        query += "     SUM(mis.mis_qtd_moedas) 'qtd_moedas',";
        query += "     mus_dt_Conclusao 'mus_dt_conclusao'";
        query += " FROM";
        query += "     missao_usuario mus ";
        query += "     JOIN missao mis ON mis.mis_id = mus.mis_id";
        query += "     JOIN usuario usu ON usu.usu_id = mus.usu_id";
        query += " WHERE";
        query += "     MONTH(mus.mus_dt_conclusao) = MONTH(SYSDATE()) - ?menos";
        query += "     AND YEAR(mus.mus_dt_conclusao) = YEAR(SYSDATE())";
        query += "     AND mus.mus_status = 'VALIDADA'";
        query += "     AND usu.set_id = ?set_id";



        objCommand = Mapped.Command(query, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?set_id", set_id));
        objCommand.Parameters.Add(Mapped.Parameter("?menos", menos));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }


    //1 capitura info SEMANAL atual 
    public static DataSet ContarXpPontoMoedaPorSemanaSetor(int set_id, int menos)
    {

        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " SELECT ";
        query += "     SUM(mis.mis_qtd_exp) 'qtd_exp',";
        query += "     SUM(mis.mis_qtd_pontos) 'qtd_pontos',";
        query += "     SUM(mis.mis_qtd_moedas) 'qtd_moedas',";
        query += "     mus_dt_Conclusao 'mus_dt_conclusao'";
        query += " FROM";
        query += "     missao_usuario mus ";
        query += "     JOIN missao mis ON mis.mis_id = mus.mis_id";
        query += "     JOIN usuario usu ON usu.usu_id = mus.usu_id";
        query += " WHERE";
        query += "     DAY(mus.mus_dt_conclusao) = DAY(SYSDATE()) - ?menos  ";
        query += "     AND MONTH(mus.mus_dt_conclusao) = MONTH(SYSDATE())";
        query += "     AND YEAR(mus.mus_dt_conclusao) = YEAR(SYSDATE())";
        query += "     AND mus.mus_status = 'VALIDADA'";
        query += "     AND usu.set_id = ?set_id";



        objCommand = Mapped.Command(query, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?set_id", set_id));
        objCommand.Parameters.Add(Mapped.Parameter("?menos", menos));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

    

}