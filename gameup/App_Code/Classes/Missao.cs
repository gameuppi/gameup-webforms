using System;
using System.Collections.Generic;
using System.Data;
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

    public List<Missao> criarListaObjMissao(DataSet missoes)
    {
        List<Missao> listaDeMissoes = new List<Missao>();
        Missao missao;
        foreach (DataRow mis in missoes.Tables[0].Rows)
        {
            missao = new Missao();
            missao.Id = Convert.ToInt32(mis["mis_id"]);
            missao.Nome = mis["mis_nome"].ToString();
            missao.Descricao = mis["mis_descricao"].ToString();

            // Verifica se possui data inicio
            if (mis["mis_dt_inicio"] != null)
            {
                missao.DtInicio = Convert.ToDateTime(mis["mis_dt_inicio"]);
            }

            // Verifica se possui data fim
            if (mis["mis_dt_final"] != null)
            {
                missao.DtFinal = Convert.ToDateTime(mis["mis_dt_final"]);
            }

            // Verifica se possui qtd pontos
            if (mis["mis_qtd_pontos"] != null)
            {
                missao.QtdPontos = Convert.ToInt32(mis["mis_qtd_pontos"]);
            }

            // Verifica se possui qtd moedas
            if (mis["mis_qtd_moedas"] != null)
            {
                missao.QtdMoedas = Convert.ToInt32(mis["mis_qtd_moedas"]);
            }

            // Verifica se possui qtd exp
            if (mis["mis_qtd_exp"] != null)
            {
                missao.QtdPontos = Convert.ToInt32(mis["mis_qtd_exp"]);
            }

            missao.Status = mis["mis_status"].ToString();
            missao.Tipo = mis["mis_tipo"].ToString();

            listaDeMissoes.Add(missao);
        }

        return listaDeMissoes;
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