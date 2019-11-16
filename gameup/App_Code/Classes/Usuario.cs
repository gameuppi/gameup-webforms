using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Usuario
/// </summary>
public class Usuario
{
    private int usu_id;
    private string usu_nome;
    private DateTime usu_dataNascimento;
    private string usu_email;
    private string usu_senha;
    private int usu_statusUsuario;
    private string usu_apelido;
    private int usu_qtdMoeda;
    private int usu_qtdXp;
    private int usu_qtdPontos;
    private TipoUsuarioEnum tus_id;
    private Setor set_id;
    private Usuario usu_idGerente;

    public int Usu_id
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

    public string Usu_nome
    {
        get
        {
            return usu_nome;
        }

        set
        {
            usu_nome = value;
        }
    }

    public DateTime Usu_dataNascimento
    {
        get
        {
            return usu_dataNascimento;
        }

        set
        {
            usu_dataNascimento = value;
        }
    }

    public string Usu_email
    {
        get
        {
            return usu_email;
        }

        set
        {
            usu_email = value;
        }
    }

    public string Usu_senha
    {
        get
        {
            return usu_senha;
        }

        set
        {
            usu_senha = value;
        }
    }

    public int Usu_statusUsuario
    {
        get
        {
            return usu_statusUsuario;
        }

        set
        {
            usu_statusUsuario = value;
        }
    }

    public string Usu_apelido
    {
        get
        {
            return usu_apelido;
        }

        set
        {
            usu_apelido = value;
        }
    }

    public int Usu_qtdMoeda
    {
        get
        {
            return usu_qtdMoeda;
        }

        set
        {
            usu_qtdMoeda = value;
        }
    }

    public int Usu_qtdXp
    {
        get
        {
            return usu_qtdXp;
        }

        set
        {
            usu_qtdXp = value;
        }
    }

    public int Usu_qtdPontos
    {
        get
        {
            return usu_qtdPontos;
        }

        set
        {
            usu_qtdPontos = value;
        }
    }

    public TipoUsuarioEnum Tus_id
    {
        get
        {
            return tus_id;
        }

        set
        {
            tus_id = value;
        }
    }

    public Setor Set_id
    {
        get
        {
            return set_id;
        }

        set
        {
            set_id = value;
        }
    }

    public Usuario Usu_idGerente
    {
        get
        {
            return usu_idGerente;
        }

        set
        {
            usu_idGerente = value;
        }
    }
}