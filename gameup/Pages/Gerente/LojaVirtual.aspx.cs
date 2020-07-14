using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Gerente_LojaVirtual : System.Web.UI.Page
{
    private static Usuario usuarioLogado;

    protected void Page_Load(object sender, EventArgs e)
    {
        validarSessao();
        CriaCards();
        CarregaMeusProdutos();

        string exibeModal;

        if (Session["EXIBEMODAL"] != null)
        {
            exibeModal = (string)Session["EXIBEMODAL"].ToString();

            if (!exibeModal.Equals(""))
            {
                // Preenche modal
                msgModalCadastraMissao.Text = $"<h5 class='text-sucess'>{exibeModal}</h5>";
                ltrTituloModal.Text = "Ótimo!";
                // Abre modal de sucesso
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalCompra').modal('show');</script>");

                Session["EXIBEMODAL"] = null;
            }
        }

    }

    void CarregaMeusProdutos()
    {
        rptMeusProdutos.DataSource = ProdutoDB.procurarMeusProdutos(usuarioLogado.Usu_id);
        rptMeusProdutos.DataBind();
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

            if (usuarioLogado.Tus_id != 2) // Gerente
            {
                Response.Redirect("../Visitante/Login.aspx");
            }

        }
    }

    void CriaCards()
    {
        usuarioLogado = (Usuario)Session["USUARIO"];

        rptProdutos.DataSource = ProdutoDB.FindAllEmpresa(usuarioLogado.Emp_id);
        rptProdutos.DataBind();
    }

    protected void rptProdutos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Comprar")
        {
            string url = $"ConfirmarCompra.aspx?pro_id={Convert.ToInt32(e.CommandArgument.ToString())}";

            Response.Redirect(url);
        }
    }
}