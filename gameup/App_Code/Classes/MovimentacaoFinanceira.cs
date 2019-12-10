using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de MovimentacaoFinanceira
/// </summary>
public class MovimentacaoFinanceira
{
    private int mfi_id;
    private double mfi_valorProd;
    private int mfi_qtdProd;
    private DateTime mfi_dHCompra;
    private Produto pro_id;
    private Empresa emp_id;
    private Usuario usu_id;

    public int Mfi_id
    {
        get
        {
            return mfi_id;
        }

        set
        {
            mfi_id = value;
        }
    }

    public double Mfi_valorProd
    {
        get
        {
            return mfi_valorProd;
        }

        set
        {
            mfi_valorProd = value;
        }
    }

    public int Mfi_qtdProd
    {
        get
        {
            return mfi_qtdProd;
        }

        set
        {
            mfi_qtdProd = value;
        }
    }

    public DateTime Mfi_dHCompra
    {
        get
        {
            return mfi_dHCompra;
        }

        set
        {
            mfi_dHCompra = value;
        }
    }

    public Produto Pro_id
    {
        get
        {
            return pro_id;
        }

        set
        {
            pro_id = value;
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

    public Usuario Usu_id
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
}