using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de UsuarioComprador
/// </summary>
public class UsuarioComprador
{
    private string nomeUsuario;
    private string nomeSetor;

    public string NomeUsuario
    {
        get
        {
            return nomeUsuario;
        }

        set
        {
            nomeUsuario = value;
        }
    }

    public string NomeSetor
    {
        get
        {
            return nomeSetor;
        }

        set
        {
            nomeSetor = value;
        }
    }
}