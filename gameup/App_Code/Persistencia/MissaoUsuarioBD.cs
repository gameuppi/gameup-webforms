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
            query += "	INTO TBL_MISSAO_USUARIO ( ";
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
            objComando.Parameters.Add(Mapped.Parameter("?usu_id", missaoUsuario.Usuario.Id));

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

}