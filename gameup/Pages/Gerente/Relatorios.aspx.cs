using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Gerente_Relatorios : System.Web.UI.Page
{
    private static Usuario usuarioLogado;
    private static MissaoUsuario missUsuarioLogado;
    protected void Page_Load(object sender, EventArgs e)
    {
        validarSessao();

        if (!IsPostBack)
        {
            
        }
    }

    public string ObterDadosDoUsuario()
    {
        DataTable dados = new DataTable();

        //coluna dos dados
        dados.Columns.Add(new DataColumn("Data", typeof(string)));
        dados.Columns.Add(new DataColumn("Missões Concluidas", typeof(string)));
        dados.Columns.Add(new DataColumn("Pontos", typeof(string)));
        dados.Columns.Add(new DataColumn("Experiencia", typeof(string)));
        // Os dados que serão mostrados no charts

        dados.Rows.Add(new object[] { 2016, 10, 24, 44 });
        dados.Rows.Add(new object[] { 2017, 2, 44, 33  });
        dados.Rows.Add(new object[] { 2018, 3, 7, 11 });
        dados.Rows.Add(new object[] { 2016, 10, 24, 44 });
        dados.Rows.Add(new object[] { 2017, 2, 44, 33 });
        dados.Rows.Add(new object[] { 2018, 3, 7, 11 });

        string strDados;

        strDados = "[['Data','Missões Concluidas', 'Pontos', 'Experiencia'],";

        foreach (DataRow dr in dados.Rows)
        {
            strDados = strDados + "[";
            strDados = strDados + "'" + dr[0] + "'" + "," + dr[1] + "," + dr[2] + "," + dr[3];
            strDados = strDados + "],";
        }
        strDados = strDados + "]";


        return strDados;
    }




















    void validarSessao()
    {
        if (Session["USUARIO"] == null)
        {
            Response.Redirect("../Visitante/Login.aspx");
        }
        else
        {
            usuarioLogado = (Usuario)Session["USUARIO"];

            if (usuarioLogado.Tus_id != 1 && usuarioLogado.Tus_id != 2) // Colaborador ou Gerente
            {
                Response.Redirect("../Visitante/Login.aspx");
            }
        }
    }

}