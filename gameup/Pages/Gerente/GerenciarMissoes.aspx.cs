using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Gerente_GerenciarMissoes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            limparTudo();
            carregarListaParticipantes();
        }
        carregarMissoes();
    }

    public void limparTudo()
    {
        txtNome.Text = "";
        txtDescricao.Text = "";
        dtInicio.Text = "";
        dtFim.Text = "";
        txtQtdExp.Text = "";
        txtQtdMoedas.Text = "";
        txtQtdPontos.Text = "";
        ltbParticipantes.Items.Clear();
    }

    List<int> criarListaDeParticipantes()
    {
        List<int> listaDeParticipantes = new List<int>();

        if (rdbTipoSetor.Checked)
        {
            //DataSet listaDeUsuarios = SetorBD.procurarUsuariosSetor(1);
            DataSet usuarioGerente = SetorBD.procurarGerenteSetor(1);
            int idGerente = 0;

            idGerente = Convert.ToInt32(usuarioGerente.Tables[0].Rows[0]["usu_id"].ToString());

            listaDeParticipantes.Add(idGerente);

        }
        else if (rdbTipoIndividual.Checked)
        {
            foreach (ListItem item in ltbParticipantes.Items)
            {
                if (item.Selected)
                {
                    listaDeParticipantes.Add(Convert.ToInt32(item.Value));
                }
            }
        }
        else if (rdbTipoGrupo.Checked)
        {
            foreach (ListItem item in ltbParticipantes.Items)
            {
                if (item.Selected)
                {
                    listaDeParticipantes.Add(Convert.ToInt32(item.Value));
                }
            }
        }

        return listaDeParticipantes;
    }

    Missao inserirNaMissao(Missao missao)
    {
        missao.Nome = txtNome.Text;
        missao.Descricao = txtDescricao.Text;

        // Verifica se as datas foram preenchidas para realizar a conversao
        if (!dtInicio.Text.Equals("") && dtInicio != null ||
            !dtFim.Text.Equals("") && dtFim != null)
        {
            missao.DtInicio = Convert.ToDateTime(dtInicio.Text);
            missao.DtFinal = Convert.ToDateTime(dtFim.Text);
        }

        missao.DtCriacao = DateTime.Now;

        // Verifica se as recompensas foram preenchidas para realizar a conversao
        if (!txtQtdMoedas.Text.Equals("") && txtQtdMoedas != null ||
            !txtQtdPontos.Text.Equals("") && txtQtdPontos != null ||
            !txtQtdExp.Text.Equals("") && txtQtdExp != null
            )
        {
            missao.QtdMoedas = Convert.ToInt32(txtQtdMoedas.Text);
            missao.QtdPontos = Convert.ToInt32(txtQtdPontos.Text);
            missao.QtdExp = Convert.ToInt32(txtQtdExp.Text);
        }

        missao.Tipo = tipoSelecionado();

        return missao;
    }

    protected void cadastrarMissao_Click(object sender, EventArgs e)
    {

        if (!idMissao.Text.Equals(""))
        {
            // Se o campo id_missao estiver preenchido, significa que ele esta em continuar criacao
            Missao missao = criarObjMissao(MissaoBD.procurarMissaoPoId(Convert.ToInt32(idMissao.Text)));
            missao = inserirNaMissao(missao);

            if (estaCompleta(missao))
            {
                missao.Status = StatusMissaoEnum.COMPLETA.ToString();
                registrarMissaoUsuario(criarListaDeParticipantes(), missao);
            }
            else
            {
                missao.Status = StatusMissaoEnum.INCOMPLETA.ToString();
            }

            // Atualiza o banco de dados
            MissaoBD.UpdateMissao(missao);
            limparTudo();
            //carregarListaParticipantes();
            carregarMissoes();

            // Preenche modal
            msgModalCadastraMissao.Text = "<h5 class='text-success'> Sua missão foi atualizada com sucesso!</h5>";
            ltrTituloModal.Text = "Ótimo!";
            // Abre modal de sucesso
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalCadastraMissao').modal('show');</script>");

        }
        else
        {

            try
            {
                Missao missao = new Missao();
                missao = inserirNaMissao(missao);

                // Verifica se a missao esta completa
                if (!estaCompleta(missao))
                {
                    missao.Status = StatusMissaoEnum.INCOMPLETA.ToString();
                }
                else
                {
                    missao.Status = StatusMissaoEnum.COMPLETA.ToString();
                }

                List<int> listaDeParticipantes = criarListaDeParticipantes();

                // Insere a missao no banco de dados
                switch (MissaoBD.InsertMissao(missao))
                {
                    case true:
                        msgModalCadastraMissao.Text = "<h5 class='text-success'> Sua nova missão foi cadastrada com sucesso!</h5>";
                        ltrTituloModal.Text = "Ótimo!";
                        // Abre modal de sucesso
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalCadastraMissao').modal('show');</script>");

                        registrarMissaoUsuario(listaDeParticipantes, missao);

                        break;
                    case false:
                        msgModalCadastraMissao.Text = "<h5 class='text-warning'> Sua nova missão não pode ser cadastrada. Algum erro aconteceu.</h5>";
                        ltrTituloModal.Text = "Poxa vida!";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalCadastraMissao').modal('show');</script>");
                        break;
                }


            }
            catch (Exception exc)
            {
                Console.Write(exc.StackTrace);
            }
            finally
            {
                limparTudo();
                //carregarListaParticipantes();
                carregarMissoes();
            }
        }
    }

    public void limparParticipantes()
    {
        ltbParticipantes.Items.Clear();
    }

    public void carregarListaParticipantes()
    {

        limparParticipantes();

        if (rdbTipoIndividual.Checked)
        {
            DataSet listaDeUsuarios = MissaoBD.procurarUsuariosEmpresa(1);

            // Carrega informacoes no modal 
            lblTituloParticipantes.Text = "<h4> Colaboradores </h4>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalParticipantes').modal('show');</script>");

            // Carrega os colaboradores
            foreach (DataRow usu in listaDeUsuarios.Tables[0].Rows)
            {
                ltbParticipantes.Items.Add(new ListItem(usu["usu_nome"].ToString(), usu["usu_id"].ToString()));
            }

        }
        else if (rdbTipoSetor.Checked)
        {

            DataSet listaDeSetores = MissaoBD.procurarSetoresEmpresa(1);

            // Carrega informacoes no modal 
            lblTituloParticipantes.Text = "<h4> Setores </h4>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalParticipantes').modal('show');</script>");

            // Carrega os setores
            foreach (DataRow set in listaDeSetores.Tables[0].Rows)
            {
                ltbParticipantes.Items.Add(new ListItem(set["set_nome"].ToString(), set["set_id"].ToString()));
            }

        }
        else if (rdbTipoGrupo.Checked)
        {
            ltbParticipantes.SelectionMode = ListSelectionMode.Multiple;
            DataSet listaDeUsuarios = MissaoBD.procurarUsuariosEmpresa(1);

            // Carrega informacoes no modal 
            lblTituloParticipantes.Text = "<h4> Colaboradores </h4>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalParticipantes').modal('show');</script>");

            // Carrega os colaboradores
            foreach (DataRow usu in listaDeUsuarios.Tables[0].Rows)
            {
                ltbParticipantes.Items.Add(new ListItem(usu["usu_nome"].ToString(), usu["usu_id"].ToString()));
            }
        }
    }

    public void registrarMissaoUsuario(List<int> listaDeParticipantes, Missao missao)
    {
        DataSet ultimoId = MissaoBD.procurarIdMissao();
        int maiorId = 0;

        foreach (DataRow id in ultimoId.Tables[0].Rows)
        {
            maiorId = Convert.ToInt32(id["mis_id"].ToString());
        }

        MissaoUsuario missaoUsuario = new MissaoUsuario();
        missaoUsuario.Missao = criarObjMissao(MissaoBD.procurarMissaoPoId(maiorId));
        missaoUsuario.DtAtribuicao = DateTime.Now;

        if (missao.Status.Equals(StatusMissaoEnum.INCOMPLETA.ToString()))
        {
            missaoUsuario.Status = StatusMissaoEnum.INCOMPLETA;
        }
        else
        {
            missaoUsuario.Status = StatusMissaoEnum.EM_ANDAMENTO;
        }

        foreach (int i in listaDeParticipantes)
        {
            missaoUsuario.Usuario = new Usuario();
            missaoUsuario.Usuario.Id = i;
            MissaoUsuarioBD.InsertMissaoUsuario(missaoUsuario);
        }
    }

    public string tipoSelecionado()
    {
        string tipo = "";

        if (rdbTipoIndividual.Checked)
        {
            tipo = TipoMissaoEnum.INDIVIDUAL.ToString();
        }
        else if (rdbTipoGrupo.Checked)
        {
            tipo = TipoMissaoEnum.GRUPO.ToString();
        }
        else
        {
            tipo = TipoMissaoEnum.SETOR.ToString();
        }

        return tipo;
    }

    public TipoMissaoEnum tipoSelecionado(Missao missao)
    {
        string tipo = "";

        if (missao.Tipo.Equals(TipoMissaoEnum.INDIVIDUAL))
        {
            tipo = TipoMissaoEnum.INDIVIDUAL.ToString();
        }
        else if (missao.Tipo.Equals(TipoMissaoEnum.GRUPO))
        {
            tipo = TipoMissaoEnum.GRUPO.ToString();
        }
        else
        {
            tipo = TipoMissaoEnum.SETOR.ToString();
        }

        return tipo;
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

    public bool estaCompleta(Missao missao)
    {
        bool estaCompleta = false;

        if ((!missao.Nome.Equals("")) &&
            (!missao.Descricao.Equals("")) &&
            (missao.DtInicio != Convert.ToDateTime("01/01/0001")) &&
            (missao.DtFinal != Convert.ToDateTime("01/01/0001")) &&
            (missao.QtdExp != 0) &&
            (missao.QtdMoedas != 0) &&
            (missao.QtdPontos != 0) &&
            (!tipoSelecionado().Equals("")) && (tipoSelecionado() != null))
        {
            estaCompleta = true;
        }

        return estaCompleta;
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

    public Usuario procurarUsuarioPorId(int usu_id)
    {
        DataSet usuarioDs = UsuarioBD.procurarUsuarioPorId(usu_id);

        Usuario usuario = criarObjUsuario(usuarioDs);

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

    public MissaoUsuario criarObjMissaoUsuario(DataSet missao)
    {
        MissaoUsuario missaoUsuario = new MissaoUsuario();
        missaoUsuario.Id = Convert.ToInt32(missao.Tables[0].Rows[0]["mus_id"]);
        missaoUsuario.DtValidacao = DateTime.Now;
        missaoUsuario.Usuario = procurarUsuarioPorId(Convert.ToInt32(missao.Tables[0].Rows[0]["usu_id"]));

        return missaoUsuario;
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
            }
        }
        catch (Exception e)
        {
            Console.Write(e);
        }

        return missao;
    }

    public Usuario criarObjUsuario(DataSet usuarioDs)
    {
        Usuario usuario = new Usuario();

        try
        {
            foreach (DataRow mis in usuarioDs.Tables[0].Rows)
            {
                usuario.Id = Convert.ToInt32(mis["usu_id"]);
                usuario.Nome = mis["usu_nome"].ToString();
            }
        }
        catch (Exception e)
        {
            Console.Write(e);
        }

        return usuario;
    }

    public Missao procurarMissaoPorId(int idMissao)
    {
        DataSet missaoDs = MissaoBD.procurarMissaoPoId(idMissao);
        Missao missao = criarObjMissao(missaoDs);

        return missao;
    }

    public void carregarMissoes()
    {
        pnlMissaoAgValidacao.Controls.Clear();
        pnlMissoesEmConstrucao.Controls.Clear();
        pnlMissoesVisualizar.Controls.Clear();

        List<Missao> listaDeMissoes = criarListaObjMissao(MissaoBD.procurarMissao());
        List<MissaoUsuario> listaDeMissoesUsuario = criarListaObjMissaoUsuario(MissaoBD.procurarTodasMissaoUsuario()); // usuario chumbado

        carregarMissoesIncompletas(listaDeMissoes);
        carregarTodasAsMissoesUsuario(listaDeMissoesUsuario);
    }



    public void carregarMissoesIncompletas(List<Missao> listaDeMissoes)
    {
        string resp = "";
        pnlMissoesEmConstrucao.Controls.Clear();

        foreach (Missao missao in listaDeMissoes)
        {

            if (missao.Nome.Equals(""))
            {
                missao.Nome = "NOME NÃO DEFINIDO";
            }

            if (missao.Descricao.Equals(""))
            {
                missao.Descricao = "Descrição ainda não definida.";
            }

            if (missao.Status.Equals(StatusMissaoEnum.INCOMPLETA.ToString()))
            {
                Literal topo = new Literal();
                Literal rodape = new Literal();
                resp = "";

                resp += " <div class='col-12 col-md-4 mb-4'> ";
                resp += "     <div class='card border-left-danger shadow h-100 py-2'> ";
                resp += "         <div class='card-body'> ";
                resp += "             <div class='row no-gutters align-items-center'> ";
                resp += "                 <div class='col mr-2'> ";
                resp += "                     <div class='text-sm font-weight-bold text-danger text-uppercase mb-1'> " + missao.Nome + "</div> ";
                resp += $"                     <div class='h6 mb-0 text-gray-800'>{missao.Descricao}</div> ";
                resp += "                     <div class='mt-4'> ";
                resp += "                         <i class='fas fa-user fa-2x text-danger'></i> ";
                resp += "                         &nbsp;  ";
                resp += "                         <br /> ";
                resp += "                         <br /> ";

                topo.Text = resp;
                resp = "";

                LinkButton btnContinuarCadastro = new LinkButton();
                btnContinuarCadastro.Text = "Continuar criação";
                btnContinuarCadastro.Click += (sender, e) => { this.continuarCriacaoMissao(sender, e, missao.Id); };
                btnContinuarCadastro.ID = missao.Id.ToString();
                btnContinuarCadastro.CssClass = "btn btn-block btn-danger";

                resp += "                     </div> ";
                resp += "                 </div> ";
                resp += "                 <div class='col-auto'> ";
                resp += "                     <a href='#'><i class='fas fa-wrench fa-2x text-danger'></i></a> ";
                resp += "                 </div> ";
                resp += "             </div> ";
                resp += "         </div> ";
                resp += "     </div> ";
                resp += " </div> ";

                rodape.Text = resp;

                pnlMissoesEmConstrucao.Controls.Add(topo);
                pnlMissoesEmConstrucao.Controls.Add(btnContinuarCadastro);
                pnlMissoesEmConstrucao.Controls.Add(rodape);
            }
        }

        if (resp.Equals(""))
        {
            resp = "<div class='col-12 col-md-4 mb-4'> <h5>Não há missões em construção...</h5> </div>";
        }

        //ltrMissoesEmConstrucao.Text = resp;
    }


    void continuarCriacaoMissao(object sender, EventArgs e, int mis_id)
    {
        Missao missao = procurarMissaoPorId(mis_id);

        txtNome.Text = missao.Nome;
        txtDescricao.Text = missao.Descricao;
        dtInicio.Text = String.Format("{0:dd/MM/yyyy}", missao.DtInicio.ToString());
        dtFim.Text = String.Format("{0:dd/MM/yyyy}", missao.DtFinal);
        txtQtdExp.Text = missao.QtdExp.ToString();
        txtQtdMoedas.Text = missao.QtdMoedas.ToString();
        txtQtdPontos.Text = missao.QtdPontos.ToString();
        idMissao.Text = mis_id.ToString();

        TipoMissaoEnum tipoMissao = tipoSelecionado(missao);
        if (tipoMissao.Equals(TipoMissaoEnum.INDIVIDUAL))
        {
            rdbTipoIndividual.Checked = true;
        }
        else if (tipoMissao.Equals(TipoMissaoEnum.GRUPO))
        {
            rdbTipoGrupo.Checked = true;
        }
        else if (tipoMissao.Equals(TipoMissaoEnum.SETOR))
        {
            rdbTipoSetor.Checked = true;
        }

        navCadastroTab.CssClass = "nav-item nav-link active";
    }

    void verDetalhesMissao(object sender, EventArgs e, int mis_id)
    {
        Missao missao = procurarMissaoPorId(mis_id);

        ltrDetalhesMoedas.Text = missao.QtdMoedas.ToString();
        ltrDetalhesEstrelas.Text = missao.QtdExp.ToString();
        ltrDetalhesMeteoros.Text = missao.QtdPontos.ToString();

        ltrDetalhesDescricao.Text = missao.Descricao;
        //ltrDataConclusao.Text = missao.dt;

        navCadastroTab.CssClass = "nav-item nav-link active";
    }

    public void carregarTodasAsMissoes(List<Missao> listaDeMissoes)
    {
        string resp = "";

        foreach (Missao missao in listaDeMissoes)
        {
            if (missao.Status.Equals(StatusMissaoEnum.COMPLETA.ToString()))
            {
                resp += " <div class='col-12 col-md-4 mb-4'> ";
                resp += "     <div class='card border-left-danger shadow h-100 py-2'> ";
                resp += "         <div class='card-body'> ";
                resp += "             <div class='row no-gutters align-items-center'> ";
                resp += "                 <div class='col mr-2'> ";
                resp += "                     <div class='text-sm font-weight-bold text-danger text-uppercase mb-1'> " + missao.Nome + "</div> ";
                resp += "                     <div class='h6 mb-0 text-gray-800'> " + missao.Descricao + "</div> ";
                resp += "                     <div class='mt-4'> ";
                resp += "                         <i class='fas fa-user fa-2x text-danger'></i> ";
                resp += "                         &nbsp; João Ricardo ";
                resp += "                         <br /> ";
                resp += "                         <br /> ";
                resp += "                         <asp:Button class='btn btn-danger' Text='Continuar criação' type='button' runat='server' ID='btnContinuarCriacao' OnClick='btnContinuarCriacao_Click'></asp:Button>";
                resp += "                     </div> ";
                resp += "                 </div> ";
                resp += "                 <div class='col-auto'> ";
                resp += "                     <a href='#'><i class='fas fa-wrench fa-2x text-danger'></i></a> ";
                resp += "                 </div> ";
                resp += "             </div> ";
                resp += "         </div> ";
                resp += "     </div> ";
                resp += " </div> ";
            }
        }

        if (resp.Equals(""))
        {
            resp = "<div class='col-12 col-md-4 mb-4'> <h5>Não há missões para visuzalizar...</h5> </div>";
        }

        //ltrMissoesEmConstrucao.Text = resp;
    }

    public void carregarTodasAsMissoesUsuario(List<MissaoUsuario> listaMissoesUsuario)
    {
        string resp = "";

        foreach (MissaoUsuario missao in listaMissoesUsuario)
        {
            DataSet idUsuario = UsuarioBD.procurarUsuarioPorId(missao.Usuario.Id);
            Usuario usuario = new Usuario();

            foreach (DataRow id in idUsuario.Tables[0].Rows)
            {
                usuario.Id = Convert.ToInt32(id["usu_id"].ToString());
                usuario.Nome = id["usu_nome"].ToString();
            }

            if (missao.Status.Equals(StatusMissaoEnum.CONCLUIDA))
            {
                Literal topo = new Literal();
                Literal meio = new Literal();
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
                resp += $"                         &nbsp; {missao.Usuario.Nome} ";
                resp += "                         <br /> ";
                resp += "                         <br /> ";

                topo.Text = resp;
                resp = "";

                LinkButton btnContinuarCadastro = new LinkButton();
                btnContinuarCadastro.Text = "Detalhes";
                btnContinuarCadastro.Click += (sender, e) => { this.verDetalhesMissao(sender, e, missao.Id); };
                btnContinuarCadastro.ID = missao.Id.ToString();
                btnContinuarCadastro.CssClass = "btn btn-block btn-warning";

                resp += "                     </div> ";
                resp += "                 </div> ";
                resp += "                 <div class='col-auto'> ";
                resp += "                     <a href='#'><i class='fas fa-clock fa-2x text-warning'></i></a> ";
                resp += "                 </div> ";
                resp += "             </div> ";
                resp += "         </div> ";
                resp += "     </div> ";
                resp += " </div> ";

                rodape.Text = resp;

                pnlMissoesEmConstrucao.Controls.Add(topo);
                pnlMissoesEmConstrucao.Controls.Add(btnContinuarCadastro);
                pnlMissoesEmConstrucao.Controls.Add(rodape);
            }
            else if (missao.Status.Equals(StatusMissaoEnum.EM_ANDAMENTO))
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
                resp += $"                         &nbsp; {missao.Usuario.Nome} ";
                resp += "                         <br /> ";
                resp += "                         <br /> ";

                topo.Text = resp;
                resp = "";

                LinkButton btnVerDetalhes = new LinkButton();
                btnVerDetalhes.Text = "Detalhes";
                btnVerDetalhes.Click += (sender, e) => { this.verDetalhesMissao(sender, e, missao.Missao.Id); };
                btnVerDetalhes.ID = (missao.Id + 20).ToString();
                btnVerDetalhes.CssClass = "btn btn-block btn-warning";


                resp += "                     </div> ";
                resp += "                 </div> ";
                resp += "                 <div class='col-auto'> ";
                resp += "                     <a href='#'><i class='fas fa-clock fa-2x text-warning'></i></a> ";
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
            else if (missao.Status.Equals(StatusMissaoEnum.AG_VALIDACAO))
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
                resp += $"                         &nbsp; {missao.Usuario.Nome} ";
                resp += "                         <br /> ";
                resp += "                         <br /> ";

                topo.Text = resp;
                resp = "";

                LinkButton btnVerDetalhes = new LinkButton();
                btnVerDetalhes.Text = "Detalhes";
                btnVerDetalhes.Click += (sender, e) => { this.verDetalhesMissao(sender, e, missao.Missao.Id); };
                btnVerDetalhes.ID = (missao.Id + 20).ToString();
                btnVerDetalhes.CssClass = "btn btn-block btn-info";

                resp += "                     </div> ";
                resp += "                 </div> ";
                resp += "                 <div class='col-auto'> ";

                meio.Text = resp;
                resp = "";

                LinkButton btnValidar = new LinkButton();
                btnValidar.Click += (sender, e) => { this.validarMissao(sender, e, missao.Id); };
                btnValidar.ID = (missao.Id + 50).ToString();
                btnValidar.Text = "<i class='fas fa-check fa-2x text-gray-500 icon-change'></i>";


                //resp += "                     <a href='#'><i class='fas fa-check fa-2x text-gray-500 icon-change'></i></a> ";
                resp += "                 </div> ";
                resp += "             </div> ";
                resp += "         </div> ";
                resp += "     </div> ";
                resp += " </div> ";

                rodape.Text = resp;

                pnlMissaoAgValidacao.Controls.Add(topo);
                pnlMissaoAgValidacao.Controls.Add(btnVerDetalhes);
                pnlMissaoAgValidacao.Controls.Add(meio);
                pnlMissaoAgValidacao.Controls.Add(btnValidar);
                pnlMissaoAgValidacao.Controls.Add(rodape);

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
                resp += $"                         &nbsp; {missao.Usuario.Nome} ";
                resp += "                         <br /> ";
                resp += "                         <br /> ";

                topo.Text = resp;
                resp = "";

                LinkButton btnContinuarCadastro = new LinkButton();
                btnContinuarCadastro.Text = "Detalhes";
                btnContinuarCadastro.Click += (sender, e) => { this.verDetalhesMissao(sender, e, missao.Id); };
                btnContinuarCadastro.ID = missao.Id.ToString();
                btnContinuarCadastro.CssClass = "btn btn-block btn-success";

                resp += "                     </div> ";
                resp += "                 </div> ";
                resp += "                 <div class='col-auto'> ";
                resp += "                     <a href='#'><i class='fas fa-check fa-2x text-success'></i></a> ";
                resp += "                 </div> ";
                resp += "             </div> ";
                resp += "         </div> ";
                resp += "     </div> ";
                resp += " </div> ";

                rodape.Text = resp;

                pnlMissoesVisualizar.Controls.Add(topo);
                pnlMissoesVisualizar.Controls.Add(btnContinuarCadastro);
                pnlMissoesVisualizar.Controls.Add(rodape);
            }
        }

        if (resp.Equals(""))
        {
            resp = "<div class='col-12 col-md-4 mb-4'> <h5>Não há missões para visualizar...</h5> </div>";
        }

        //ltrVisualizarMissoes.Text = resp;

    }

    void validarMissao(object sender, EventArgs e, int mus_id)
    {
        try
        {
            MissaoUsuario missaoUsuario = new MissaoUsuario();
            missaoUsuario = criarObjMissaoUsuario(MissaoUsuarioBD.procurarMissaoUsuarioPorId(mus_id));

            missaoUsuario.Status = StatusMissaoEnum.VALIDADA;

            MissaoUsuarioBD.validarMissao(missaoUsuario);
        }
        catch (Exception ex)
        {
            Console.Write(ex);
        }
        finally
        {
            carregarMissoes();
        }
    }

    protected void btnContinuarCriacao_Click(object sender, EventArgs e)
    {

    }

    protected void btnCarregarParticipantes_Click(object sender, EventArgs e)
    {
        carregarListaParticipantes();
    }
}
