using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de CodigoSeguranca
/// </summary>
public class CodigoSeguranca
{
    private string email;
    private string codigo;
    private DateTime dtCriacao;
    private DateTime dtValidade;

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

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
}