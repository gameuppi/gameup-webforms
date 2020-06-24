using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Representante_GerenciarLojaVirtual : System.Web.UI.Page
{
    private static Usuario usuarioLogado;
    protected void Page_Load(object sender, EventArgs e)
    {
        validarSessao();
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

            if (usuarioLogado.Tus_id != 3) // Representante
            {
                Response.Redirect("../Visitante/Login.aspx");
            }

        }
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        Produto produto = criarObjetoProduto(
            txtNome.Text, 
            txtSubtitulo.Text, 
            txtDescricao.Text, 
            Convert.ToInt32(txtValorMoeda.Text), 
            Convert.ToInt32(txtQuantidade.Text),
            drpCategoria.SelectedValue,
            usuarioLogado.Emp_id
        );

        if (ProdutoDB.InsertProduto(produto))
        {
            ProdutoDB.InsertMovimentacaoEstoque(produto, Convert.ToInt32(txtQuantidade));
        }
    }

    protected Produto criarObjetoProduto(string nome, string subtitulo, string descricao, int preco, int quantidade, string categoria, int empresa)
    {
        Produto produto = new Produto();
        produto.Nome = nome;
        produto.Subtitulo = subtitulo;
        produto.Descricao = descricao;
        produto.Preco = preco;
        produto.Categoria = (CategoriaProdutoEnum)Enum.Parse(typeof(CategoriaProdutoEnum), categoria);
        produto.EmpresaId.Emp_id = empresa;

        return produto;
    }
}