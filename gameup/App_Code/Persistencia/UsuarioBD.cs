﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de UsuarioBD
/// </summary>
public class UsuarioBD
{
    public static DataSet procurarUsuarioPorId(int usu_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "SELECT * from usuario WHERE usu_id = ?usu_id";

        objCommand = Mapped.Command(query, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

    public static DataSet procurarUsuarioPorEmail(string usu_email)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "SELECT * from usuario WHERE usu_email = ?usu_email";

        objCommand = Mapped.Command(query, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?usu_email", usu_email));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

    public static void atribuirRecompensaUsuario(Usuario usuario)
    {
        try
        {
            DataSet ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objCommand;
            objConexao = Mapped.Connection();

            string query = "update usuario SET usu_qtdXp = ?usu_qtdXp, usu_qtdPontos = ?usu_qtdPontos, usu_qtdMoeda = ?usu_qtdMoeda WHERE usu_id = ?usu_id";

            objCommand = Mapped.Command(query, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usuario.Usu_id));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_qtdXp", usuario.Usu_qtdXp));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_qtdPontos", usuario.Usu_qtdPontos));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_qtdMoeda", usuario.Usu_qtdMoeda));

            objCommand.ExecuteNonQuery();

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();
        }
        catch (Exception ex)
        {
            Console.Write(ex.StackTrace);
        }

    }
}