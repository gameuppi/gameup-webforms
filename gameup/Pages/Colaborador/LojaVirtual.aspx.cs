﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Colaborador_LojaVirtual : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CriaCards();
    }

    List<Produto> CarregaProdutos()
    {
        DataSet ds = ProdutoDB.FindAll();

        List<Produto> listaProdutos = new List<Produto>();
        Produto produto;

        foreach (DataRow p in ds.Tables[0].Rows)
        {
            produto = new Produto();

            if (p["pro_id"] != null)
            {
                produto.Pro_id = Convert.ToInt32(p["pro_id"]);
            }
            produto.Pro_nome = p["pro_nome"].ToString();
            produto.Pro_subTitulo = p["pro_subTitulo"].ToString();
            produto.Pro_descricao = p["pro_descricao"].ToString();
            produto.Pro_logo = p["pro_logo"].ToString();

            if (Convert.ToInt32(p["pro_status"]) == 1)
            {
                produto.Pro_status = StatusProdutoEnum.DISPONIVEL;
            }
            else
            {
                produto.Pro_status = StatusProdutoEnum.INDISPONIVEL;
            }

            if (p["pro_valorMoeda"] != null)
            {
                produto.Pro_valorMoeda = Convert.ToInt32(p["pro_valorMoeda"]);
            }

            Empresa emp = new Empresa();
            TipoItemsEnum tip = new TipoItemsEnum();
            Usuario usu = new Usuario();

            emp.Emp_id = Convert.ToInt32(p["emp_id"]);
            produto.Emp_id = emp;

            tip.Tip_id = Convert.ToInt32(p["tip_id"]);
            produto.Tip_id = tip;

            usu.Usu_id = Convert.ToInt32(p["usu_id"]);
            produto.Usu_id = usu;

            listaProdutos.Add(produto);
        }

        return listaProdutos;
    }

    void CriaCards()
    {
        List<Produto> listaPro = CarregaProdutos();

        foreach (Produto pro in listaPro)
        {
            Literal ltlImg = new Literal();
            ltlImg.Text = $"<div class='col-12 col-md-3'>" +
                          $"    <div class='card-custom border-left-success shadow h-100'>" +
                          $"        <div class='card-custom-image'>" +
                          $"            <img src='{pro.Pro_logo}'>" +
                          $"            <span class='card-custom-title font-weight-bold'>{pro.Pro_nome}" +
                          $"            <br /><small>1 disponíveis</small>" +
                          $"            </span><div class='text-center'>";

            LinkButton btnCard = new LinkButton();
            btnCard.Click += (sender, e) => { this.ContinuarCompra(sender, e, pro.Pro_id); };
            btnCard.ID = pro.Pro_id.ToString();
            btnCard.CssClass = "btn-floating btn-large halfway-fab btn-success fas fa-shopping-cart text-white";

            Literal ltlText = new Literal();
            ltlText.Text += $"      </div></div><br/><div class='col-md-12 card-custom-content'>" +
                           $"           <p>{pro.Pro_subTitulo}</p>" +
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
                produto.Pro_id = Convert.ToInt32(pro["pro_id"]);
                produto.Pro_nome = pro["pro_nome"].ToString();
                produto.Pro_subTitulo = pro["pro_subTitulo"].ToString();
                produto.Pro_descricao = pro["pro_descricao"].ToString();
                produto.Pro_logo = pro["pro_logo"].ToString();

                if (Convert.ToInt32(pro["pro_status"]) == 1)
                {
                    produto.Pro_status = StatusProdutoEnum.DISPONIVEL;
                }
                else
                {
                    produto.Pro_status = StatusProdutoEnum.INDISPONIVEL;
                }

                if (pro["pro_valorMoeda"] != null)
                {
                    produto.Pro_valorMoeda = Convert.ToInt32(pro["pro_valorMoeda"]);
                }

                Empresa emp = new Empresa();
                TipoItemsEnum tip = new TipoItemsEnum();
                Usuario usu = new Usuario();

                emp.Emp_id = Convert.ToInt32(pro["emp_id"]);
                produto.Emp_id = emp;

                tip.Tip_id = Convert.ToInt32(pro["tip_id"]);
                produto.Tip_id = tip;

                usu.Usu_id = Convert.ToInt32(pro["usu_id"]);
                produto.Usu_id = usu;
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
        Produto produto = CriarObjetoProduto(ProdutoDB.procurarPorId(pro_id));


    }

    
}