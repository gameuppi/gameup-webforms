using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de MissaoUsuarioBD
/// </summary>
public class MissaoUsuarioBD
{

    public static bool InsertMissaoUsuario(MissaoUsuario missaoUsuario)
    {
        bool ok = true;

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;

            objConexao = Mapped.Connection();

            string query = "";
            query += "INSERT ";
            query += "	INTO MISSAO_USUARIO ( ";
            query += "		MUS_DT_ATRIBUICAO, ";
            query += "		MUS_DT_CONCLUSAO, ";
            query += "		MUS_STATUS, ";
            query += "		MIS_ID, ";
            query += "		USU_ID ";
            query += "	) ";
            query += "VALUES ( ";
            query += "		?MUS_DT_ATRIBUICAO, ";
            query += "		?MUS_DT_CONCLUSAO, ";
            query += "		?MUS_STATUS, ";
            query += "		?MIS_ID, ";
            query += "		?USU_ID ";
            query += "	); ";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?mus_dt_atribuicao", missaoUsuario.DtAtribuicao));
            objComando.Parameters.Add(Mapped.Parameter("?mus_dt_conclusao", missaoUsuario.DtConclusao));
            objComando.Parameters.Add(Mapped.Parameter("?mus_status", missaoUsuario.Status.ToString()));
            objComando.Parameters.Add(Mapped.Parameter("?mis_id", missaoUsuario.Missao.Id));
            objComando.Parameters.Add(Mapped.Parameter("?usu_id", missaoUsuario.Usuario.Usu_id));

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

    public static bool validarMissao(MissaoUsuario missaoUsuario)
    {
        bool ok = true;

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;

            objConexao = Mapped.Connection();

            string query = "";
            query += " UPDATE ";
            query += " 	MISSAO_USUARIO ";
            query += " SET ";
            query += " 	MUS_STATUS = ?mus_status, ";
            query += " 	MUS_DT_VALIDACAO = ?dt_validacao ";
            query += " WHERE  ";
            query += " 	MUS_ID = ?mus_id; ";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?mus_status", missaoUsuario.Status.ToString()));
            objComando.Parameters.Add(Mapped.Parameter("?mus_id", missaoUsuario.Id));
            objComando.Parameters.Add(Mapped.Parameter("?dt_validacao", missaoUsuario.DtValidacao));
            
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

    public static bool concluirMissao(MissaoUsuario missaoUsuario)
    {
        bool ok = true;

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;

            objConexao = Mapped.Connection();

            string query = "";
            query += " UPDATE ";
            query += " 	MISSAO_USUARIO ";
            query += " SET ";
            query += " 	MUS_STATUS = ?mus_status, ";
            query += " 	MUS_DT_CONCLUSAO = ?dt_conclusao ";
            query += " WHERE  ";
            query += " 	MUS_ID = ?mus_id; ";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?mus_status", missaoUsuario.Status.ToString()));
            objComando.Parameters.Add(Mapped.Parameter("?mus_id", missaoUsuario.Id));
            objComando.Parameters.Add(Mapped.Parameter("?dt_conclusao", missaoUsuario.DtConclusao));

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


    public static DataSet procurarMissaoUsuarioPorId(int mus_id)
    {

        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "";
        query += " SELECT  ";
        query += " 	MUS_ID, ";
        query += " 	USU_ID, ";
        query += " 	MIS_ID, ";
        query += " 	MUS_DT_CONCLUSAO ";
        query += " FROM ";
        query += " 	MISSAO_USUARIO ";
        query += " WHERE  ";
        query += " 	MUS_ID = ?mus_id; ";

        objCommand = Mapped.Command(query, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?mus_id", mus_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

}