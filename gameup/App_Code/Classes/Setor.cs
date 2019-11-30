using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Setor
/// </summary>
public class Setor
{
    private int set_id;
    private string set_nome;
    private Empresa emp_id;

    public int Set_id
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

    public string Set_nome
    {
        get
        {
            return set_nome;
        }

        set
        {
            set_nome = value;
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