using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Loja
/// </summary>
public class Produto
{
    private int pro_id;
    private string pro_nome;
    private string pro_subTitulo;
    private string pro_descricao;
    private int pro_valorMoeda;
    private string pro_logo;
    private StatusProdutoEnum pro_status;
    private Empresa emp_id;
    private Usuario usu_id;
    private TipoItemsEnum tip_id;

    public int Pro_id
    {
        get
        {
            return pro_id;
        }

        set
        {
            pro_id = value;
        }
    }

    public string Pro_nome
    {
        get
        {
            return pro_nome;
        }

        set
        {
            pro_nome = value;
        }
    }

    public string Pro_subTitulo
    {
        get
        {
            return pro_subTitulo;
        }

        set
        {
            pro_subTitulo = value;
        }
    }

    public string Pro_descricao
    {
        get
        {
            return pro_descricao;
        }

        set
        {
            pro_descricao = value;
        }
    }

    public int Pro_valorMoeda
    {
        get
        {
            return pro_valorMoeda;
        }

        set
        {
            pro_valorMoeda = value;
        }
    }

    public string Pro_logo
    {
        get
        {
            return pro_logo;
        }

        set
        {
            pro_logo = value;
        }
    }

    public StatusProdutoEnum Pro_status
    {
        get
        {
            return pro_status;
        }

        set
        {
            pro_status = value;
        }
    }

    public Empresa Emp_id
    {
        get
        {
            return emp_id;
        }

        set
        {
            emp_id = value;
        }
    }

    public Usuario Usu_id
    {
        get
        {
            return usu_id;
        }

        set
        {
            usu_id = value;
        }
    }

    public TipoItemsEnum Tip_id
    {
        get
        {
            return tip_id;
        }

        set
        {
            tip_id = value;
        }
    }
}