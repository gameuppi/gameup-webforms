using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de MissaoUsuario
/// </summary>
public class MissaoUsuario
{
    private int id;
    private DateTime dtAtribuicao;
    private DateTime dtConclusao;
    private DateTime dtValidacao;
    private StatusMissaoEnum status;
    private Missao missao;
    private Usuario usuario;

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

    public DateTime DtAtribuicao
    {
        get
        {
            return dtAtribuicao;
        }

        set
        {
            dtAtribuicao = value;
        }
    }

    public DateTime DtConclusao
    {
        get
        {
            return dtConclusao;
        }

        set
        {
            dtConclusao = value;
        }
    }

    public StatusMissaoEnum Status
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

    public Missao Missao
    {
        get
        {
            return missao;
        }

        set
        {
            missao = value;
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

    public DateTime DtValidacao
    {
        get
        {
            return dtValidacao;
        }

        set
        {
            dtValidacao = value;
        }
    }
}