﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.IO;
using System.Security.Cryptography;

/// <summary>
/// Descrição resumida de UsuarioDB
/// </summary>
public class UsuarioDB
{
    private static int ok;
    
    public static string Cryptografia(string pwd)
    {
        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] HashValue, MessageBytes = UE.GetBytes(pwd);
        SHA512Managed SHhash = new SHA512Managed();
        string strHex = "";
        HashValue = SHhash.ComputeHash(MessageBytes);
        foreach (byte b in HashValue)
        {
            strHex += String.Format("{0:x2}", b);
        }
        return strHex;

    }

    public static int Login( string email, string pwd)
    {
        try
        {
            DataSet ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter dataAdapter;
            objConexao = Mapped.Connection();

            string query = "select usu_email, usu_senha from usuario where usu_email = ?usu_email";
            objCommand = Mapped.Command(query, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_email", email));
            dataAdapter = Mapped.Adapter(objCommand);
            dataAdapter.Fill(ds);

            if ( ds.Tables[0].Rows[0]["usu_email"].ToString().Equals(email))
            {
                if (ds.Tables[0].Rows[0]["usu_senha"].ToString().Equals(Cryptografia(pwd)))
                {
                    ok = 1;
                }
                else
                {
                    ok = -1;
                }
            }
            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();
        }
        catch (Exception)
        {

            ok = -2;
        }

        return ok;
    }

    public static int CadastroSenha( Usuario usu )
    {
        int ok;

        try
        {
            DataSet ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objCommand;
            objConexao = Mapped.Connection();

            string query = "update usuario SET usu_senha = ?usu_senha WHERE usu_email = ?usu_email";

            objCommand = Mapped.Command(query, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", usu.Usu_senha));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_email", usu.Usu_email));

            objCommand.ExecuteNonQuery();

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            ok = 0;
        }
        catch (Exception)
        {
            ok = -2;
        }

        return ok;
    }
    
}