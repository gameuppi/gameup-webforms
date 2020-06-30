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
            query += "	INTO MISSAO ( ";
            query += "		MIS_NOME, ";
            query += "		MIS_DESCRICAO, ";
            query += "		MIS_DT_CRIACAO, ";
            query += "		MIS_DT_INICIO, ";
            query += "		MIS_DT_FINAL, ";
            query += "		MIS_QTD_PONTOS, ";
            query += "		MIS_QTD_EXP, ";
            query += "		MIS_QTD_MOEDAS, ";
            query += "		MIS_TIPO, ";
            query += "		MIS_STATUS, ";
            query += "		USU_CRIADOR_ID, ";
            query += "		EMP_ID ";
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
            query += "		?MIS_STATUS, ";
            query += "		?USU_CRIADOR_ID, ";
            query += "		?EMP_ID ";
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
            objComando.Parameters.Add(Mapped.Parameter("?usu_criador_id", missao.UsuarioCriador.Usu_id));
            objComando.Parameters.Add(Mapped.Parameter("?emp_id", missao.UsuarioCriador.Emp_id));


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
            query += " 	MISSAO ";
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
        string query = "SELECT * from missao WHERE mis_id = ?mis_id";

        objCommand = Mapped.Command(query, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?mis_id", mis_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

    public static DataSet procurarDetalhesMissaoPoId(int mus_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " SELECT ";
        query += "    MUS.MIS_ID, ";
        query += "    MUS.MUS_ID, ";
        query += "    MUS.MUS_DT_CONCLUSAO, ";
        query += "    MIS.MIS_QTD_PONTOS, ";
        query += "    MIS.MIS_QTD_MOEDAS, ";
        query += "    MIS.MIS_QTD_EXP, ";
        query += "    MUS.USU_ID ";
        query += " FROM ";
        query += "    MISSAO_USUARIO MUS ";
        query += "    JOIN MISSAO MIS ON MUS.MIS_ID = MIS.MIS_ID ";
        query += " WHERE ";
        query += "    MUS.MUS_ID = ?mus_id ";

        objCommand = Mapped.Command(query, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?mus_id", mus_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

    public static DataSet procurarMissao(int emp_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "SELECT * FROM missao where emp_id = ?emp_id";

        objCommand = Mapped.Command(query, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", emp_id));
               
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
        query += " 	    MISSAO_USUARIO ";
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

    public static DataSet procurarTodasMissaoUsuarioGerente(int usu_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " SELECT ";
        query += "     MUS.MIS_ID, ";
        query += "     MUS.MUS_ID, ";
        query += "     MUS.MUS_DT_ATRIBUICAO, ";
        query += "     MUS.MUS_DT_CONCLUSAO, ";
        query += "     MUS.MUS_STATUS, ";
        query += "     MUS.USU_ID,";
        query += "     MIS.EMP_ID";
        query += " FROM ";
        query += "     MISSAO_USUARIO MUS";
        query += "     JOIN MISSAO MIS ON MUS.MIS_ID = MIS.MIS_ID";
        query += " WHERE ";
        query += "     MUS.MUS_STATUS <> 'INCOMPLETA' ";
        query += "     AND MIS.USU_CRIADOR_ID = ?usu_id";
        
        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

    public static DataSet procurarTodasMissaoUsuarioGerentePorStatus(int usu_id, string status)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " SELECT ";
        query += "     MUS.MIS_ID, ";
        query += "     MUS.MUS_ID, ";
        query += "     MUS.MUS_DT_ATRIBUICAO, ";
        query += "     MUS.MUS_DT_CONCLUSAO, ";
        query += "     MUS.MUS_STATUS, ";
        query += "     MUS.USU_ID,";
        query += "     MIS.EMP_ID";
        query += " FROM ";
        query += "     MISSAO_USUARIO MUS";
        query += "     JOIN MISSAO MIS ON MUS.MIS_ID = MIS.MIS_ID";
        query += " WHERE ";
        query += "     MUS.MUS_STATUS = ?status ";
        query += "     AND MIS.USU_CRIADOR_ID = ?usu_id";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?status", status));
        objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static DataSet procurarTodasMissaoUsuarioColaborador(int usu_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " SELECT ";
        query += "     MUS.MIS_ID, ";
        query += "     MUS.MUS_ID, ";
        query += "     MUS.MUS_DT_ATRIBUICAO, ";
        query += "     MUS.MUS_DT_CONCLUSAO, ";
        query += "     MUS.MUS_STATUS, ";
        query += "     MUS.USU_ID,";
        query += "     MIS.EMP_ID";
        query += " FROM ";
        query += "     MISSAO_USUARIO MUS";
        query += "     JOIN MISSAO MIS ON MUS.MIS_ID = MIS.MIS_ID";
        query += " WHERE ";
        query += "     MUS.MUS_STATUS <> 'INCOMPLETA' ";
        query += "     AND MUS.USU_ID = ?usu_id";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }


    public static DataSet procurarTodasMissaoUsuarioColaboradorSetor(int set_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " SELECT ";
        query += "     MUS.MIS_ID, ";
        query += "     MUS.MUS_ID, ";
        query += "     MUS.MUS_DT_ATRIBUICAO, ";
        query += "     MUS.MUS_DT_CONCLUSAO, ";
        query += "     MUS.MUS_STATUS, ";
        query += "     MUS.USU_ID,";
        query += "     MIS.EMP_ID,";
        query += "     USU.SET_ID";
        query += " FROM ";
        query += "     MISSAO_USUARIO MUS";
        query += "     JOIN MISSAO MIS ON MUS.MIS_ID = MIS.MIS_ID";
        query += "     JOIN usuario usu ON usu.usu_id = mus.usu_id";
        query += " WHERE ";
        query += "     MUS.MUS_STATUS <> 'INCOMPLETA' ";
        query += "     AND SET_ID = ?set_id";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?set_id", set_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }


    public static DataSet procurarTodasMissaoUsuarioColaboradorEmpresa(int emp_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " SELECT ";
        query += "     MUS.MIS_ID, ";
        query += "     MUS.MUS_ID, ";
        query += "     MUS.MUS_DT_ATRIBUICAO, ";
        query += "     MUS.MUS_DT_CONCLUSAO, ";
        query += "     MUS.MUS_STATUS, ";
        query += "     MUS.USU_ID,";
        query += "     MIS.EMP_ID,";
        query += "     USU.SET_ID";
        query += " FROM ";
        query += "     MISSAO_USUARIO MUS";
        query += "     JOIN MISSAO MIS ON MUS.MIS_ID = MIS.MIS_ID";
        query += "     JOIN usuario usu ON usu.usu_id = mus.usu_id";
        query += " WHERE ";
        query += "     MUS.MUS_STATUS <> 'INCOMPLETA' ";
        query += "     AND usu.emp_ID = ?emp_id";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", emp_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }




    public static DataSet procurarTodasMissaoUsuarioColaboradorPorStatus(int usu_id, string status)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " SELECT ";
        query += "     MUS.MIS_ID, ";
        query += "     MUS.MUS_ID, ";
        query += "     MUS.MUS_DT_ATRIBUICAO, ";
        query += "     MUS.MUS_DT_CONCLUSAO, ";
        query += "     MUS.MUS_STATUS, ";
        query += "     MUS.USU_ID,";
        query += "     MIS.EMP_ID";
        query += " FROM ";
        query += "     MISSAO_USUARIO MUS";
        query += "     JOIN MISSAO MIS ON MUS.MIS_ID = MIS.MIS_ID";
        query += " WHERE ";
        query += "     MUS.MUS_STATUS = ?status ";
        query += "     AND MUS.USU_ID = ?usu_id";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?status", status));
        objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static DataSet procurarUsuariosEmpresa(int emp_id, int usu_id)
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
        query += " 	    SET_ID, ";
        query += " 	    USU_STATUSUSUARIO ";
        query += " 	FROM ";
        query += " 	    USUARIO ";
        query += " 	WHERE ";
        query += " 	    EMP_ID = ?emp_id ";
        query += " 	    AND USU_ID <> ?usu_id; ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", emp_id));
        objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));

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

    public static DataSet procurarSetoresEmpresaGerente(int set_id)
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
        query += " 	    SET_ID = ?set_id; ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?SET_ID", set_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }

    public static DataSet procurarIdMissao(int usu_id)
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
        query += " 	    MISSAO ";
        query += " 	WHERE ";
        query += " 	    USU_CRIADOR_ID = ?usu_id ";

        objCommand = Mapped.Command(query, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));
        
        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;
    }
}