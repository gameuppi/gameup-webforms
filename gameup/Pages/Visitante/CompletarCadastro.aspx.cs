using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Visitante_CompletarCadastro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        verificaHashDaUrl();
    }

    protected void verificaHashDaUrl()
    {
        bool ok = false;
        string hash = Request.QueryString["hash"];

        if (hash != null)
        {
            string hashConvertida = lerHash(hash);
            string[] dados = hashConvertida.Split('&');

            try
            {
                DateTime dataValidade = Convert.ToDateTime(dados[0]);

                if (dataValidade > DateTime.Now)
                {
                    ok = true;
                    txtEmail.Text = dados[1];
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        if (!ok)
        {
            Response.Redirect("http://localhost:62235/Pages/Visitante/Login.aspx");
        }
    }
    protected string lerHash(string texto)
    {
        string resultado = "";

        try
        {
            var encode = new UTF8Encoding();
            var utf8Decode = encode.GetDecoder();

            byte[] stringValor = Convert.FromBase64String(texto);

            int contador = utf8Decode.GetCharCount(stringValor, 0, stringValor.Length);

            char[] decodeChar = new char[contador];
            utf8Decode.GetChars(stringValor, 0, stringValor.Length, decodeChar, 0);

            resultado = new string(decodeChar);

            
        } catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return resultado;
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

    protected void btnConfirmarRedirecionamento_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:62235/Pages/Visitante/Login.aspx");
    }
}