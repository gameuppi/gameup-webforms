using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Gerente_PlacarLideres : System.Web.UI.Page
{
    private static Usuario usuarioLogado;
    protected void Page_Load(object sender, EventArgs e)
    {
        validarSessao();

        if (gvPlacarLideres.Rows.Count > 0)
        {
            gvPlacarLideres.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        DataSet listaDeUsuariosDs = PlacarLideresBD.procurarUsuariosPlacarGeral(usuarioLogado.Emp_id);
        List<Usuario> listaDeUsuarios = new List<Usuario>();
        Usuario usuario = new Usuario();

        foreach (DataRow usu in listaDeUsuariosDs.Tables[0].Rows)
        {
            usuario = new Usuario();
            usuario.Usu_nome = usu["usu_nome"].ToString();
            usuario.Usu_qtdPontos = Convert.ToInt32(usu["usu_qtdpontos"].ToString());
            listaDeUsuarios.Add(usuario);
        }

        int pos = 1;

        foreach (Usuario usu in listaDeUsuarios)
        {
            // Preenche top 3
            if (pos == 1)
            {
                lbl1Posicao.Text = formatarNome(usu.Usu_nome);
                lblPontos1Posicao.Text = usu.Usu_qtdPontos.ToString();
            }
            else if (pos == 2)
            {
                lbl2Posicao.Text = formatarNome(usu.Usu_nome);
                lblPontos2Posicao.Text = usu.Usu_qtdPontos.ToString();
            }
            else if (pos == 3)
            {
                lbl3Posicao.Text = formatarNome(usu.Usu_nome);
                lblPontos3Posicao.Text = usu.Usu_qtdPontos.ToString();
            }
            pos++;
        }

        CriaGvPlacarLideresGeral();


    }

    void CriaGvPlacarLideresGeral()
    {

        ltlPlacar.Text = "<h5 class='m-0 font-weight-bold text-dark col-md-6'>Placar geral</h5>";

        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("posicao", typeof(int)));
        dt.Columns.Add(new DataColumn("usu_nome", typeof(string)));
        dt.Columns.Add(new DataColumn("usu_qtdPontos", typeof(int)));

        int i = 1;

        foreach (DataRow cds in PlacarLideresBD.procurarUsuariosPlacarGeral(usuarioLogado.Emp_id).Tables[0].Rows)
        {
            dt.Rows.Add(i++, cds["usu_nome"].ToString(), Convert.ToInt32(cds["usu_qtdPontos"].ToString()));
        }

        gvPlacarLideres.DataSource = dt;
        gvPlacarLideres.DataBind();

        if (gvPlacarLideres.Rows.Count > 0)
        {
            gvPlacarLideres.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    void CriaGvPlacarLideresMensal()
    {

        ltlPlacar.Text = "<h5 class='m-0 font-weight-bold text-dark col-md-6'>Placar Mensal</h5>";

        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("posicao", typeof(int)));
        dt.Columns.Add(new DataColumn("usu_nome", typeof(string)));
        dt.Columns.Add(new DataColumn("usu_qtdPontos", typeof(int)));

        int i = 1;

        foreach (DataRow cds in PlacarLideresBD.procurarUsuariosPlacarMensal(usuarioLogado.Emp_id).Tables[0].Rows)
        {
            dt.Rows.Add(i++, cds["usu_nome"].ToString(), Convert.ToInt32(cds["usu_qtdPontos"].ToString()));
        }

        gvPlacarLideres.DataSource = dt;
        gvPlacarLideres.DataBind();

        if (gvPlacarLideres.Rows.Count > 0)
        {
            gvPlacarLideres.HeaderRow.TableSection = TableRowSection.TableHeader;
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

            if (usuarioLogado.Tus_id != 2) // Gerente
            {
                Response.Redirect("../Visitante/Login.aspx");
            }
        }
    }

    protected void btnAlteraGv_Click(object sender, EventArgs e)
    {
        if (ddlPlacar.SelectedValue.Equals("1"))
        {
            CriaGvPlacarLideresGeral();
        }
        else if (ddlPlacar.SelectedValue.Equals("2"))
        {
            CriaGvPlacarLideresMensal();
        }
    }
}