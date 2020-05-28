using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de MensagemRedefinicaoSenha
/// </summary>
public class MensagemRedefinicaoSenha
{
    private string assunto;
    private string destinatario;
    private string mensagem;

    public string Assunto
    {
        get
        {
            return assunto;
        }

        set
        {
            assunto = value;
        }
    }

    public string Destinatario
    {
        get
        {
            return destinatario;
        }

        set
        {
            destinatario = value;
        }
    }

    public string Mensagem
    {
        get
        {
            return mensagem;
        }

        set
        {
            mensagem = value;
        }
    }
}