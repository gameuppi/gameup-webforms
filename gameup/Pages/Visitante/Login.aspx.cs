using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Visitante_Login : System.Web.UI.Page
{
    static List<Usuario> listaUsuarios = new List<Usuario>();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();
        usu.Usu_email = txtEmail.Text;
        usu.Usu_senha = txtSenha.Text;


        switch ( UsuarioDB.Login(usu))
        {
            case 1:
                listaUsuarios.Add(usu);
                Session["LISTAUSUARIOS"] = listaUsuarios;
                Response.Redirect("../Colaborador/PainelPrincipal.aspx");
                break;
            case -1:
                ltlMsg.Text = "<ul><li>Senha Inválida</li></ul>";
                break;
            case -2:
                ltlMsg.Text = "<ul><li>Email Inválido</li></ul>";
                break;
        }
    }
}