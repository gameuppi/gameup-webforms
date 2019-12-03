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


}