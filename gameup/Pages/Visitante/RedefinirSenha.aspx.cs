using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text.RegularExpressions;

public partial class Pages_Visitante_RedefinirSenha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string nome = "";
        DataSet usuarioExiste = UsuarioBD.procurarUsuarioPorEmail(email);

        if (usuarioExiste.Tables[0].Rows.Count <= 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalEmailNaoEncontrado').modal('show');</script>");
        }
        else
        {
            string codigo = gerarCodigo(5);
            try
            {
                int id = Convert.ToInt32(usuarioExiste.Tables[0].Rows[0]["usu_id"].ToString());
                bool ok = salvarCodigo(codigo, id);

                if (ok)
                {
                    nome = usuarioExiste.Tables[0].Rows[0]["usu_nome"].ToString();
                    EnviarEmail(email, nome, codigo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalRedefinicaoEnviada').modal('show');</script>");
        }
    }

    private bool salvarCodigo(string codigo, int id)
    {
        CodigoSeguranca codigoSeguranca = new CodigoSeguranca();
        codigoSeguranca.Id = id;
        codigoSeguranca.Codigo = codigo;
        codigoSeguranca.DtCriacao = DateTime.Now;
        codigoSeguranca.DtValidade = DateTime.Now.AddHours(1);

        bool ok = CodigoSegurancaBD.InsertCodigoSeguranca(codigoSeguranca);

        return ok;
    }

    public string gerarCodigo(int tamanho)
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var codigo = new string(
            Enumerable.Repeat(chars, tamanho)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());

        return codigo;
    }

    public bool EnviarEmail(string destinatario, string nome, string codigo)
    {
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("gameup.enterprise@gmail.com", "Equipe GameUP");

            mailMessage.CC.Add(destinatario);
            mailMessage.Subject = "Redefinição de senha";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "Olá, <b>" + nome + "</b> <br /> Digite o código a seguir na tela em que você solicitou a redefinição de senha: " + codigo;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("gameup.enterprise@gmail.com", "B@n@n@123");

            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);

            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public static bool SalvarNovaSenha(string senha, string email)
    {
        bool ok = false;

        Regex padraoSenha = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{6,})");

        try
        {
            if (padraoSenha.IsMatch(senha))
            {
                UsuarioBD.UpdateNovaSenha(senha, email);
                ok = true;
            } else
            {
                ok = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ok;
    }


    [WebMethod]
    public static bool verificarCodigo(string codigoDigitado, string email)
    {
        bool ok = false;
        try
        {
            DataSet usuario = UsuarioBD.procurarUsuarioPorEmail(email);
            DataSet codigoInfo = CodigoSegurancaBD.BuscarCodigoSegurancaPorId(Convert.ToInt32(usuario.Tables[0].Rows[0]["usu_id"].ToString()));

            string codigo = codigoInfo.Tables[0].Rows[0]["cse_codigo"].ToString();
            int idCodigo = Convert.ToInt32(codigoInfo.Tables[0].Rows[0]["cse_id"].ToString());
            StatusCodigoSegurancaEnum statusCodigo = (StatusCodigoSegurancaEnum) Enum.Parse(typeof(StatusCodigoSegurancaEnum), codigoInfo.Tables[0].Rows[0]["cse_status"].ToString());
            DateTime dtValidade = Convert.ToDateTime(codigoInfo.Tables[0].Rows[0]["cse_dtvalidade"].ToString());

            if (DateTime.Now.CompareTo(dtValidade) <= 0 && codigoDigitado.Equals(codigo) && statusCodigo.Equals(StatusCodigoSegurancaEnum.NAO_VALIDADO)) // Se for antes desse momento e os códigos forem iguais
            {
                bool atualizou = AtualizarStatusDoCodigo(idCodigo, StatusCodigoSegurancaEnum.VALIDADO); // Atualiza o status do codigo no banco

                if (atualizou)
                {
                    ok = true;
                }
            }

            return ok;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public static bool salvarNovaSenha(string senha, string confirmaSenha, string email)
    {
        bool ok = false;
        Regex padraoSenha = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{6,})");

        try
        {
            if (padraoSenha.IsMatch(senha))
            {
                ok = UsuarioBD.UpdateNovaSenha(senha, email);
            }
            else
            {
                ok = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ok;
    }

    public static bool AtualizarStatusDoCodigo(int idCodigo, StatusCodigoSegurancaEnum status)
    {
        bool ok = false;
        try
        {
            bool atualizou = CodigoSegurancaBD.UpdateStatusCodigoPorId(idCodigo, status);

            if (atualizou)
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
        }
        catch (Exception ex)
        {
            ok = false;
        }

        return ok;
    }

}