using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de CodigoSeguranca
/// </summary>
public class CodigoSeguranca
{
    private int id;
    private string codigo;
    private DateTime dtCriacao;
    private DateTime dtValidade;


    public string Codigo
    {
        get
        {
            return codigo;
        }

        set
        {
            codigo = value;
        }
    }

    public DateTime DtCriacao
    {
        get
        {
            return dtCriacao;
        }

        set
        {
            dtCriacao = value;
        }
    }

    public DateTime DtValidade
    {
        get
        {
            return dtValidade;
        }

        set
        {
            dtValidade = value;
        }
    }

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
}