using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Gerente_MeuPerfil : System.Web.UI.Page
{
    //TELA DE MEU PERFIL DE GERENTE

    private static Usuario usuarioLogado;

    protected void Page_Load(object sender, EventArgs e)
    {
        validarSessao();

        if (!IsPostBack)
        {
            carregarPerfil();
        }
    }


    void carregarPerfil()
    {
        txtNome.Text = usuarioLogado.Usu_nome;
        txtNasc.Text = usuarioLogado.Usu_dataNascimento.ToShortDateString();
        txtEmail.Text = usuarioLogado.Usu_email;
        txtApelido.Text = usuarioLogado.Usu_apelido;

        lblMoedas.Text = usuarioLogado.Usu_qtdMoeda.ToString();
        lblPontos.Text = usuarioLogado.Usu_qtdPontos.ToString();
        lblExp.Text = usuarioLogado.Usu_qtdXp.ToString();
    }

    void validarSessao()
    {

        if (Session["USUARIO"] == null)
        {

            Response.Redirect("../Visitante/Login.aspx");

        }
        else
        {
            usuarioLogado = (Usuario)Session["USUARIO"];

            if (usuarioLogado.Tus_id != 2) // Colaborador ou Gerente
            {
                Response.Redirect("../Visitante/Login.aspx");
            }

        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Usuario usuarioAlterado = new Usuario();
        usuarioAlterado.Usu_nome = txtNome.Text;
        usuarioAlterado.Usu_apelido = txtApelido.Text;
        usuarioAlterado.Usu_id = usuarioLogado.Usu_id;

        usuarioLogado.Usu_nome = usuarioAlterado.Usu_nome;
        usuarioLogado.Usu_apelido = usuarioAlterado.Usu_apelido;

        if (UsuarioBD.salvarAlteracoesPerfil(usuarioAlterado))
        {
            ltrTituloModal.Text = "Ótimo!";
            msgModalCadastraMissao.Text = "Dados alterados com sucesso!";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalSucesso').modal('show');</script>");
        }
        else
        {
            ltrTituloModal.Text = "Ops!";
            msgModalCadastraMissao.Text = "Falha ao alterar os dados!";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalSucesso').modal('show');</script>");
        }

        Session["USUARIO"] = usuarioLogado;
        carregarPerfil();
    }
}