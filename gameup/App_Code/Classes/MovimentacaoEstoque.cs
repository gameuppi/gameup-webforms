using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de MovimentacaoEstoque
/// </summary>
public class MovimentacaoEstoque
{
    private int mes_id;
    private DateTime mes_dHCriacao;
    private int mes_qtdEntrada;
    private int mes_qtdSaida;
    private int mes_saldo;
    private string mes_descricao;
    private Produto pro_id;
    private Empresa emp_id;

    public int Mes_id
    {
        get
        {
            return mes_id;
        }

        set
        {
            mes_id = value;
        }
    }

    public DateTime Mes_dHCriacao
    {
        get
        {
            return mes_dHCriacao;
        }

        set
        {
            mes_dHCriacao = value;
        }
    }

    public int Mes_qtdEntrada
    {
        get
        {
            return mes_qtdEntrada;
        }

        set
        {
            mes_qtdEntrada = value;
        }
    }

    public int Mes_qtdSaida
    {
        get
        {
            return mes_qtdSaida;
        }

        set
        {
            mes_qtdSaida = value;
        }
    }

    public int Mes_saldo
    {
        get
        {
            return mes_saldo;
        }

        set
        {
            mes_saldo = value;
        }
    }

    public string Mes_descricao
    {
        get
        {
            return mes_descricao;
        }

        set
        {
            mes_descricao = value;
        }
    }

    public Produto Pro_id
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
}