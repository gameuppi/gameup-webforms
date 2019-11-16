using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Visitante_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        switch ( UsuarioDB.Login(txtEmail.Text, txtSenha.Text))
        {
            case 1:
                ltlMsg.Text = "<ul><li>Sucesso</li></ul>";
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