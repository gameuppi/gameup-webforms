using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Visitante_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Salvar_Click(object sender, EventArgs e)
    {
        if (txtSenha.Text.Equals( txtConfirmarSenha.Text ))
        {
            Usuario usu = new Usuario();

            usu.Usu_senha = UsuarioDB.Cryptografia(txtSenha.Text);
            usu.Usu_email = txtEmail.Text;

            UsuarioDB.CadastroSenha(usu);
        }
        else
        {

        }
    }
}