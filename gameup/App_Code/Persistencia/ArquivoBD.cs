using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Arquivo
/// </summary>
public class ArquivoBD
{
    public static bool InserirArquivo(string caminho, int id)
    {
        bool ok = true;

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;

            objConexao = Mapped.Connection();

            string query = "";
            query += " UPDATE missao_usuario ";
            query += " SET ";
            query += "     mus_arquivo = ?caminhoArquivo ";
            query += " WHERE ";
            query += "     mus_id = ?mus_id ";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?caminhoArquivo", caminho));
            objComando.Parameters.Add(Mapped.Parameter("?mus_id", id));

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

    public static DataSet BuscarNomeDoArquivoPorIdDaMissaoUsuario(int idMissaoUsuario)
    {
        try
        {
            DataSet ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter dataAdapter;

            objConexao = Mapped.Connection();
            string query = "";
            query += " SELECT ";
            query += " 	mus_arquivo ";
            query += " FROM ";
            query += " 	missao_usuario ";
            query += " WHERE ";
            query += " 	mus_id = ?id ";

            objCommand = Mapped.Command(query, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?id", idMissaoUsuario));

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