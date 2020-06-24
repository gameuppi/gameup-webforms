using System;
using System.Collections.Generic;
using System.Data;
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
        popularVisualizacaoDeProdutos();
    }

    void popularResumo()
    {
        int qtdItensAtivos = ProdutoDB.BuscarQtdItensAtivos(usuarioLogado);
        int qtdItensDisponiveis = ProdutoDB.BuscarQtdItensDisponiveis(usuarioLogado);
        int qtdMoedasGastas = ProdutoDB.BuscarQtdMoedasGastas(usuarioLogado);
        int qtdItensVendidos = ProdutoDB.BuscarQtdItensVendidos(usuarioLogado);
        int qtdItemMaisVendido = ProdutoDB.BuscarQtdItemMaisVendido(usuarioLogado);
        string nomeItemMaisVendido = ProdutoDB.BuscarNomeItemMaisVendido(usuarioLogado);

        lblIQtdItensAtivos.Text = qtdItensAtivos.ToString();
        lblQtdItensDisponiveis.Text = qtdItensDisponiveis.ToString();
        lblQtdMoedasGastas.Text = qtdMoedasGastas.ToString();
        lblQtdItensVendidos.Text = qtdItensVendidos.ToString();
        lblQtdItemMaisVendido.Text = qtdItemMaisVendido.ToString();
        lblNomeItemMaisVendido.Text = nomeItemMaisVendido;
    }

    void popularVisualizacaoDeProdutos()
    {
        DataSet produtos = ProdutoDB.BuscarTodosOsProdutosPorEmpresaEStatus(usuarioLogado.Emp_id, StatusProdutoEnum.DISPONIVEL);
        ProdutoEstoque produto;
        List<ProdutoEstoque> listaDeProdutos = new List<ProdutoEstoque>();

        foreach (DataRow prod in produtos.Tables[0].Rows)
        {
            produto = criarObjetoProdutoEstoque(
                    prod["nome"].ToString(),
                    prod["subtitulo"].ToString(),
                    prod["descricao"].ToString(),
                    Convert.ToInt32(prod["preco"].ToString()),
                    Convert.ToInt32(prod["quantidade"].ToString()),
                    prod["categoria"].ToString(),
                    usuarioLogado,
                    prod["logo_url"].ToString()
            );

            listaDeProdutos.Add(produto);
        }

        foreach(ProdutoEstoque prod in listaDeProdutos)
        {
            Literal ltlImg = new Literal();
            ltlImg.Text = $"<div class='col-12 col-md-3'>" +
                          $"    <div class='card-custom border-left-success shadow h-100'>" +
                          $"        <div class='card-custom-image'>" +
                          $"            <img src='{prod.LogoUrl}'>" +
                          $"            <span class='card-custom-title font-weight-bold'>{prod.Nome}" +
                          $"            <br /><small>{prod.Quantidade} disponíveis</small>" +
                          $"            </span><div class='text-center'>";

            LinkButton btnCard = new LinkButton();
            //btnCard.Click += (sender, e) => { this.ContinuarCompra(sender, e, pro.Id); };
            //btnCard.ID = prod.Id.ToString();
            btnCard.CssClass = "btn-floating btn-large halfway-fab btn-success fas fa-shopping-cart text-white";

            Literal ltlText = new Literal();
            ltlText.Text += $"      </div></div><br/><div class='col-md-12 card-custom-content'>" +
                           $"           <p>{prod.Subtitulo}</p>" +
                           $"           <p>{prod.Preco} Moedas</p>" +
                           $"       </div>" +
                           $"   </div>" +
                           $"</div>";

            pnlVisualizarProdutos.Controls.Add(ltlImg);
            pnlVisualizarProdutos.Controls.Add(btnCard);
            pnlVisualizarProdutos.Controls.Add(ltlText);
        }
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

        String[] logos = new string[] {
            "../../Assets/Imagens/jantar.jpg",
            "../../Assets/Imagens/tempo.jpg",
            "../../Assets/Imagens/piscina.jpg"
        };

        Random random = new Random();
        int posicao = random.Next(0, logos.Length);
        string logoUrl = logos[posicao];

        produto.LogoUrl = logoUrl;

        return produto;
    }

    protected ProdutoEstoque criarObjetoProdutoEstoque(string nome, string subtitulo, string descricao, int preco, int quantidade, string categoria, Usuario usuarioLogado, string logoUrl)
    {
        ProdutoEstoque produto = new ProdutoEstoque();
        produto.Nome = nome;
        produto.Subtitulo = subtitulo;
        produto.Descricao = descricao;
        produto.Preco = preco;
        produto.Quantidade = quantidade;
        produto.Categoria = (CategoriaProdutoEnum)Enum.Parse(typeof(CategoriaProdutoEnum), categoria);
        produto.LogoUrl = logoUrl;

        return produto;
    }

}