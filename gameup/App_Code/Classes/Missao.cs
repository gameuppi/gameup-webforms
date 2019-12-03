using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Missao
/// </summary>
public class Missao
{
    private int id;
    private string nome;
    private string descricao;
    private DateTime dtCriacao;
    private DateTime dtInicio;
    private DateTime dtFinal;
    private int qtdPontos;
    private int qtdExp;
    private int qtdMoedas;
    private string tipo;
    private string status;
    private Usuario usuarioCriador;

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

    public DateTime DtInicio
    {
        get
        {
            return dtInicio;
        }

        set
        {
            dtInicio = value;
        }
    }

    public DateTime DtFinal
    {
        get
        {
            return dtFinal;
        }

        set
        {
            dtFinal = value;
        }
    }

    public int QtdPontos
    {
        get
        {
            return qtdPontos;
        }

        set
        {
            qtdPontos = value;
        }
    }

    public int QtdExp
    {
        get
        {
            return qtdExp;
        }

        set
        {
            qtdExp = value;
        }
    }

    public int QtdMoedas
    {
        get
        {
            return qtdMoedas;
        }

        set
        {
            qtdMoedas = value;
        }
    }

    public string Tipo
    {
        get
        {
            return tipo;
        }

        set
        {
            tipo = value;
        }
    }

    public string Status
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

    public Usuario UsuarioCriador
    {
        get
        {
            return usuarioCriador;
        }

        set
        {
            usuarioCriador = value;
        }
    }
}