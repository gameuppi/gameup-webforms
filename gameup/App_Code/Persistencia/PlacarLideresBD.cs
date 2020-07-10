using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de PlacarLideresBD
/// </summary>
public class PlacarLideresBD
{
    public static DataSet procurarUsuariosPlacarGeral(int emp_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "SELECT usu_nome, usu_qtdPontos from usuario WHERE emp_id = ?emp_id AND tus_id <> '3' order by usu_qtdpontos desc";

        objCommand = Mapped.Command(query, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", emp_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

    public static DataSet procurarUsuariosPlacarMensal(int emp_id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objCommand;
        IDataAdapter dataAdapter;

        objConexao = Mapped.Connection();
        string query = "SELECT SUM(mis.mis_qtd_pontos) as usu_qtdPontos, usu.usu_nome as usu_nome FROM missao_usuario mus JOIN missao mis ON mis.mis_id = mus.mis_id JOIN usuario usu ON usu.usu_id = mus.usu_id WHERE usu.emp_id = ?emp_id AND MONTH(mus.mus_dt_conclusao) = MONTH(SYSDATE()) ORDER BY usu_qtdPontos desc";

        objCommand = Mapped.Command(query, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?emp_id", emp_id));

        dataAdapter = Mapped.Adapter(objCommand);

        dataAdapter.Fill(ds);

        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

        return ds;

    }

}