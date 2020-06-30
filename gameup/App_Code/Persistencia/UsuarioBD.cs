using System;
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

    public static DataSet procurarUsuarioPorEmpresa(int emp_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "SELECT usu_id, usu_nome, usu_email, tus_id, set_id, usu_statususuario from usuario WHERE emp_id = ?emp_id order by usu_nome";

        objCommand = Mapped.Command(query, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", emp_id));

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

    public static bool salvarAlteracoesPerfil(Usuario usuario)
    {
        bool ok = false;
        try
        {
            DataSet ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objCommand;
            objConexao = Mapped.Connection();

            string query = "update usuario SET usu_nome = ?usu_nome, usu_apelido = ?usu_apelido WHERE usu_id = ?usu_id";

            objCommand = Mapped.Command(query, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usuario.Usu_id));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_nome", usuario.Usu_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_apelido", usuario.Usu_apelido));

            objCommand.ExecuteNonQuery();

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            ok = true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.StackTrace);
        }

        return ok;

    }

    public static bool UpdateGerente(int usu_id)
    {
        bool ok = false;
        try
        {
            DataSet ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objCommand;
            objConexao = Mapped.Connection();

            string query = "update usuario SET tus_id = ?tus_id WHERE usu_id = ?usu_id";

            objCommand = Mapped.Command(query, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));
            objCommand.Parameters.Add(Mapped.Parameter("?tus_id", 2));

            objCommand.ExecuteNonQuery();

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            ok = true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.StackTrace);
        }

        return ok;

    }

    public static bool UpdateGerente2(int usu_id)
    {
        bool ok = false;
        try
        {
            DataSet ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objCommand;
            objConexao = Mapped.Connection();

            string query = "update usuario SET tus_id = ?tus_id WHERE usu_id = ?usu_id";

            objCommand = Mapped.Command(query, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));
            objCommand.Parameters.Add(Mapped.Parameter("?tus_id", 1));

            objCommand.ExecuteNonQuery();

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            ok = true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.StackTrace);
        }

        return ok;

    }

    public static bool UpdateInativo(int usu_id)
    {
        bool ok = false;
        try
        {
            DataSet ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objCommand;
            objConexao = Mapped.Connection();

            string query = "update usuario SET usu_statususuario = ?status WHERE usu_id = ?usu_id";

            objCommand = Mapped.Command(query, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));
            objCommand.Parameters.Add(Mapped.Parameter("?status", 2));

            objCommand.ExecuteNonQuery();

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            ok = true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.StackTrace);
        }

        return ok;

    }

    public static bool UpdateInativo2(int usu_id)
    {
        bool ok = false;
        try
        {
            DataSet ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objCommand;
            objConexao = Mapped.Connection();

            string query = "update usuario SET usu_statususuario = ?status WHERE usu_id = ?usu_id";

            objCommand = Mapped.Command(query, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));
            objCommand.Parameters.Add(Mapped.Parameter("?status", 1));

            objCommand.ExecuteNonQuery();

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            ok = true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.StackTrace);
        }

        return ok;

    }

    public static bool UpdateNovaSenha(string senha, string email)
    {
        bool ok = false;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            objConexao = Mapped.Connection();

            string query = "update usuario SET usu_senha = ?usu_senha WHERE usu_email = ?usu_email";

            objCommand = Mapped.Command(query, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", UsuarioDB.Cryptografia(senha.Trim())));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_email", email.Trim()));

            objCommand.ExecuteNonQuery();

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            ok = true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.StackTrace);
        }

        return ok;
    }

    public static bool InsertColaborador(Usuario usuario)
    {
        bool ok = false;

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;

            objConexao = Mapped.Connection();

            string query = "";
            query += "INSERT  ";
            query += "	INTO USUARIO( ";
            query += "		USU_NOME, ";
            query += "		USU_EMAIL, ";
            query += "		EMP_ID, ";
            query += "		SET_ID, ";
            query += "		TUS_ID, ";
            query += "		NIV_ID ";
            query += "	) ";
            query += "VALUES ( ";
            query += "		?USU_NOME, ";
            query += "		?USU_EMAIL, ";
            query += "		?EMP_ID, ";
            query += "		?SET_ID, ";
            query += "		?TUS_ID, ";
            query += "		1 ";
            query += "	); ";

            objComando = Mapped.Command(query, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?USU_NOME", usuario.Usu_nome));
            objComando.Parameters.Add(Mapped.Parameter("?USU_EMAIL", usuario.Usu_email));
            objComando.Parameters.Add(Mapped.Parameter("?EMP_ID", usuario.Emp_id));
            objComando.Parameters.Add(Mapped.Parameter("?SET_ID", usuario.Set_id));
            objComando.Parameters.Add(Mapped.Parameter("?TUS_ID", usuario.Tus_id));


            objComando.ExecuteNonQuery();

            objConexao.Dispose();
            objComando.Dispose();

            ok = true;
        }
        catch (Exception e)
        {
            Console.Write(e);
        }

        return ok;
    }
}