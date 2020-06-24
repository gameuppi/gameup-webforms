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
        popularResumo();
    }

    void popularResumo()
    {
        int qtdItensAtivos = ProdutoDB.BuscarQtdItensAtivos(usuarioLogado);
        int qtdItensDisponiveis = ProdutoDB.BuscarQtdItensDisponiveis(usuarioLogado);
        int qtdMoedasGastas = ProdutoDB.BuscarQtdMoedasGastas(usuarioLogado);
        int qtdItensVendidos = ProdutoDB.BuscarQtdItensVendidos(usuarioLogado);
        //int qtdItemMaisVendido = ProdutoDB.BuscarQtdItemMaisVendido(usuarioLogado);
        //string nomeItemMaisVendido = ProdutoDB.BuscarNomeItemMaisVendido(usuarioLogado);

        lblIQtdItensAtivos.Text = qtdItensAtivos.ToString();
        lblQtdItensDisponiveis.Text = qtdItensDisponiveis.ToString();
        lblQtdMoedasGastas.Text = qtdMoedasGastas.ToString();
        lblQtdItensVendidos.Text = qtdItensVendidos.ToString();
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
            usuarioLogado
        );

        if (ProdutoDB.InsertProduto(produto))
        {
            ProdutoDB.InsertMovimentacaoEstoque(produto, Convert.ToInt32(txtQuantidade.Text));
        }
    }

    protected Produto criarObjetoProduto(string nome, string subtitulo, string descricao, int preco, int quantidade, string categoria, Usuario usuarioLogado)
    {
        Produto produto = new Produto();
        produto.Nome = nome;
        produto.Subtitulo = subtitulo;
        produto.Descricao = descricao;
        produto.Preco = preco;
        produto.Categoria = (CategoriaProdutoEnum)Enum.Parse(typeof(CategoriaProdutoEnum), categoria);
        Empresa empresa = new Empresa();
        produto.Empresa = empresa;
        produto.Empresa.Emp_id = usuarioLogado.Emp_id;
        produto.Usuario = usuarioLogado;

        return produto;
    }
}