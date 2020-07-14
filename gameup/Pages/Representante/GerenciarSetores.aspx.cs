using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Representante_GerenciarSetores : System.Web.UI.Page
{
    private static Usuario usuarioLogado;

    protected void Page_Load(object sender, EventArgs e)
    {
        validarSessao();

        if (gvSetores.Rows.Count > 0)
        {
            gvSetores.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        if (!IsPostBack)
        {
            lblNome.Text = "<h6 class='m-0 font-weight-bold text-dark'>Colaborador: Selecione um colaborador</h6>";
            lblSetor.Text = "<h7 class='m-0 font-weight-bold mt-5'>Procure um Setor que deseja, ou cadastre novos setores ao lado </ h7>";
        }

        CriaListaSetores();
    }

    void LimpaTudo()
    {
        txtNome.Text = "";
    }

    DataTable CriaDataTableSetor()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("set_id", typeof(int)));
        dt.Columns.Add(new DataColumn("set_nome", typeof(string)));
        dt.Columns.Add(new DataColumn("set_status", typeof(string)));

        foreach (DataRow cds in SetorBD.procurarSetoresEmpresa(usuarioLogado.Emp_id).Tables[0].Rows)
        {
            dt.Rows.Add(Convert.ToInt32(cds["set_id"].ToString()), cds["set_nome"].ToString(), cds["set_status"].Equals(1) ? StatusSetorEnum.ATIVO.ToString() : StatusSetorEnum.INATIVO.ToString());
        }

        return dt;
    }

    DataTable CriaDataTableUmSetor( int set_id )
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("set_id", typeof(int)));
        dt.Columns.Add(new DataColumn("set_nome", typeof(string)));
        dt.Columns.Add(new DataColumn("set_status", typeof(string)));

        foreach (DataRow cds in SetorBD.procurarSetoresID(set_id).Tables[0].Rows)
        {
            dt.Rows.Add(Convert.ToInt32(cds["set_id"].ToString()), cds["set_nome"].ToString(), cds["set_status"].Equals(1) ? StatusSetorEnum.ATIVO.ToString() : StatusSetorEnum.INATIVO.ToString());
        }

        return dt;
    }

    void CriaListaSetores()
    {
        DataTable dt = CriaDataTableSetor();

        gvSetores.DataSource = dt;
        gvSetores.DataBind();        

        if (gvSetores.Rows.Count > 0)
        {
            gvSetores.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }

    string formatarNome(string nome)
    {
        string nomeFormatado = nome;

        if (nome.Count() > 8)
        {
            string[] nomes = nome.Split(' ');
            nomeFormatado = nomes[0] + " " + nomes[1].Substring(0, 1) + ".";
        }

        return nomeFormatado;
    }

    void validarSessao()
    {
        if (Session["USUARIO"] == null)
        {

            Response.Redirect("../Visitante/Login.aspx");

        }
        else
        {
            usuarioLogado = (Usuario)Session["USUARIO"];

            if (usuarioLogado.Tus_id != 3) // Representante
            {
                Response.Redirect("../Visitante/Login.aspx");
            }

        }
    }

    protected void btnCadastroSetor_Click(object sender, EventArgs e)
    {
        Setor setor = new Setor();

        setor.Set_nome = txtNome.Text;

        Empresa emp = new Empresa();
        emp.Emp_id = usuarioLogado.Emp_id;

        setor.Emp_id = emp;

        switch (SetorBD.InsertSetor(setor))
        {
            case true:
                msgModalCadastraSetor.Text = "<h5 class='text-success'> Um novo setor foi cadastrado com sucesso!</h5>";
                ltrTituloModal.Text = "Ótimo!";
                // Abre modal de sucesso
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalCadastraSetor').modal('show');</script>");
                LimpaTudo();

                CriaListaSetores();

                break;
            case false:
                msgModalCadastraSetor.Text = "<h5 class='text-warning'> Seu setor não pode ser cadastrado. Algum erro aconteceu. Verifique na lista abaixo se ele já não está cadastrado</h5>";
                ltrTituloModal.Text = "Poxa vida!";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalCadastraSetor').modal('show');</script>");
                break;
        }
    }

    protected void gvSetores_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            //Response.Write($"<script> alert({ e.CommandArgument}) </script>");

            lblSetor.Visible = false;
            rptSetor.Visible = true;

            lblNome.Text = $"<h6 class='m-0 font-weight-bold text-dark'>Colaborador: {SetorBD.procurarSetoresPorID(Convert.ToInt32(e.CommandArgument.ToString()))}</h6>";

            DataTable dt = CriaDataTableUmSetor(Convert.ToInt32(e.CommandArgument.ToString()));

            rptSetor.DataSource = dt;
            rptSetor.DataBind();

        }

        if (e.CommandName == "Inativar")
        {
            switch (SetorBD.InativaSetor(Convert.ToInt32(e.CommandArgument)))
            {
                case true:
                    lblUpdateSetText.Text = "<h5 class='text-success'>Update realizado com sucesso!</h5>";
                    lblUpdateSetTitle.Text = "Ótimo!";
                    // Abre modal de sucesso
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalUpdateSetor').modal('show');</script>");
                    break;
                case false:
                    lblUpdateSetText.Text = "<h5 class='text-danger'>O Setor não pode ser alterado, tente novamente mais tarde!!!</h5>";
                    lblUpdateSetTitle.Text = "Vish, Que pena!";
                    // Abre modal de sucesso
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalUpdateSetor').modal('show');</script>");
                    break;
            }

            CriaListaSetores();

        }
    }

    protected void gvSetores_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnk = (LinkButton)e.Row.FindControl("btnInativo");

            if (lnk != null)
            {
                switch (lnk.Text)
                {
                    case "ATIVO":
                        lnk.Text = "<i class='fa fa-check' data-toggle='tooltip' title='Ativo'></i>";
                        break;
                    case "INATIVO":
                        lnk.Text = "<i class='fa fa-ban' data-toggle='tooltip' title='Inativo'></i>";
                        break;
                }
            }
        }
    }
}