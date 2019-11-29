using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Usuario
/// </summary>
public class Usuario
{
    private int id;
    private string nome;
    private int qtdPontos;

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
}