using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Empresa
/// </summary>
public class Empresa
{
    private int emp_id;
    private string emp_cnpj;
    private string emp_nome;

    public int Emp_id
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

    public string Emp_cnpj
    {
        get
        {
            return emp_cnpj;
        }

        set
        {
            emp_cnpj = value;
        }
    }

    public string Emp_nome
    {
        get
        {
            return emp_nome;
        }

        set
        {
            emp_nome = value;
        }
    }
}