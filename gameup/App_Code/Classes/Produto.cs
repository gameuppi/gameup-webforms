using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Loja
/// </summary>
public class Produto
{
    private int id;
    private string nome;
    private string subtitulo;
    private string descricao;
    private int preco;
    private string logoUrl;
    private StatusProdutoEnum status;
    private Empresa empresa;
    private Usuario usuario;
    private CategoriaProdutoEnum categoria;
    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Nome
    {
        get
        {
            return nome;
        }

        set
        {
            nome = value;
        }
    }

    public string Subtitulo
    {
        get
        {
            return subtitulo;
        }

        set
        {
            subtitulo = value;
        }
    }

    public string Descricao
    {
        get
        {
            return descricao;
        }

        set
        {
            descricao = value;
        }
    }

    public int Preco
    {
        get
        {
            return preco;
        }

        set
        {
            preco = value;
        }
    }

    public string LogoUrl
    {
        get
        {
            return logoUrl;
        }

        set
        {
            logoUrl = value;
        }
    }

    public StatusProdutoEnum Status
    {
        get
        {
            return status;
        }

        set
        {
            status = value;
        }
    }

    public Empresa Empresa
    {
        get
        {
            return empresa;
        }

        set
        {
            empresa = value;
        }
    }

    public Usuario Usuario
    {
        get
        {
            return usuario;
        }

        set
        {
            usuario = value;
        }
    }

    public CategoriaProdutoEnum Categoria
    {
        get
        {
            return categoria;
        }

        set
        {
            categoria = value;
        }
    }
}