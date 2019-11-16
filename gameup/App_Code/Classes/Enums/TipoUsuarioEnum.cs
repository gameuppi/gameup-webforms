using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de TipoUsuarioEnum
/// </summary>
public class TipoUsuarioEnum
{
    //1 - Colaborador, 2 - Gerente, 3 - Empresa, 4 - Administrador, 5 - Moderador

    private int tus_id;
    private string tus_descricao;

    public int Tus_id
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

    public string Tus_descricao
    {
        get
        {
            return tus_descricao;
        }

        set
        {
            tus_descricao = value;
        }
    }
}