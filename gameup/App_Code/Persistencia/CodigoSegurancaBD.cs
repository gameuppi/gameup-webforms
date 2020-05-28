using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de CodigoSegurancaBD
/// </summary>
public class CodigoSegurancaBD
{
    public static bool InsertCodigoSeguranca(CodigoSeguranca codigoSeguranca)
    {
        bool ok = true;

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;

            objConexao = Mapped.Connection();

            string query = "";
            query += "INSERT ";
            query += "	INTO CODIGO_SEGURANCA ( ";
            query += "		CSE_EMAIL, ";
            query += "		CSE_CODIGO, ";
            query += "		CSE_DTCRIACAO, ";
            query += "		CSE_DTVALIDADE, ";
            query += "		CSE_STATUS ";
            query += "	) ";
            query += "VALUES ( ";
            query += "		?EMAIL, ";
            query += "		?CODIGO, ";
            query += "		?DTCRIACAO, ";
            query += "		?DTVALIDADE, ";
            query += "		?STATUS ";
            query += "	); ";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?EMAIL", codigoSeguranca.Email));
            objComando.Parameters.Add(Mapped.Parameter("?CODIGO", codigoSeguranca.Codigo));
            objComando.Parameters.Add(Mapped.Parameter("?DTCRIACAO", codigoSeguranca.DtCriacao));
            objComando.Parameters.Add(Mapped.Parameter("?DTVALIDADE", codigoSeguranca.DtValidade));
            objComando.Parameters.Add(Mapped.Parameter("?STATUS", StatusCodigoSegurancaEnum.NAO_VALIDADO));

            objComando.ExecuteNonQuery();

            objConexao.Dispose();
            objComando.Dispose();
        }
        catch (Exception ex)
        {
            ok = false;
            throw ex;
        }

        return ok;
    }

    public static bool UpdateStatusCodigoPorId(int id, StatusCodigoSegurancaEnum status)
    {
        bool ok = false;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;

            objConexao = Mapped.Connection();

            string query = "";
            query += " UPDATE ";
            query += " 	CODIGO_SEGURANCA ";
            query += " SET ";
            query += " 	CSE_STATUS = ?STATUS ";
            query += " WHERE ";
            query += " 	CSE_ID = ?ID ";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?STATUS", status));
            objComando.Parameters.Add(Mapped.Parameter("?ID", id));


            objComando.ExecuteNonQuery();

            objConexao.Dispose();
            objComando.Dispose();

            ok = true;
        }
        catch (Exception ex)
        {
            ok = false;
        }

        return ok;
    }
    public static DataSet BuscarCodigoSegurancaPorEmail(string email)
    {
        try
        {
            DataSet ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter dataAdapter;

            objConexao = Mapped.Connection();
            string query = "";
            query += "SELECT  ";
            query += "	cod.*  ";
            query += "FROM ";
            query += "	 codigo_seguranca cod ";
            query += "WHERE  ";
            query += "	cod.cse_email = ?EMAIL ";
            query += "	AND cod.cse_dtCriacao = ( ";
            query += "		SELECT  ";
            query += "			MAX(cod2.cse_dtcriacao)  ";
            query += "		FROM  ";
            query += "			codigo_seguranca cod2  ";
            query += "		WHERE  ";
            query += "			cod.cse_email = cod2.cse_email ";
            query += "	); ";

            objCommand = Mapped.Command(query, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?EMAIL", email));

            dataAdapter = Mapped.Adapter(objCommand);

            dataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}