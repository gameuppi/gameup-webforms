using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Gerente_ConfirmarCompra : System.Web.UI.Page
{
    static Usuario usuarioLogado;
    static Produto produto;

    protected void Page_Load(object sender, EventArgs e)
    {
        usuarioLogado = (Usuario)Session["USUARIO"];

        produto = CriarObjetoProduto(ProdutoDB.procurarPorId(Convert.ToInt32(Request.QueryString["pro_id"])));
        MovimentacaoEstoque mvEstoque = CarregaObjetoEstoque(produto.Id);

        imgLogo.ImageUrl = produto.LogoUrl;
        txtNome.Text = produto.Nome;
        txtQtd.Text = $"{mvEstoque.Mes_saldo.ToString()} Disponíveis";
        txtValor.Text = $"{produto.Preco.ToString()} Moedas";
        txtSub.Text = produto.Subtitulo;
        txtDescricao.Text = produto.Descricao;
    }


    public Produto CriarObjetoProduto(DataSet produtoDs)
    {
        Produto produto = new Produto();

        try
        {
            foreach (DataRow pro in produtoDs.Tables[0].Rows)
            {
                produto.Id = Convert.ToInt32(pro["pro_id"]);
                produto.Nome = pro["pro_nome"].ToString();
                produto.Subtitulo = pro["pro_subTitulo"].ToString();
                produto.Descricao = pro["pro_descricao"].ToString();
                produto.LogoUrl = pro["pro_logo"].ToString();

                if (Convert.ToInt32(pro["pro_status"]) == 1)
                {
                    produto.Status = StatusProdutoEnum.DISPONIVEL;
                }
                else
                {
                    produto.Status = StatusProdutoEnum.INDISPONIVEL;
                }

                if (pro["pro_valorMoeda"] != null)
                {
                    produto.Preco = Convert.ToInt32(pro["pro_valorMoeda"]);
                }

                Empresa emp = new Empresa();
                TipoItemsEnum tip = new TipoItemsEnum();
                Usuario usu = new Usuario();

                emp.Emp_id = Convert.ToInt32(pro["emp_id"]);
                produto.Empresa = emp;

                tip.Tip_id = Convert.ToInt32(pro["tip_id"]);
                produto.Categoria = CategoriaProdutoEnum.FISICO; // arrumar

                usu.Usu_id = Convert.ToInt32(pro["usu_id"]);
                produto.Usuario = usu;
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.StackTrace);
        }

        return produto;
    }

    public MovimentacaoEstoque CarregaObjetoEstoque(int pro_id)
    {
        DataSet movestoque = ProdutoDB.procurarEstoquePorId(pro_id);
        MovimentacaoEstoque mes = new MovimentacaoEstoque();

        foreach (DataRow me in movestoque.Tables[0].Rows)
        {
            mes.Mes_id = Convert.ToInt32(me["mes_id"]);
            mes.Mes_qtdEntrada = Convert.ToInt32(me["mes_qtdEntrada"]);
            mes.Mes_qtdSaida = Convert.ToInt32(me["mes_qtdSaida"]);
            mes.Mes_saldo = Convert.ToInt32(me["mes_saldo"]);
        }

        return mes;
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        if (ProdutoDB.FazMovimentacaoFinanceira(produto, usuarioLogado))
        {
            Session["EXIBEMODAL"] = "Produto adquirido com sucesso!!!";
            Response.Redirect("LojaVirtual.aspx");
        }
        else
        {
            // Preenche modal
            msgModalCadastraMissao.Text = "<h5 class='text-danger'>Falha ao comprar o produto, seu saldo pode ser insuficiente!</h5>";
            ltrTituloModal.Text = "Oops!";
            // Abre modal de sucesso
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalCompra').modal('show');</script>");
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("LojaVirtual.aspx");
    }
}