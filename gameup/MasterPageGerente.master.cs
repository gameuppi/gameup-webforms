using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageGerente : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario usuario = (Usuario) Session["USUARIO"];
        lblNome.Text = usuario.Usu_nome;
    }

    protected void btnSair_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#logoutModal').modal('show');</script>");

    }

    protected void btnSairDeVez_Click(object sender, EventArgs e)
    {
        Session["USUARIO"] = null;
        Response.Redirect("../Visitante/Login.aspx");
    }
}
