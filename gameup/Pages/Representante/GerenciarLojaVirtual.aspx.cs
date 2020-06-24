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
        DataSet produtos = ProdutoDB.BuscarTodosOsProdutosPorEmpresaEStatus(usuarioLogado.Emp_id);
        ProdutoEstoque produto;
        List<ProdutoEstoque> listaDeProdutos = new List<ProdutoEstoque>();

        foreach (DataRow prod in produtos.Tables[0].Rows)
        {
            produto = criarObjetoProdutoEstoque(
                    Convert.ToInt32(prod["id"].ToString()),
                    prod["nome"].ToString(),
                    prod["subtitulo"].ToString(),
                    prod["descricao"].ToString(),
                    Convert.ToInt32(prod["preco"].ToString()),
                    !prod["quantidade"].ToString().Equals("") ? Convert.ToInt32(prod["quantidade"].ToString()) : 0,
                    prod["categoria"].ToString(),
                    usuarioLogado,
                    prod["logo_url"].ToString(),
                    (StatusProdutoEnum)Enum.Parse(typeof(StatusProdutoEnum), prod["status"].ToString())
            );

            listaDeProdutos.Add(produto);
        }

        foreach(ProdutoEstoque prod in listaDeProdutos)
        {
            Literal ltlImg = new Literal();
            ltlImg.Text = $"<div class='col-12 col-md-3 mt-2'>" +
                          $"    <div class='card-custom border-left-success shadow h-100'>" +
                          $"        <div class='card-custom-image'>" +
                          $"            <img src='{prod.LogoUrl}'>" +
                          $"            <span class='card-custom-title font-weight-bold'>{prod.Nome}" +
                          $"            <br /><small>{prod.Quantidade} disponíveis</small>" +
                          $"            </span><div class='text-center'>";

            LinkButton btnCard = new LinkButton();
            btnCard.Click += (sender, e) => { this.VisualizarListaCompradores(sender, e, prod.Id); };
            btnCard.ID = prod.Id.ToString();
            btnCard.CssClass = "btn-floating btn-large halfway-fab btn-info";
            btnCard.Text = "<center><i class='fas fa-list text-white'></i></center>";

            Literal ltlText = new Literal();
            ltlText.Text += $"      </div></div><br/><div class='col-md-12 card-custom-content'>" +
                           $"           <p>{prod.Subtitulo}</p>" +
                           $"           <p>{prod.Preco} Moedas</p>" +
                           $"           <div class='row mt-3 d-flex justify-content-between'>";

            Button btnAtivar = new Button();
            btnAtivar.CssClass = "btn btn-success col-5";
            btnAtivar.Text = "Ativar";
            btnAtivar.Click += (sender, e) => { this.AtivarProduto(sender, e, prod.Id); };
            btnAtivar.ID = prod.Id.ToString() + "ativar";

            Button btnDesativar = new Button();
            btnDesativar.CssClass = "btn btn-danger col-5";
            btnDesativar.Text = "Desativar";
            btnDesativar.Click += (sender, e) => { this.DesativarProduto(sender, e, prod.Id); };
            btnDesativar.ID = prod.Id.ToString() + "desativar";

            if (prod.Status.Equals(StatusProdutoEnum.DISPONIVEL))
            {
                btnAtivar.Enabled = false;
                btnAtivar.Attributes["disabled"] = "disabled";
            } else if (prod.Status.Equals(StatusProdutoEnum.INDISPONIVEL))
            {
                btnDesativar.Enabled = false;
                btnDesativar.Attributes["disabled"] = "disabled";
            }

            Literal ltlTextFinal = new Literal();
            ltlTextFinal.Text += $" </div> </div></div> </div>";

            pnlVisualizarProdutos.Controls.Add(ltlImg);
            pnlVisualizarProdutos.Controls.Add(btnCard);
            pnlVisualizarProdutos.Controls.Add(ltlText);
            pnlVisualizarProdutos.Controls.Add(btnAtivar);
            pnlVisualizarProdutos.Controls.Add(btnDesativar);
            pnlVisualizarProdutos.Controls.Add(ltlTextFinal);
        }
    }

    private void AtivarProduto(object sender, EventArgs e, int pro_id)
    {
        ProdutoDB.AlterarStatusProduto(pro_id, StatusProdutoEnum.DISPONIVEL);
    }

    private void DesativarProduto(object sender, EventArgs e, int pro_id)
    {
        ProdutoDB.AlterarStatusProduto(pro_id, StatusProdutoEnum.INDISPONIVEL);
    }

    private void VisualizarListaCompradores(object sender, EventArgs e, int pro_id)
    {
        DataSet listaDeUsuarios = ProdutoDB.BuscarCompradoresPorIdDoProduto(pro_id);

        List<UsuarioComprador> listaDeUsuarioComprador = new List<UsuarioComprador>();
        UsuarioComprador usuarioComprador;

        foreach (DataRow usu in listaDeUsuarios.Tables[0].Rows)
        {
            usuarioComprador = criarObjetoUsuarioComprador(
                    usu["usu_nome"].ToString(),
                    usu["set_nome"].ToString()
            );

            listaDeUsuarioComprador.Add(usuarioComprador);
        }

        // Carrega o modal 
        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalParticipantes').modal('show');</script>");

        // Carrega os colaboradores no modal
        foreach(UsuarioComprador usuario in listaDeUsuarioComprador)
        {
            ltbCompradores.Items.Add(new ListItem(usuario.NomeUsuario, usuario.NomeSetor));
        }
    }

    protected UsuarioComprador criarObjetoUsuarioComprador(string nomeUsuario, string nomeSetor)
    {
        UsuarioComprador usuario = new UsuarioComprador();
        usuario.NomeUsuario = nomeUsuario;
        usuario.NomeSetor = nomeSetor;

        return usuario;
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
            lblCorpo.Text = "<h5 class='text-success'> Novo produto cadastrado com sucesso!</h5>";
            lblTitulo.Text = "Ótimo!";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalGenerico').modal('show');</script>");

            txtNome.Text = "";
            txtSubtitulo.Text = "";
            txtDescricao.Text = "";
            txtValorMoeda.Text = "";
            txtQuantidade.Text = "";
            drpCategoria.Text = "";
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
        produto.Status = StatusProdutoEnum.DISPONIVEL;

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

    protected ProdutoEstoque criarObjetoProdutoEstoque(int id, string nome, string subtitulo, string descricao, int preco, int quantidade, string categoria, Usuario usuarioLogado, string logoUrl, StatusProdutoEnum status)
    {
        ProdutoEstoque produto = new ProdutoEstoque();
        produto.Id = id;
        produto.Nome = nome;
        produto.Subtitulo = subtitulo;
        produto.Descricao = descricao;
        produto.Preco = preco;
        produto.Quantidade = quantidade;
        produto.Categoria = (CategoriaProdutoEnum)Enum.Parse(typeof(CategoriaProdutoEnum), categoria);
        produto.LogoUrl = logoUrl;
        produto.Status = status;

        return produto;
    }

}