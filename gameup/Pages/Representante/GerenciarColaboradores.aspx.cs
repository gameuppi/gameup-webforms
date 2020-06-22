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

        btnEditar.Visible = false;
        btnVisualizar.Visible = false;

        if (!IsPostBack)
        {
            lblNome.Text = "<h6 class='m-0 font-weight-bold text-dark'>Colaborador: Selecione um colaborador</h6>";
            lblUsuario.Text = "<h7 class='m-0 font-weight-bold mt-5'>Procure o colaborador que deseja, ou cadastre novos competidores ao lado " +
                              "para ingressar nessa aventura!!!</ h7>";
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
                    dt.Rows.Add(Convert.ToInt32(cds["usu_id"].ToString()), cds["usu_nome"].ToString(), cds["usu_email"].ToString(), TipoUsuarioEnum.COLABORADOR.ToString(), SetorBD.procurarSetoresPorID(Convert.ToInt32(cds["set_id"].ToString())), StatusUsuarioEnum.CADASTRADO.ToString());
                }
                else if (Convert.ToInt32(cds["tus_id"].ToString()) == 2)
                {
                    dt.Rows.Add(Convert.ToInt32(cds["usu_id"].ToString()), cds["usu_nome"].ToString(), cds["usu_email"].ToString(), TipoUsuarioEnum.GERENTE.ToString(), SetorBD.procurarSetoresPorID(Convert.ToInt32(cds["set_id"].ToString())), StatusUsuarioEnum.CADASTRADO.ToString());
                }
                else if (Convert.ToInt32(cds["tus_id"].ToString()) == 3)
                {
                    dt.Rows.Add(Convert.ToInt32(cds["usu_id"].ToString()), cds["usu_nome"].ToString(), cds["usu_email"].ToString(), TipoUsuarioEnum.REPRESENTANTE.ToString(), SetorBD.procurarSetoresPorID(Convert.ToInt32(cds["set_id"].ToString())), StatusUsuarioEnum.CADASTRADO.ToString());
                }
            }
        }

        gvColaboradores.DataSource = dt;
        gvColaboradores.DataBind();

        //DataSet colaboradoresDS = UsuarioBD.procurarUsuarioPorEmpresa(usuarioLogado.Emp_id);
        //Usuario usuario;
        //List<Usuario> listaDeColaboradores = new List<Usuario>();

        //foreach (DataRow u in colaboradoresDS.Tables[0].Rows)
        //{
        //    usuario = new Usuario();
        //    usuario.Usu_id = Convert.ToInt32(u["usu_id"].ToString());
        //    usuario.Usu_nome = u["usu_nome"].ToString();
        //    usuario.Tus_id = Convert.ToInt32(u["tus_id"].ToString());
        //    usuario.Set_id = Convert.ToInt32(u["set_id"].ToString());
        //    //usuario.Usu_statusUsuario = Convert.ToInt32(u["usu_statususuario"].ToString());

        //    listaDeColaboradores.Add(usuario);
        //}

        //ListarColaboradores(listaDeColaboradores);
    }

    void ListarColaboradores(List<Usuario> listaDeColaboradores)
    {
        //TableRow tr;
        //TableCell tcUsuario;
        //TableCell tcCargo;
        //TableCell tcSetor;
        //TableCell tcStatus;

        //foreach (Usuario usuario in listaDeColaboradores)
        //{
        //    tr = new TableRow();
        //    tcUsuario = new TableCell();
        //    tcCargo = new TableCell();
        //    tcSetor = new TableCell();
        //    tcStatus = new TableCell();

        //    tcUsuario.Text = formatarNome(usuario.Usu_nome);

        //    if (usuario.Tus_id == 1)
        //    {
        //        tcCargo.Text = TipoUsuarioEnum.COLABORADOR.ToString();
        //    }
        //    else if (usuario.Tus_id == 2)
        //    {
        //        tcCargo.Text = TipoUsuarioEnum.GERENTE.ToString();
        //    }
        //    else if (usuario.Tus_id == 3)
        //    {
        //        tcCargo.Text = TipoUsuarioEnum.REPRESENTANTE.ToString();
        //    }

        //    tcSetor.Text = SetorBD.procurarSetoresPorID(usuario.Set_id);
        //    tcStatus.Text = StatusUsuarioEnum.CADASTRADO.ToString();

        //    tr.Controls.Add(tcUsuario);
        //    tr.Controls.Add(tcCargo);
        //    tr.Controls.Add(tcSetor);
        //    tr.Controls.Add(tcStatus);

        //    tblColaboradores.Controls.Add(tr);
        //}
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
                    string hash = gerarHash(DateTime.Now.AddDays(1).ToString()+ "&" + usu.Usu_email);

                    EnviarEmail(usu.Usu_email, usu.Usu_nome, hash);

                } catch(Exception)
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
            mailMessage.Body = "Olá, <b>" + nome + "</b> <br />" + "<a href='http://localhost:62235/Pages/Visitante/CompletarCadastro.aspx?hash=" + codigo +"'>Clique aqui para confirmar seu cadastro.</a>";

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
}