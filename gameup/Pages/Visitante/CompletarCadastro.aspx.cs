using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Visitante_AssinaturaDePacote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        if (txtSenha.Text.Equals(txtConfirmarSenha.Text))
        {
            Usuario usu = new Usuario();

            usu.Usu_email = txtEmail.Text;
            usu.Usu_senha = txtSenha.Text;
            usu.Usu_dataNascimento = Convert.ToDateTime(txtDataNascimento.Text);

            switch (UsuarioDB.CompletarCadastro(usu))
            {
                case 0:
                    //sucesso + redirect
                    break;
                case -2:
                    //erro
                    break;
            }
            
        }
        else
        {
            //msg de aviso
        }
    }
}