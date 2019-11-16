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
            query += "		MIS_ID, ";
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
            query += "		?MIS_ID, ";
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
            objComando.Parameters.Add(Mapped.Parameter("?mis_id", missao.Id));
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

    /*public static DataSet procurarMissaoPoId(int mis_id)
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

    } */

    public static DataSet procurarMissao()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "SELECT * FROM missao";

        objCommand = Mapped.Command(query, objConexao);
        

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

    /*public static DataSet procurarMissaoUsuario()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " SELECT ";
        query += "     MIS.MIS_NOME, ";
        query += "     MIS.MIS_DESCRICAO, ";
        query += "     MUS.MUS_DT_ATRIBUICAO, ";
        query += "     MUS.MUS_DT_CONCLUSAO ";
        query += " FROM ";
        query += "     TBL_MISSAO_USUARIO MUS ";
        query += "     JOIN TBL_MISSAO MIS ON MUS.MIS_ID = MIS.MIS_ID; ";

        objCommand = Mapped.Command(query, objConexao);

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }*/
}