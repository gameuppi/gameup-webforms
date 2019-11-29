using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de MissaoBD
/// </summary>
public class MissaoBD
{
    public static bool InsertMissao(Missao missao)
    {
        bool ok = true;

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;

            objConexao = Mapped.Connection();

            string query = "";
            query += "INSERT ";
            query += "	INTO TBL_MISSAO ( ";
            query += "		MIS_NOME, ";
            query += "		MIS_DESCRICAO, ";
            query += "		MIS_DT_CRIACAO, ";
            query += "		MIS_DT_INICIO, ";
            query += "		MIS_DT_FINAL, ";
            query += "		MIS_QTD_PONTOS, ";
            query += "		MIS_QTD_EXP, ";
            query += "		MIS_QTD_MOEDAS, ";
            query += "		MIS_TIPO, ";
            query += "		MIS_STATUS ";
            query += "	) ";
            query += "VALUES ( ";
            query += "		?MIS_NOME, ";
            query += "		?MIS_DESCRICAO, ";
            query += "		?MIS_DT_CRIACAO, ";
            query += "		?MIS_DT_INICIO, ";
            query += "		?MIS_DT_FINAL, ";
            query += "		?MIS_QTD_PONTOS, ";
            query += "		?MIS_QTD_EXP, ";
            query += "		?MIS_QTD_MOEDAS, ";
            query += "		?MIS_TIPO, ";
            query += "		?MIS_STATUS ";
            query += "	); ";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?mis_nome", missao.Nome.ToUpper()));
            objComando.Parameters.Add(Mapped.Parameter("?mis_descricao", missao.Descricao));
            objComando.Parameters.Add(Mapped.Parameter("?mis_dt_criacao", missao.DtCriacao));
            objComando.Parameters.Add(Mapped.Parameter("?mis_dt_inicio", missao.DtInicio));
            objComando.Parameters.Add(Mapped.Parameter("?mis_dt_final", missao.DtFinal));
            objComando.Parameters.Add(Mapped.Parameter("?mis_qtd_pontos", missao.QtdPontos));
            objComando.Parameters.Add(Mapped.Parameter("?mis_qtd_exp", missao.QtdExp));
            objComando.Parameters.Add(Mapped.Parameter("?mis_qtd_moedas", missao.QtdMoedas));
            objComando.Parameters.Add(Mapped.Parameter("?mis_tipo", missao.Tipo));
            objComando.Parameters.Add(Mapped.Parameter("?mis_status", missao.Status));

            objComando.ExecuteNonQuery();

            objConexao.Dispose();
            objComando.Dispose();
        }
        catch (Exception e)
        {
            Console.Write(e);
            ok = false;
        }

        return ok;
    }

    public static bool UpdateMissao(Missao missao)
    {
        bool ok = true;

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;

            objConexao = Mapped.Connection();

            string query = "";
            query += " UPDATE ";
            query += " 	TBL_MISSAO ";
            query += " SET ";
            query += " 	MIS_NOME = ?MIS_NOME, ";
            query += " 	MIS_DESCRICAO = ?MIS_DESCRICAO, ";
            query += " 	MIS_DT_INICIO = ?MIS_DT_INICIO, ";
            query += " 	MIS_DT_FINAL = ?MIS_DT_FINAL, ";
            query += " 	MIS_QTD_PONTOS = ?MIS_QTD_PONTOS, ";
            query += " 	MIS_QTD_MOEDAS = ?MIS_QTD_MOEDAS, ";
            query += " 	MIS_QTD_EXP = ?MIS_QTD_EXP, ";
            query += " 	MIS_TIPO = ?MIS_TIPO, ";
            query += " 	MIS_STATUS = ?MIS_STATUS  ";
            query += " WHERE ";
            query += " 	MIS_ID = ?MIS_ID ";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?mis_nome", missao.Nome.ToUpper()));
            objComando.Parameters.Add(Mapped.Parameter("?mis_descricao", missao.Descricao));
            objComando.Parameters.Add(Mapped.Parameter("?mis_dt_criacao", missao.DtCriacao));
            objComando.Parameters.Add(Mapped.Parameter("?mis_dt_inicio", missao.DtInicio));
            objComando.Parameters.Add(Mapped.Parameter("?mis_dt_final", missao.DtFinal));
            objComando.Parameters.Add(Mapped.Parameter("?mis_qtd_pontos", missao.QtdPontos));
            objComando.Parameters.Add(Mapped.Parameter("?mis_qtd_exp", missao.QtdExp));
            objComando.Parameters.Add(Mapped.Parameter("?mis_qtd_moedas", missao.QtdMoedas));
            objComando.Parameters.Add(Mapped.Parameter("?mis_tipo", missao.Tipo));
            objComando.Parameters.Add(Mapped.Parameter("?mis_status", missao.Status));
            objComando.Parameters.Add(Mapped.Parameter("?mis_id", missao.Id));


            objComando.ExecuteNonQuery();

            objConexao.Dispose();
            objComando.Dispose();
        }
        catch (Exception e)
        {
            Console.Write(e);
            ok = false;
        }

        return ok;
    }

    public static DataSet procurarMissaoPoId(int mis_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "SELECT * from tbl_missao WHERE mis_id = ?mis_id";

        objCommand = Mapped.Command(query, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?mis_id", mis_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

    public static DataSet procurarMissao()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "SELECT * FROM TBL_MISSAO";

        objCommand = Mapped.Command(query, objConexao);
        

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

    public static DataSet procurarMissaoUsuarioPorId(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " 	SELECT ";
        query += " 	    MIS_ID, ";
        query += " 	    MUS_DT_ATRIBUICAO, ";
        query += " 	    MUS_DT_CONCLUSAO ";
        query += " 	FROM ";
        query += " 	    TBL_MISSAO_USUARIO ";
        query += " 	WHERE ";
        query += " 		USU_ID = ?USU_ID; ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_id", id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

    public static DataSet procurarTodasMissaoUsuario()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " 	SELECT ";
        query += " 	    MIS_ID, ";
        query += " 	    MUS_ID, ";
        query += " 	    MUS_DT_ATRIBUICAO, ";
        query += " 	    MUS_DT_CONCLUSAO, ";
        query += " 	    MUS_STATUS, ";
        query += " 	    USU_ID ";
        query += " 	FROM ";
        query += " 	    TBL_MISSAO_USUARIO ";
        query += " WHERE ";
        query += " 	    MUS_STATUS <> 'INCOMPLETA' ";

        objCommand = Mapped.Command(query, objConexao);

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

    public static DataSet procurarUsuariosEmpresa(int emp_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " 	SELECT ";
        query += " 	    USU_ID, ";
        query += " 	    USU_NOME, ";
        query += " 	    ID_SETOR, ";
        query += " 	    USU_STATUS ";
        query += " 	FROM ";
        query += " 	    TBL_USUARIO ";
        query += " 	WHERE ";
        query += " 	    USU_EMPRESA = ?USU_EMPRESA; ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?USU_EMPRESA", emp_id));

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
        query += " 	    TBL_SETOR ";
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

    public static DataSet procurarIdMissao()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " 	SELECT ";
        query += " 	    MAX(MIS_ID) MIS_ID ";
        query += " 	FROM ";
        query += " 	    TBL_MISSAO ";

        objCommand = Mapped.Command(query, objConexao);

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }
}