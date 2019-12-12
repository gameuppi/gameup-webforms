using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageColaborador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ltrCss.Text = "<link href=\"/Assets/Custom/Css/sb-admin-2.css\" rel=\"stylesheet\">";
        ltrCss.Text += "<link href=\"/Assets/Custom/Css/main.css\" rel=\"stylesheet\">";

        
        if (Session["USUARIO"] != null)
        {
            Usuario usuario = (Usuario)Session["USUARIO"];
            lblNome.Text = formatarNome(usuario.Usu_nome);
        } else
        {
            Response.Redirect("../Visitante/Login.aspx");
        }
    }

    protected void btnSairDeVez_Click(object sender, EventArgs e)
    {
        Session["USUARIO"] = null;
        Response.Redirect("../Visitante/Login.aspx");

    }

    string formatarNome(string nome)
    {
        string nomeFormatado = nome;

        if (nome.Count() > 8)
        {
            string[] nomes = nome.Split(' ');
            nomeFormatado = nomes[0] + " " + nomes[1].Substring(0, 1) + ".";
        }

        return nomeFormatado;
    }

    protected void btnSair_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#logoutModal').modal('show');</script>");
    }

    protected void btnModoEscuro_Click(object sender, EventArgs e)
    {
        ltrCss.Text = "<link href=\"/Assets/Custom/Css/sb-admin-2-escuro.css\" rel=\"stylesheet\">";
        ltrCss.Text += "<link href=\"/Assets/Custom/Css/main-escuro.css\" rel=\"stylesheet\">";
    }

    protected void btnModoContraste_Click(object sender, EventArgs e)
    {

        ltrCss.Text = "<link href=\"/Assets/Custom/Css/sb-admin-2-escuro.css\" rel=\"stylesheet\">";
        ltrCss.Text += "<link href=\"/Assets/Custom/Css/main-escuro.css\" rel=\"stylesheet\">";
    }
}
