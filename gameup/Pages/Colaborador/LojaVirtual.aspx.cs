using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Colaborador_LojaVirtual : System.Web.UI.Page
{
    private static Usuario usuarioLogado;

    protected void Page_Load(object sender, EventArgs e)
    {
        //validarSessao();
        CriaCards();
        CarregaMeusProdutos();
    }

    void CarregaMeusProdutos()
    {
        DataSet produtosDs = ProdutoDB.procurarMeusProdutos(usuarioLogado.Usu_id);
        Produto produto;
        List<Produto> listaDeProdutos = new List<Produto>();

        foreach (DataRow p in produtosDs.Tables[0].Rows)
        {
            produto = new Produto();

            if (p["pro_id"] != null)
            {
                produto.Id = Convert.ToInt32(p["pro_id"]);
            }
            produto.Nome = p["pro_nome"].ToString();
            produto.Subtitulo = p["pro_subTitulo"].ToString();
            produto.Descricao = p["pro_descricao"].ToString();
            produto.LogoUrl = p["pro_logo"].ToString();

            listaDeProdutos.Add(produto);
        }

        string resp = "";

        foreach (Produto p in listaDeProdutos)
        {
            resp += " <div class='col-12 col-md-3'> ";
            resp += "     <div class='card-custom border-left-success shadow'> ";
            resp += "         <div class='card-custom-image'> ";
            resp += $"             <img src='{p.LogoUrl}'> ";
            resp += $"             <span class='card-custom-title font-weight-bold'>{p.Nome} ";
            resp += "             </span> ";
            resp += "         </div> ";
            resp += "         <div class='card-custom-content'> ";
            resp += $"             <p>{p.Descricao}</p> ";
            resp += "         </div> ";
            resp += "     </div> ";
            resp += " </div> ";
        

        }
        ltrMeuProdutos.Text = resp;

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

    public List<Produto> CarregaProdutos()
    {
        usuarioLogado = (Usuario)Session["USUARIO"];

        DataSet ds = ProdutoDB.FindAllEmpresa(usuarioLogado.Emp_id);

        List<Produto> listaProdutos = new List<Produto>();
        Produto produto;

        foreach (DataRow p in ds.Tables[0].Rows)
        {
            produto = new Produto();

            if (p["pro_id"] != null)
            {
                produto.Id = Convert.ToInt32(p["pro_id"]);
            }
            produto.Nome = p["pro_nome"].ToString();
            produto.Subtitulo = p["pro_subTitulo"].ToString();
            produto.Descricao = p["pro_descricao"].ToString();
            produto.LogoUrl = p["pro_logo"].ToString();

            if (Convert.ToInt32(p["pro_status"]) == 1)
            {
                produto.Status = StatusProdutoEnum.DISPONIVEL;
            }
            else
            {
                produto.Status = StatusProdutoEnum.INDISPONIVEL;
            }

            if (p["pro_valorMoeda"] != null)
            {
                produto.Preco = Convert.ToInt32(p["pro_valorMoeda"]);
            }

            Empresa emp = new Empresa();
            TipoItemsEnum tip = new TipoItemsEnum();
            Usuario usu = new Usuario();

            emp.Emp_id = Convert.ToInt32(p["emp_id"]);
            produto.Empresa = emp;

            tip.Tip_id = Convert.ToInt32(p["tip_id"]);
            produto.Categoria = CategoriaProdutoEnum.FISICO; // arrumar

            usu.Usu_id = Convert.ToInt32(p["usu_id"]);
            produto.Usuario = usu;

            listaProdutos.Add(produto);
        }

        return listaProdutos;
    }

    public MovimentacaoEstoque CarregaObjetoEstoque( int pro_id)
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

    void CriaCards()
    {
        List<Produto> listaPro = CarregaProdutos();

        foreach (Produto pro in listaPro)
        {
            MovimentacaoEstoque mes_qtd = CarregaObjetoEstoque(pro.Id);
            Literal ltlImg = new Literal();
            ltlImg.Text = $"<div class='col-12 col-md-3'>" +
                          $"    <div class='card-custom border-left-success shadow h-100'>" +
                          $"        <div class='card-custom-image'>" +
                          $"            <img src='{pro.LogoUrl}'>" +
                          $"            <span class='card-custom-title font-weight-bold'>{pro.Nome}" +
                          $"            <br /><small>{mes_qtd.Mes_saldo} disponíveis</small>" +
                          $"            </span><div class='text-center'>";

            LinkButton btnCard = new LinkButton();
            btnCard.Click += (sender, e) => { this.ContinuarCompra(sender, e, pro.Id); };
            btnCard.ID = pro.Id.ToString();
            btnCard.CssClass = "btn-floating btn-large halfway-fab btn-success fas fa-shopping-cart text-white";

            Literal ltlText = new Literal();
            ltlText.Text += $"      </div></div><br/><div class='col-md-12 card-custom-content'>" +
                           $"           <p>{pro.Subtitulo}</p>" +
                           $"           <p>{pro.Preco} Moedas</p>" +
                           $"       </div>" +
                           $"   </div>" +
                           $"</div>";

            painel1.Controls.Add(ltlImg);
            painel1.Controls.Add(btnCard);
            painel1.Controls.Add(ltlText);
        }
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
    private void ContinuarCompra(object sender, EventArgs e, int pro_id)
    {
        //Produto produto = CriarObjetoProduto(ProdutoDB.procurarPorId(pro_id));

        string url = $"ConfirmarCompra.aspx?pro_id={pro_id}";

        Response.Redirect(url);

    }

    
}