using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Representante_GerenciarColaboradores : System.Web.UI.Page
{
    private static Usuario usuarioLogado;

    protected void Page_Load(object sender, EventArgs e)
    {
        validarSessao();

        if (gvColaboradores.Rows.Count > 0)
        {
            gvColaboradores.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        if (!IsPostBack)
        {
            lblNome.Text = "<h6 class='m-0 font-weight-bold text-dark'>Colaborador: Selecione um colaborador</h6>";
            lblUsuario.Text = "<h7 class='m-0 font-weight-bold mt-5' style='align: center'>Procure o colaborador que deseja, ou cadastre novos competidores ao lado " +
                              "para ingressar nessa aventura!!!</ h7>";
            rptColaborador.Visible = false;
        }

        carregaSetores(usuarioLogado.Emp_id);
        CriaListaColaboradores();
    }

    void LimpaTudo()
    {
        ddlSetor.Items.Clear();
        txtEmail.Text = "";
        txtNome.Text = "";
        cbGerente.Checked = false;
    }

    void CriaListaColaboradores()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("usu_id", typeof(int)));
        dt.Columns.Add(new DataColumn("usu_nome", typeof(string)));
        dt.Columns.Add(new DataColumn("usu_email", typeof(string)));
        dt.Columns.Add(new DataColumn("tus_id", typeof(string)));
        dt.Columns.Add(new DataColumn("set_id", typeof(string)));
        dt.Columns.Add(new DataColumn("usu_statususuario", typeof(string)));

        foreach (DataRow cds in UsuarioBD.procurarUsuarioPorEmpresa(usuarioLogado.Emp_id).Tables[0].Rows)
        {
            if (cds["usu_id"].ToString() != null)
            {
                if (Convert.ToInt32(cds["tus_id"].ToString()) == 1)
                {
                    dt.Rows.Add(Convert.ToInt32(cds["usu_id"].ToString()), cds["usu_nome"].ToString(), cds["usu_email"].ToString(), TipoUsuarioEnum.COLABORADOR.ToString(), SetorBD.procurarSetoresPorID(Convert.ToInt32(cds["set_id"].ToString())), cds["usu_statususuario"].Equals(3) ? StatusUsuarioEnum.CADASTRADO.ToString() : cds["usu_statususuario"].Equals(1) ? StatusUsuarioEnum.ATIVO.ToString() : StatusUsuarioEnum.INATIVO.ToString());
                }
                else if (Convert.ToInt32(cds["tus_id"].ToString()) == 2)
                {
                    dt.Rows.Add(Convert.ToInt32(cds["usu_id"].ToString()), cds["usu_nome"].ToString(), cds["usu_email"].ToString(), TipoUsuarioEnum.GERENTE.ToString(), SetorBD.procurarSetoresPorID(Convert.ToInt32(cds["set_id"].ToString())), cds["usu_statususuario"].Equals(3) ? StatusUsuarioEnum.CADASTRADO.ToString() : cds["usu_statususuario"].Equals(1) ? StatusUsuarioEnum.ATIVO.ToString() : StatusUsuarioEnum.INATIVO.ToString());
                }
                else if (Convert.ToInt32(cds["tus_id"].ToString()) == 3)
                {
                    dt.Rows.Add(Convert.ToInt32(cds["usu_id"].ToString()), cds["usu_nome"].ToString(), cds["usu_email"].ToString(), TipoUsuarioEnum.REPRESENTANTE.ToString(), SetorBD.procurarSetoresPorID(Convert.ToInt32(cds["set_id"].ToString())), cds["usu_statususuario"].Equals(3) ? StatusUsuarioEnum.CADASTRADO.ToString() : cds["usu_statususuario"].Equals(1) ? StatusUsuarioEnum.ATIVO.ToString() : StatusUsuarioEnum.INATIVO.ToString());
                }
            }
        }

        gvColaboradores.DataSource = dt;
        gvColaboradores.DataBind();

        if (gvColaboradores.Rows.Count > 0)
        {
            gvColaboradores.HeaderRow.TableSection = TableRowSection.TableHeader;
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

    void carregaSetores(int emp_id)
    {
        ddlSetor.DataSource = SetorBD.procurarSetoresEmpresa(emp_id);
        ddlSetor.DataTextField = "set_nome";
        ddlSetor.DataValueField = "set_id";
        ddlSetor.DataBind();
    }



    protected void btnCadastroColaborador_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();

        usu.Usu_nome = txtNome.Text;
        usu.Usu_email = txtEmail.Text;
        usu.Set_id = Convert.ToInt32(ddlSetor.SelectedValue);
        usu.Emp_id = usuarioLogado.Emp_id;
        if (!cbGerente.Checked)
        {
            usu.Tus_id = Convert.ToInt32(TipoUsuarioEnum.COLABORADOR);
        }
        else
        {
            usu.Tus_id = Convert.ToInt32(TipoUsuarioEnum.GERENTE);
        }

        switch (UsuarioBD.InsertColaborador(usu))
        {
            case true:
                try
                {
                    string hash = gerarHash(DateTime.Now.AddDays(1).ToString() + "&" + usu.Usu_email);

                    EnviarEmail(usu.Usu_email, usu.Usu_nome, hash);

                }
                catch (Exception)
                {
                    msgModalCadastraColaborador.Text = "<h5 class='text-danger'> Falha ao cadastrar colaborador...</h5>";
                    ltrTituloModal.Text = "Vish, que pena!";
                    // Abre modal de erro
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalCadastraColaborador').modal('show');</script>");
                }
                msgModalCadastraColaborador.Text = "<h5 class='text-success'> Um novo colaborador foi cadastrado com sucesso!</h5>";
                ltrTituloModal.Text = "Ótimo!";
                // Abre modal de sucesso
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalCadastraColaborador').modal('show');</script>");
                LimpaTudo();

                break;
            case false:
                msgModalCadastraColaborador.Text = "<h5 class='text-warning'> Seu colaborador não pode ser cadastrado. Algum erro aconteceu. Verifique na lista abaixo se ele já não está cadastrado</h5>";
                ltrTituloModal.Text = "Poxa vida!";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalCadastraColaborador').modal('show');</script>");
                break;
        }
    }

    protected string gerarHash(string texto)
    {
        byte[] stringBase64 = new byte[texto.Length];
        stringBase64 = Encoding.UTF8.GetBytes(texto);
        string hash = Convert.ToBase64String(stringBase64);

        return hash;
    }

    [WebMethod]
    public static string ExibirDetalhesColaborador(string email)
    {
        return email;
    }



    public bool EnviarEmail(string destinatario, string nome, string codigo)
    {
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("gameup.enterprise@gmail.com", "Equipe GameUP");

            mailMessage.CC.Add(destinatario);
            mailMessage.Subject = "Seja muito bem vindo(a)!";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "Olá, <b>" + nome + "</b> <br />" + "<a href='http://localhost:62235/Pages/Visitante/CompletarCadastro.aspx?hash=" + codigo + "'>Clique aqui para confirmar seu cadastro.</a>";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("gameup.enterprise@gmail.com", "B@n@n@123");

            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);

            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvColaboradores_SelectedIndexChanged(object sender, EventArgs e)
    {
        Console.WriteLine("sfsd");
    }

    protected void gvColaboradores_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            //Response.Write($"<script> alert({ e.CommandArgument}) </script>");

            lblUsuario.Visible = false;
            rptColaborador.Visible = true;

            DataSet dsColaborador = UsuarioBD.procurarUsuarioPorId(Convert.ToInt32(e.CommandArgument.ToString()));

            lblNome.Text = $"<h6 class='m-0 font-weight-bold text-dark'>Colaborador: {formatarNome(dsColaborador.Tables[0].Rows[0]["usu_nome"].ToString())}</h6>";

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("usu_id", typeof(int)));
            dt.Columns.Add(new DataColumn("usu_nome", typeof(string)));
            dt.Columns.Add(new DataColumn("usu_apelido", typeof(string)));
            dt.Columns.Add(new DataColumn("set_id", typeof(string)));
            dt.Columns.Add(new DataColumn("tus_id", typeof(string)));
            dt.Columns.Add(new DataColumn("usu_email", typeof(string)));
            dt.Columns.Add(new DataColumn("usu_qtdPontos", typeof(int)));
            dt.Columns.Add(new DataColumn("usu_qtdXp", typeof(int)));
            dt.Columns.Add(new DataColumn("usu_statususuario", typeof(string)));
            dt.Columns.Add(new DataColumn("niv_id", typeof(int)));

            foreach (DataRow cds in UsuarioBD.procurarUsuarioPorId(Convert.ToInt32(e.CommandArgument.ToString())).Tables[0].Rows)
            {
                if (cds["usu_id"].ToString() != null)
                {
                    if (Convert.ToInt32(cds["tus_id"].ToString()) == 1)
                    {
                        dt.Rows.Add(Convert.ToInt32(cds["usu_id"].ToString()), cds["usu_nome"].ToString(), cds["usu_apelido"].ToString(), SetorBD.procurarSetoresPorID(Convert.ToInt32(cds["set_id"].ToString())), TipoUsuarioEnum.COLABORADOR.ToString(), cds["usu_email"].ToString(), Convert.ToInt32(cds["usu_qtdPontos"].ToString()), Convert.ToInt32(cds["usu_qtdXp"].ToString()), cds["usu_statususuario"].Equals(3) ? StatusUsuarioEnum.CADASTRADO.ToString() : cds["usu_statususuario"].Equals(1) ? StatusUsuarioEnum.ATIVO.ToString() : StatusUsuarioEnum.INATIVO.ToString(), Convert.ToInt32(cds["niv_id"].ToString()));
                    }
                    else if (Convert.ToInt32(cds["tus_id"].ToString()) == 2)
                    {
                        dt.Rows.Add(Convert.ToInt32(cds["usu_id"].ToString()), cds["usu_nome"].ToString(), cds["usu_apelido"].ToString(), SetorBD.procurarSetoresPorID(Convert.ToInt32(cds["set_id"].ToString())), TipoUsuarioEnum.GERENTE.ToString(), cds["usu_email"].ToString(), Convert.ToInt32(cds["usu_qtdPontos"].ToString()), Convert.ToInt32(cds["usu_qtdXp"].ToString()), cds["usu_statususuario"].Equals(3) ? StatusUsuarioEnum.CADASTRADO.ToString() : cds["usu_statususuario"].Equals(1) ? StatusUsuarioEnum.ATIVO.ToString() : StatusUsuarioEnum.INATIVO.ToString(), Convert.ToInt32(cds["niv_id"].ToString()));
                    }
                    else if (Convert.ToInt32(cds["tus_id"].ToString()) == 3)
                    {
                        dt.Rows.Add(Convert.ToInt32(cds["usu_id"].ToString()), cds["usu_nome"].ToString(), cds["usu_apelido"].ToString(), SetorBD.procurarSetoresPorID(Convert.ToInt32(cds["set_id"].ToString())), TipoUsuarioEnum.REPRESENTANTE.ToString(), cds["usu_email"].ToString(), Convert.ToInt32(cds["usu_qtdPontos"].ToString()), Convert.ToInt32(cds["usu_qtdXp"].ToString()), cds["usu_statususuario"].Equals(3) ? StatusUsuarioEnum.CADASTRADO.ToString() : cds["usu_statususuario"].Equals(1) ? StatusUsuarioEnum.ATIVO.ToString() : StatusUsuarioEnum.INATIVO.ToString(), Convert.ToInt32(cds["niv_id"].ToString()));
                    }
                }
            }

            rptColaborador.DataSource = dt;
            rptColaborador.DataBind();

        }

        if (e.CommandName == "Inativar")
        {
            switch (UsuarioBD.UpdateInativo(Convert.ToInt32(e.CommandArgument)))
            {
                case true:
                    Response.Write("<script> alert('Update realizado com sucesso!!!')</script>");
                    break;
                case false:
                    Response.Write("<script> alert('Ocorreu algum erro, Tente novamente mais tarde')</script>");
                    break;
            }

            CriaListaColaboradores();
        }


    }

    protected void rptColaborador_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edite")
        {
            DataSet dsColaborador = UsuarioBD.procurarUsuarioPorId(Convert.ToInt32(e.CommandArgument.ToString()));
            Session["USU_ID_EDITAR"] = e.CommandArgument.ToString();

            if (dsColaborador.Tables[0].Rows[0]["tus_id"].Equals("2"))
            {
                cbGerenteModal.Checked = true;
            }

            if (dsColaborador.Tables[0].Rows[0]["usu_statususuario"].Equals("2"))
            {
                cbInativoModal.Checked = true;
            }
                       
            lblTitulo.Text = $"<h6 class='m-0 font-weight-bold text-dark'>Colaborador: {formatarNome(dsColaborador.Tables[0].Rows[0]["usu_nome"].ToString())}</h6>"; ;
            // Abre modal de sucesso
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalEditaColaborador').modal('show');</script>");
        }
    }



    protected void btnSalve_Click(object sender, EventArgs e)
    {
        int usu_id_editar = Convert.ToInt32(Session["USU_ID_EDITAR"].ToString());

        DataSet dsColab = UsuarioBD.procurarUsuarioPorId(usu_id_editar);

        if (cbGerenteModal.Checked)
        {
            switch (UsuarioBD.UpdateGerente(usu_id_editar))
            {
                case true:
                    Response.Write("<script> alert('Update realizado com sucesso!!!')</script>");
                    break;
                case false:
                    Response.Write("<script> alert('Ocorreu algum erro, Tente novamente mais tarde')</script>");
                    break;
            }
        }
        else
        {
            if (dsColab.Tables[0].Rows[0]["tus_id"].Equals("2"))
            {
                switch (UsuarioBD.UpdateGerente2(usu_id_editar))
                {
                    case true:
                        Response.Write("<script> alert('Update realizado com sucesso!!!')</script>");
                        break;
                    case false:
                        Response.Write("<script> alert('Ocorreu algum erro, Tente novamente mais tarde')</script>");
                        break;
                }

            }
        }

        if (cbInativoModal.Checked)
        {
            
        }
        else
        {
          
        }

    }

    protected void gvColaboradores_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ( e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnk = (LinkButton) e.Row.FindControl("btnInativo");

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
                    case "CADASTRADO":
                        lnk.Text = "<i class='fa fa-id-card' data-toggle='tooltip' title='Cadastrado'></i>";
                        lnk.Enabled = false;
                        break;
                }
            }
        }
    }
}