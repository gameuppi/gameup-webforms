using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Visitante_CompletarCadastro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        if (checkConcordo.Checked)
        {
            Regex padraoSenha = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{6,})");

            if (txtSenha.Text.Equals(txtConfirmarSenha.Text) && padraoSenha.IsMatch(txtSenha.Text))
            {
                Usuario usu = new Usuario();

                usu.Usu_email = txtEmail.Text;
                usu.Usu_senha = UsuarioDB.Cryptografia(txtSenha.Text);
                usu.Usu_dataNascimento = Convert.ToDateTime(txtDataNascimento.Text);

                switch (UsuarioDB.CompletarCadastro(usu))
                {
                    case 0:
                        Response.Redirect("Login.aspx");
                        //sucesso + redirect
                        break;
                    case -2:
                        //erro
                        break;
                }

            }
            else
            {
                ltlMsg.Text = "<br /><p>Vish, suas senhas não coincidem ou não seguem os padrões de segurança</p>";
            } 
        }
        else
        {
            ltlMsg.Text = "<br /><p>Vish, você precisa aceitar e concordar com nossos termos.</p>";
        }
    }
}