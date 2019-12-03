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
        if (Session["USUARIO"] != null)
        {
            Usuario usuario = (Usuario)Session["USUARIO"];
            lblNome.Text = usuario.Usu_nome;
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



    protected void btnSair_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#logoutModal').modal('show');</script>");
    }
}
