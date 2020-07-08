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

        btnEditar.Visible = false;
        btnVisualizar.Visible = false;

        if (gvSetores.Rows.Count > 0)
        {
            gvSetores.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        if (!IsPostBack)
        {
            lblNome.Text = "<h6 class='m-0 font-weight-bold text-dark'>Colaborador: Selecione um colaborador</h6>";
            lblUsuario.Text = "<h7 class='m-0 font-weight-bold mt-5'>Procure um Setor que deseja, ou cadastre novos setores ao lado </ h7>";
        }

        CriaListaSetores();
    }

    void LimpaTudo()
    {
        txtNome.Text = "";
    }

    void CriaListaSetores()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("set_id", typeof(int)));
        dt.Columns.Add(new DataColumn("set_nome", typeof(string)));

        foreach (DataRow cds in SetorBD.procurarSetoresEmpresa(usuarioLogado.Emp_id).Tables[0].Rows)
        {
            dt.Rows.Add(Convert.ToInt32(cds["set_id"].ToString()), cds["set_nome"].ToString());
        }

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
        
    }
}