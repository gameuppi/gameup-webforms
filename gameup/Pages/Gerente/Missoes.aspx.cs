using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Gerente_Missoes : System.Web.UI.Page
{
    private static Usuario usuarioLogado;

    protected void Page_Load(object sender, EventArgs e)
    {
        validarSessao();

        if (!IsPostBack)
        {
        }
        carregarMissoes();
    }

    public void carregarMissoes()
    {
        pnlMissoesVisualizar.Controls.Clear();

        //List<Missao> listaDeMissoes = criarListaObjMissao(MissaoBD.procurarMissao(usuarioLogado.Emp_id));
        List<MissaoUsuario> listaDeMissoesUsuario = criarListaObjMissaoUsuario(MissaoBD.procurarTodasMissaoUsuarioColaborador(usuarioLogado.Usu_id));

        carregarTodasAsMissoesUsuario(listaDeMissoesUsuario);
    }

    public void carregarMissoesPorStatus(string status)
    {
        pnlMissoesVisualizar.Controls.Clear();

        //List<Missao> listaDeMissoes = criarListaObjMissao(MissaoBD.procurarMissao(usuarioLogado.Emp_id));
        DataSet missoesConcluidas = MissaoBD.procurarTodasMissaoUsuarioColaboradorPorStatus(usuarioLogado.Usu_id, status);

        List<MissaoUsuario> listaDeMissoesUsuario = criarListaObjMissaoUsuario(missoesConcluidas);

        carregarTodasAsMissoesUsuario(listaDeMissoesUsuario);
    }

    public void carregarTodasAsMissoesUsuario(List<MissaoUsuario> listaMissoesUsuario)
    {
        string resp = "";

        foreach (MissaoUsuario missao in listaMissoesUsuario)
        {
            DataSet idUsuario = UsuarioBD.procurarUsuarioPorId(missao.Usuario.Usu_id);
            Usuario usuario = new Usuario();

            foreach (DataRow id in idUsuario.Tables[0].Rows)
            {
                usuario.Usu_id = Convert.ToInt32(id["usu_id"].ToString());
                usuario.Usu_nome = id["usu_nome"].ToString();
            }

            if (missao.Status.Equals(StatusMissaoEnum.AG_VALIDACAO))
            {
                Literal topo = new Literal();
                Literal rodape = new Literal();
                resp = "";

                resp += " <div class='col-12 col-md-4 mb-4'> ";
                resp += "     <div class='card border-left-warning shadow h-100 py-2'> ";
                resp += "         <div class='card-body'> ";
                resp += "             <div class='row no-gutters align-items-center'> ";
                resp += "                 <div class='col mr-2'> ";
                resp += "                     <div class='text-sm font-weight-bold text-warning text-uppercase mb-1'> " + missao.Missao.Nome + "</div> ";
                resp += "                     <div class='h6 mb-0 text-gray-800'> " + missao.Missao.Descricao + "</div> ";
                resp += "                     <div class='mt-4'> ";
                resp += "                         <i class='fas fa-user fa-2x text-warning'></i> ";
                resp += $"                         &nbsp; {missao.Usuario.Usu_nome} ";
                resp += "                         <br /> ";
                resp += "                         <br /> ";

                topo.Text = resp;
                resp = "";

                LinkButton btnVerDetalhes = new LinkButton();
                btnVerDetalhes.Text = "Detalhes";
                btnVerDetalhes.Click += (sender, e) => { this.verDetalhesMissao(sender, e, missao.Id); };
                btnVerDetalhes.ID = (missao.Id + 20).ToString();
                btnVerDetalhes.CssClass = "btn btn-block btn-warning";


                resp += "                     </div> ";
                resp += "                 </div> ";
                resp += "                 <div class='col-auto'> ";
                resp += "                     <i class='fas fa-clock fa-2x text-warning'></i> ";
                resp += "                 </div> ";
                resp += "             </div> ";
                resp += "         </div> ";
                resp += "     </div> ";
                resp += " </div> ";

                rodape.Text = resp;

                pnlMissoesEnviadas.Controls.Add(topo);
                pnlMissoesEnviadas.Controls.Add(btnVerDetalhes);
                pnlMissoesEnviadas.Controls.Add(rodape);

            }
            else if (missao.Status.Equals(StatusMissaoEnum.EM_ANDAMENTO))
            {
                Literal topo = new Literal();
                Literal meio = new Literal();
                Literal rodape = new Literal();
                resp = "";

                resp += " <div class='col-12 col-md-4 mb-4'> ";
                resp += "     <div class='card border-left-info shadow h-100 py-2'> ";
                resp += "         <div class='card-body'> ";
                resp += "             <div class='row no-gutters align-items-center'> ";
                resp += "                 <div class='col mr-2'> ";
                resp += "                     <div class='text-sm font-weight-bold text-info text-uppercase mb-1'> " + missao.Missao.Nome + "</div> ";
                resp += "                     <div class='h6 mb-0 text-gray-800'> " + missao.Missao.Descricao + "</div> ";
                resp += "                     <div class='mt-4'> ";
                resp += "                         <i class='fas fa-user fa-2x text-info'></i> ";
                resp += $"                         &nbsp; {missao.Usuario.Usu_nome} ";
                resp += "                         <br /> ";
                resp += "                         <br /> ";

                topo.Text = resp;
                resp = "";

                LinkButton btnVerDetalhes = new LinkButton();
                btnVerDetalhes.Text = "Detalhes";
                btnVerDetalhes.Click += (sender, e) => { this.verDetalhesMissao(sender, e, missao.Id); };
                btnVerDetalhes.ID = (missao.Id + 20).ToString();
                btnVerDetalhes.CssClass = "btn btn-block btn-info";

                resp += "                     </div> ";
                resp += "                 </div> ";
                resp += "                 <div class='col-auto'> ";

                meio.Text = resp;
                resp = "";

                LinkButton btnValidar = new LinkButton();
                btnValidar.Click += (sender, e) => { this.concluirMissao(sender, e, missao.Id); };
                btnValidar.ID = (missao.Id + 50).ToString();
                btnValidar.Text = "<i class='fas fa-check fa-2x text-gray-500 icon-change'></i>";


                //resp += "                     <a href='#'><i class='fas fa-check fa-2x text-gray-500 icon-change'></i></a> ";
                resp += "                 </div> ";
                resp += "             </div> ";
                resp += "         </div> ";
                resp += "     </div> ";
                resp += " </div> ";

                rodape.Text = resp;

                pnlMissoesVisualizar.Controls.Add(topo);
                pnlMissoesVisualizar.Controls.Add(btnVerDetalhes);
                pnlMissoesVisualizar.Controls.Add(meio);
                pnlMissoesVisualizar.Controls.Add(btnValidar);
                pnlMissoesVisualizar.Controls.Add(rodape);

                if (resp.Equals(""))
                {
                    resp = "<div class='col-12 col-md-4 mb-4'> <h5>Não há missões para visualizar...</h5> </div>";
                }

            }
            else if (missao.Status.Equals(StatusMissaoEnum.VALIDADA))
            {
                Literal topo = new Literal();
                Literal meio = new Literal();
                Literal rodape = new Literal();
                resp = "";

                resp += " <div class='col-12 col-md-4 mb-4'> ";
                resp += "     <div class='card border-left-success shadow h-100 py-2'> ";
                resp += "         <div class='card-body'> ";
                resp += "             <div class='row no-gutters align-items-center'> ";
                resp += "                 <div class='col mr-2'> ";
                resp += "                     <div class='text-sm font-weight-bold text-success text-uppercase mb-1'> " + missao.Missao.Nome + "</div> ";
                resp += "                     <div class='h6 mb-0 text-gray-800'> " + missao.Missao.Descricao + "</div> ";
                resp += "                     <div class='mt-4'> ";
                resp += "                         <i class='fas fa-user fa-2x text-success'></i> ";
                resp += $"                         &nbsp; {missao.Usuario.Usu_nome} ";
                resp += "                         <br /> ";
                resp += "                         <br /> ";

                topo.Text = resp;
                resp = "";

                LinkButton btnVerDetalhes = new LinkButton();
                btnVerDetalhes.Text = "Detalhes";
                btnVerDetalhes.Click += (sender, e) => { this.verDetalhesMissao(sender, e, missao.Id); };
                btnVerDetalhes.ID = missao.Id.ToString();
                btnVerDetalhes.CssClass = "btn btn-block btn-success";

                resp += "                     </div> ";
                resp += "                 </div> ";
                resp += "                 <div class='col-auto'> ";
                resp += "                     <i class='fas fa-check fa-2x text-success'></i> ";
                resp += "                 </div> ";
                resp += "             </div> ";
                resp += "         </div> ";
                resp += "     </div> ";
                resp += " </div> ";

                rodape.Text = resp;

                pnlMissoesVisualizar.Controls.Add(topo);
                pnlMissoesVisualizar.Controls.Add(btnVerDetalhes);
                pnlMissoesVisualizar.Controls.Add(rodape);
            }
        }

        if (resp.Equals(""))
        {
            resp = "<div class='col-12 col-md-4 mb-4'> <h5>Não há missões para visualizar...</h5> </div>";
        }

    }

    void concluirMissao(object sender, EventArgs e, int mus_id)
    {
        hfIdMissao.Value = mus_id.ToString();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalConcluirMissao').modal('show');</script>");
    }

    public MissaoUsuario procurarDetalhesMissaoPorId(int idMissao)
    {
        DataSet missaoDs = MissaoBD.procurarDetalhesMissaoPoId(idMissao);
        MissaoUsuario missaoUsuario = criarObjMissaoUsuario(missaoDs);

        return missaoUsuario;
    }

    public MissaoUsuario criarObjMissaoUsuario(DataSet missao)
    {
        MissaoUsuario missaoUsuario = new MissaoUsuario();
        missaoUsuario.Id = Convert.ToInt32(missao.Tables[0].Rows[0]["mus_id"]);
        missaoUsuario.Usuario = procurarUsuarioPorId(Convert.ToInt32(missao.Tables[0].Rows[0]["usu_id"]));
        missaoUsuario.Missao = procurarMissaoPorId(Convert.ToInt32(missao.Tables[0].Rows[0]["mis_id"]));
        missaoUsuario.DtConclusao = Convert.ToDateTime(missao.Tables[0].Rows[0]["mus_dt_conclusao"]);
        missaoUsuario.Arquivo = !missao.Tables[0].Rows[0]["mus_arquivo"].ToString().Equals("") ? missao.Tables[0].Rows[0]["mus_arquivo"].ToString() : null;

        return missaoUsuario;
    }


    void verDetalhesMissao(object sender, EventArgs e, int mus_id)
    {
        MissaoUsuario missao = procurarDetalhesMissaoPorId(mus_id);

        ltrDetalhesMoedas.Text = missao.Missao.QtdMoedas.ToString();
        ltrDetalhesEstrelas.Text = missao.Missao.QtdExp.ToString();
        ltrDetalhesMeteoros.Text = missao.Missao.QtdPontos.ToString();
        ltrDetalhesDescricao.Text = missao.Missao.Descricao;
        lblIdMissaoUsuario.Text = missao.Id.ToString();

        if (missao.DtConclusao != Convert.ToDateTime("01/01/0001"))
        {
            ltrDataConclusao.Text = missao.DtConclusao.ToString();
        }
        else
        {
            ltrDataConclusao.Text = " Ainda não foi concluída";
        }

        DataSet caminhoArquivoDs = ArquivoBD.BuscarNomeDoArquivoPorIdDaMissaoUsuario(mus_id);
        string caminhoArquivo = caminhoArquivoDs.Tables[0].Rows[0]["mus_arquivo"].ToString();

        if (!caminhoArquivo.Equals(""))
        {
            lblTextoAnexo.Text = "";

            string[] caminhoSeparado = caminhoArquivo.Split('\\');
            string nomeArquivo = caminhoSeparado[caminhoSeparado.Length - 1];

            //LinkButton btnBaixarAnexo = new LinkButton();
            //btnBaixarAnexo.Click += new EventHandler(baixarAnexo);
            //nBaixarAnexo.Text = nomeArquivo;

            //pnlAnexo.Controls.Add(btnBaixarAnexo);

            btnBaixarAnexo.Text = nomeArquivo;

            pnlAnexo.Controls.Add(btnBaixarAnexo);

            hfIdMissaoUsuario.Value = mus_id.ToString();
        }
        else
        {
            lblTextoAnexo.Text = "Não há anexos";
        }

        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalDetalhesMissao').modal('show');</script>");
    }

    void baixarAnexo(string caminho)
    {
        string caminhoFormatado = caminho.Substring(caminho.LastIndexOf("gameup"));
        string[] caminhoSeparado = caminhoFormatado.Split('\\');
        string nomeArquivo = caminhoSeparado[caminhoSeparado.Length - 1];

        //Response.ContentType = "Application/any";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + nomeArquivo);
        Response.TransmitFile(caminho);
        Response.End();
    }

    void deletarAnexo(Object sender, EventArgs e, int idMissaoUsuario)
    {
        Console.Write("dsfsdfdsf");
    }

    public Missao procurarMissaoPorId(int idMissao)
    {
        DataSet missaoDs = MissaoBD.procurarMissaoPoId(idMissao);
        Missao missao = criarObjMissao(missaoDs);

        return missao;
    }

    public Missao criarObjMissao(DataSet missaoDs)
    {
        Missao missao = new Missao();

        try
        {
            foreach (DataRow mis in missaoDs.Tables[0].Rows)
            {
                missao.Id = Convert.ToInt32(mis["mis_id"]);
                missao.Nome = mis["mis_nome"].ToString();
                missao.Descricao = mis["mis_descricao"].ToString();
                missao.QtdExp = Convert.ToInt32(mis["mis_qtd_exp"]);
                missao.QtdPontos = Convert.ToInt32(mis["mis_qtd_pontos"]);
                missao.QtdMoedas = Convert.ToInt32(mis["mis_qtd_moedas"]);
                missao.Tipo = mis["mis_tipo"].ToString();
                missao.DtCriacao = Convert.ToDateTime(mis["mis_dt_criacao"]);
                missao.DtInicio = Convert.ToDateTime(mis["mis_dt_inicio"]);
                missao.DtFinal = Convert.ToDateTime(mis["mis_dt_final"]);
                missao.Status = mis["mis_status"].ToString();
                missao.UsuarioCriador = new Usuario();
                missao.UsuarioCriador.Usu_id = Convert.ToInt32(mis["usu_criador_id"].ToString());
            }
        }
        catch (Exception e)
        {
            Console.Write(e);
        }

        return missao;
    }


    public Usuario procurarUsuarioPorId(int usu_id)
    {
        DataSet usuarioDs = UsuarioBD.procurarUsuarioPorId(usu_id);

        Usuario usuario = criarObjUsuario(usuarioDs);

        return usuario;
    }

    public Usuario criarObjUsuario(DataSet usuarioDs)
    {
        Usuario usuario = new Usuario();

        try
        {
            foreach (DataRow mis in usuarioDs.Tables[0].Rows)
            {
                usuario.Usu_id = Convert.ToInt32(mis["usu_id"]);
                usuario.Usu_nome = mis["usu_nome"].ToString();
                usuario.Usu_qtdMoeda = Convert.ToInt32(mis["usu_qtdmoeda"]);
                usuario.Usu_qtdXp = Convert.ToInt32(mis["usu_qtdxp"]);
                usuario.Usu_qtdPontos = Convert.ToInt32(mis["usu_qtdpontos"]);
            }
        }
        catch (Exception e)
        {
            Console.Write(e);
        }

        return usuario;
    }


    public List<MissaoUsuario> criarListaObjMissaoUsuario(DataSet missoes)
    {
        List<MissaoUsuario> listaDeMissoesUsuario = new List<MissaoUsuario>();
        MissaoUsuario missaoUsuario;
        foreach (DataRow mus in missoes.Tables[0].Rows)
        {
            missaoUsuario = new MissaoUsuario();
            missaoUsuario.Missao = procurarMissaoPorId(Convert.ToInt32(mus["mis_id"]));
            missaoUsuario.Id = Convert.ToInt32(mus["mus_id"]);
            missaoUsuario.DtAtribuicao = Convert.ToDateTime(mus["mus_dt_atribuicao"]);
            missaoUsuario.Usuario = procurarUsuarioPorId(Convert.ToInt32(mus["usu_id"]));

            // Gambiarra
            string testeDtConclusao = mus["mus_dt_conclusao"].ToString();
            string testeDtStatus = mus["mus_status"].ToString();

            if (!testeDtConclusao.Equals(""))
            {
                missaoUsuario.DtConclusao = Convert.ToDateTime(mus["mus_dt_conclusao"]);
            }
            missaoUsuario.Status = statusSelecionado(mus["mus_status"].ToString());

            listaDeMissoesUsuario.Add(missaoUsuario);
        }

        return listaDeMissoesUsuario;
    }

    public StatusMissaoEnum statusSelecionado(string statusSelecionado)
    {

        StatusMissaoEnum status = new StatusMissaoEnum();

        if (StatusMissaoEnum.COMPLETA.ToString().Equals(statusSelecionado))
        {
            status = StatusMissaoEnum.COMPLETA;
        }
        else if (StatusMissaoEnum.CONCLUIDA.ToString().Equals(statusSelecionado))
        {
            status = StatusMissaoEnum.CONCLUIDA;
        }
        else if (StatusMissaoEnum.EM_ANDAMENTO.ToString().Equals(statusSelecionado))
        {
            status = StatusMissaoEnum.EM_ANDAMENTO;
        }
        else if (StatusMissaoEnum.INCOMPLETA.ToString().Equals(statusSelecionado))
        {
            status = StatusMissaoEnum.INCOMPLETA;
        }
        else if (StatusMissaoEnum.AG_VALIDACAO.ToString().Equals(statusSelecionado))
        {
            status = StatusMissaoEnum.AG_VALIDACAO;
        }
        else if (StatusMissaoEnum.VALIDADA.ToString().Equals(statusSelecionado))
        {
            status = StatusMissaoEnum.VALIDADA;
        }

        return status;
    }

    public List<Missao> criarListaObjMissao(DataSet missoes)
    {
        List<Missao> listaDeMissoes = new List<Missao>();
        Missao missao;
        foreach (DataRow mis in missoes.Tables[0].Rows)
        {
            missao = new Missao();
            missao.Id = Convert.ToInt32(mis["mis_id"]);
            missao.Nome = mis["mis_nome"].ToString();
            missao.Descricao = mis["mis_descricao"].ToString();

            // Verifica se possui data inicio
            if (mis["mis_dt_inicio"] != null)
            {
                missao.DtInicio = Convert.ToDateTime(mis["mis_dt_inicio"]);
            }

            // Verifica se possui data fim
            if (mis["mis_dt_final"] != null)
            {
                missao.DtFinal = Convert.ToDateTime(mis["mis_dt_final"]);
            }

            // Verifica se possui qtd pontos
            if (mis["mis_qtd_pontos"] != null)
            {
                missao.QtdPontos = Convert.ToInt32(mis["mis_qtd_pontos"]);
            }

            // Verifica se possui qtd moedas
            if (mis["mis_qtd_moedas"] != null)
            {
                missao.QtdMoedas = Convert.ToInt32(mis["mis_qtd_moedas"]);
            }

            // Verifica se possui qtd exp
            if (mis["mis_qtd_exp"] != null)
            {
                missao.QtdPontos = Convert.ToInt32(mis["mis_qtd_exp"]);
            }

            missao.Status = mis["mis_status"].ToString();
            missao.Tipo = mis["mis_tipo"].ToString();

            listaDeMissoes.Add(missao);
        }

        return listaDeMissoes;
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

            if (usuarioLogado.Tus_id != 2) //Gerente
            {
                Response.Redirect("../Visitante/Login.aspx");
            }

        }
    }

    protected void btnTodas_Click(object sender, EventArgs e)
    {
        carregarMissoes();
    }

    protected void btnConcluidas_Click(object sender, EventArgs e)
    {
        carregarMissoesPorStatus(StatusMissaoEnum.VALIDADA.ToString());
    }

    protected void btnEmAndamento_Click(object sender, EventArgs e)
    {
        carregarMissoesPorStatus(StatusMissaoEnum.EM_ANDAMENTO.ToString());
    }


    bool InserirArquivo(string caminho, string nome, int missaoUsuarioId)
    {
        bool ok = false;

        string caminhoCompleto = caminho + nome;
        if (ArquivoBD.InserirArquivo(caminhoCompleto, missaoUsuarioId))
        {
            ok = true;
        }

        return ok;
    }

    protected void btnConfirmarConclusaoMissao_Click(object sender, EventArgs e)
    {
        int missaoUsuarioId = Convert.ToInt32(hfIdMissao.Value);

        if (fuAnexo.HasFile)
        {
            if (fuAnexo.PostedFile.ContentLength <= 150000 && fuAnexo.PostedFile.ContentType == "application/vnd.ms-excel" ||
            fuAnexo.PostedFile.ContentType == "application/excel" ||
            fuAnexo.PostedFile.ContentType == "application/x-msexcel" ||
            fuAnexo.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" ||
            fuAnexo.PostedFile.ContentType == "application/pdf")
            {
                string caminhoArquivo = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoArquivos"] + @"\";

                string nomeArquivo = usuarioLogado.Usu_id + "-" + missaoUsuarioId + "-" + fuAnexo.FileName.ToString();
                fuAnexo.SaveAs(caminhoArquivo + nomeArquivo);

                InserirArquivo(caminhoArquivo, nomeArquivo, missaoUsuarioId);

                try
                {
                    int mus_id = Convert.ToInt32(hfIdMissao.Value);

                    MissaoUsuario missaoUsuario = new MissaoUsuario();
                    missaoUsuario = criarObjMissaoUsuario(MissaoUsuarioBD.procurarMissaoUsuarioPorId(mus_id));

                    missaoUsuario.Status = StatusMissaoEnum.AG_VALIDACAO;
                    missaoUsuario.DtConclusao = DateTime.Now;

                    //atribuirRecompensas(missaoUsuario);

                    MissaoUsuarioBD.concluirMissao(missaoUsuario);
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                finally
                {
                    Response.Redirect("../Gerente/Missoes.aspx");
                    carregarMissoes();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Ops!", "alert('Arquivo Inválido!! o tamanho máximo do arquivo é 15mb e nas extensões .xlsx, .xls, .csv, .pdf e .zip');", true);
            }
        }
        else
        {
            try
            {
                int mus_id = Convert.ToInt32(hfIdMissao.Value);

                MissaoUsuario missaoUsuario = new MissaoUsuario();
                missaoUsuario = criarObjMissaoUsuario(MissaoUsuarioBD.procurarMissaoUsuarioPorId(mus_id));

                missaoUsuario.Status = StatusMissaoEnum.AG_VALIDACAO;
                missaoUsuario.DtConclusao = DateTime.Now;

                //atribuirRecompensas(missaoUsuario);

                MissaoUsuarioBD.concluirMissao(missaoUsuario);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            finally
            {
                Response.Redirect("../Gerente/Missoes.aspx");
                carregarMissoes();
            }
        }


    }

    protected void btnBaixarAnexo_Click(object sender, EventArgs e)
    {
        int idMissao = Convert.ToInt32(hfIdMissaoUsuario.Value);

        DataSet caminhoArquivoDs = ArquivoBD.BuscarNomeDoArquivoPorIdDaMissaoUsuario(idMissao);
        string caminhoArquivo = caminhoArquivoDs.Tables[0].Rows[0]["mus_arquivo"].ToString();

        if (!caminhoArquivo.Equals(""))
        {
            baixarAnexo(caminhoArquivo);
        }
    }
}