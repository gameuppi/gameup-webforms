using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Mapped
/// </summary>
public class Mapped
{
    // Abre a conexão
    public static IDbConnection Connection()
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.AppSettings["strConexao"]);
        objConexao.Open();
        return objConexao;
    }

    // Cria o objeto e valida o conteúdo a ser executado
    public static IDbCommand Command(string query, IDbConnection objConexao)
    {
        IDbCommand objCommand = objConexao.CreateCommand();
        objCommand.CommandText = query;
        return objCommand;
    }

    // Ponte entre dados conexos e desconexos
    public static IDataAdapter Adapter(IDbCommand objCommand)
    {
        IDbDataAdapter adap = new MySqlDataAdapter();
        adap.SelectCommand = objCommand;
        return adap;
    }

    // Parametrização
    public static IDbDataParameter Parameter(string nomeParametro, object valor)
    {
        return new MySqlParameter(nomeParametro, valor);
    }
}