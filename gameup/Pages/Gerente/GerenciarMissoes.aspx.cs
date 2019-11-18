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
        carregarMissoes();
    }

    protected void cadastrarMissao_Click(object sender, EventArgs e)
    {

        try
        {
            Missao missao = new Missao();
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

            // Verifica se a missao esta completa
            if (!estaCompleta(missao))
            {
                missao.Status = StatusMissaoEnum.INCOMPLETA.ToString();
            }
            else
            {
                missao.Status = StatusMissaoEnum.COMPLETA.ToString();
            }

            // Insere a missao no banco de dados
            switch (MissaoBD.InsertMissao(missao))
            {
                case true:
                    msgModalCadastraMissao.Text = "<h4 class='text-success'> Sua nova missão foi cadastrada com sucesso!</h4>";
                    ltrTituloModal.Text = "Ótimo!";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalCadastraMissao').modal('show');</script>");
                    break;
                case false:
                    msgModalCadastraMissao.Text = "<h4 class='text-warning'> Sua nova missão não pode ser cadastrada. Algum erro aconteceu.</h4>";
                    ltrTituloModal.Text = "Poxa vida!";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalCadastraMissao').modal('show');</script>");
                    break;
            }

        }
        catch (Exception)
        {

        }
        finally
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            dtInicio.Text = "";
            dtFim.Text = "";
            txtQtdExp.Text = "";
            txtQtdMoedas.Text = "";
            txtQtdPontos.Text = "";
            txtParticipantes.Text = "";
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

    public StatusMissaoEnum statusSelecionado(string statusSelecionado)
    {

        StatusMissaoEnum status = new StatusMissaoEnum();

        if (StatusMissaoEnum.COMPLETA.ToString().Equals(statusSelecionado))
        {
            status = StatusMissaoEnum.COMPLETA;
        } else if (StatusMissaoEnum.CONCLUIDA.ToString().Equals(statusSelecionado))
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

        return status;
    } 

    public bool estaCompleta(Missao missao)
    {
        bool estaCompleta = false;

        if ((!missao.Nome.Equals("")) &&
            (!missao.Descricao.Equals("")) &&
            (!missao.DtInicio.Equals("")) &&
            (!missao.DtFinal.Equals("")) &&
            (!missao.QtdExp.Equals("")) &&
            (!missao.QtdMoedas.Equals("")) &&
            (!missao.QtdPontos.Equals("")) &&
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

    public List<MissaoUsuario> criarListaObjMissaoUsuario(DataSet missoes)
    {
        List<MissaoUsuario> listaDeMissoesUsuario = new List<MissaoUsuario>();
        MissaoUsuario missaoUsuario;
        foreach (DataRow mus in missoes.Tables[0].Rows) 
        {
            missaoUsuario = new MissaoUsuario();
            missaoUsuario.Missao = procurarMissaoPorId(Convert.ToInt32(mus["mis_id"]));
            missaoUsuario.DtAtribuicao = Convert.ToDateTime(mus["mus_dt_atribuicao"]);

            // Gambiarra
            string testeDtConclusao = mus["mus_dt_conclusao"].ToString();

            if (!testeDtConclusao.Equals(""))
            {
                missaoUsuario.DtConclusao = Convert.ToDateTime(mus["mus_dt_conclusao"]);
            }
            missaoUsuario.Status = statusSelecionado(mus["mus_status"].ToString());

            listaDeMissoesUsuario.Add(missaoUsuario);
        }

        return listaDeMissoesUsuario;
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

    public Missao procurarMissaoPorId(int idMissao)
    {
        DataSet missaoDs = MissaoBD.procurarMissaoPoId(idMissao);
        Missao missao = criarObjMissao(missaoDs);

        return missao;
    }

    public void carregarMissoes()
    {
        List<Missao> listaDeMissoes = criarListaObjMissao(MissaoBD.procurarMissao());
        List<MissaoUsuario> listaDeMissoesUsuario = criarListaObjMissaoUsuario(MissaoBD.procurarTodasMissaoUsuario()); // usuario chumbado

        carregarMissoesIncompletas(listaDeMissoes);
        carregarTodasAsMissoesUsuario(listaDeMissoesUsuario);
    }

    public void carregarMissoesIncompletas(List<Missao> listaDeMissoes)
    {
        string resp = "";

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
            resp = "<div class='col-12 col-md-4 mb-4'> <h5>Não há missões em construção...</h5> </div>";
        }

        ltrMissoesEmConstrucao.Text = resp;
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

        ltrMissoesEmConstrucao.Text = resp;
    }

    public void carregarTodasAsMissoesUsuario(List<MissaoUsuario> listaMissoesUsuario)
    {
        string resp = "";

        foreach (MissaoUsuario missao in listaMissoesUsuario)
        {

            Button btnDetalhes = new Button();
            btnDetalhes.Text = "Detalhes";

            if (missao.Status.Equals(StatusMissaoEnum.CONCLUIDA))
            {
                resp += " <div class='col-12 col-md-4 mb-4'> ";
                resp += "     <div class='card border-left-success shadow h-100 py-2'> ";
                resp += "         <div class='card-body'> ";
                resp += "             <div class='row no-gutters align-items-center'> ";
                resp += "                 <div class='col mr-2'> ";
                resp += "                     <div class='text-sm font-weight-bold text-success text-uppercase mb-1'> " + missao.Missao.Nome + "</div> ";
                resp += "                     <div class='h6 mb-0 text-gray-800'> " + missao.Missao.Descricao + "</div> ";
                resp += "                     <div class='mt-4' id='desc'> ";
                resp += "                         <i class='fas fa-user fa-2x text-success'></i> ";
                resp += "                         &nbsp; João Ricardo ";
                resp += "                         <br /> ";
                resp += "                         <br /> ";
                resp += "                         <button class='btn btn-success btn-block' type='button' data-toggle='modal' data-target='#modalDetalhesMissao' id='" + missao.Id + "'>Detalhes</button>";
                resp += "                     </div> ";
                resp += "                 </div> ";
                resp += "                 <div class='col-auto'> ";
                resp += "                     <a href='#'><i class='fas fa-check fa-2x text-success'></i></a> ";
                resp += "                 </div> ";
                resp += "             </div> ";
                resp += "         </div> ";
                resp += "     </div> ";
                resp += " </div> ";
            }
            else if (missao.Status.Equals(StatusMissaoEnum.EM_ANDAMENTO))
            {
                resp += " <div class='col-12 col-md-4 mb-4'> ";
                resp += "     <div class='card border-left-warning shadow h-100 py-2'> ";
                resp += "         <div class='card-body'> ";
                resp += "             <div class='row no-gutters align-items-center'> ";
                resp += "                 <div class='col mr-2'> ";
                resp += "                     <div class='text-sm font-weight-bold text-warning text-uppercase mb-1'> " + missao.Missao.Nome + "</div> ";
                resp += "                     <div class='h6 mb-0 text-gray-800'> " + missao.Missao.Descricao + "</div> ";
                resp += "                     <div class='mt-4'> ";
                resp += "                         <i class='fas fa-user fa-2x text-warning'></i> ";
                resp += "                         &nbsp; João Ricardo ";
                resp += "                         <br /> ";
                resp += "                         <br /> ";
                resp += "                         <button class='btn btn-warning btn-block' type='button' data-toggle='modal' data-target='#modalDetalhesMissao' id=' " + missao.Missao.Id + "'>Detalhes</button>";
                resp += "                     </div> ";
                resp += "                 </div> ";
                resp += "                 <div class='col-auto'> ";
                resp += "                     <a href='#'><i class='fas fa-clock fa-2x text-warning'></i></a> ";
                resp += "                 </div> ";
                resp += "             </div> ";
                resp += "         </div> ";
                resp += "     </div> ";
                resp += " </div> ";
            }
        }

        if (resp.Equals(""))
        {
            resp = "<div class='col-12 col-md-4 mb-4'> <h5>Não há missões para visualizar...</h5> </div>";
        }

        ltrVisualizarMissoes.Text = resp;

    }


    protected void btnContinuarCriacao_Click(object sender, EventArgs e)
    {

    }
}
