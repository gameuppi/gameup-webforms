using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de TipoItemsEnum
/// </summary>
public class TipoItemsEnum
{
    private int tip_id;
    private string tip_descricao;

    public int Tip_id
    {
        get
        {
            return tip_id;
        }

        set
        {
            tip_id = value;
        }
    }

    public string Tip_descricao
    {
        get
        {
            return tip_descricao;
        }

        set
        {
            tip_descricao = value;
        }
    }
}