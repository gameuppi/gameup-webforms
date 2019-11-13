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
                    //ltrInfo.Text = "<div class='alert alert-success' role='alert'>Missão cadastrada com sucesso!</ div >";
                    break;
                case false:
                    string naoOk;
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

    public void carregarMissoes()
    {
        DataSet missoes = MissaoBD.procurarMissao();

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

        carregarMissoesIncompletas(listaDeMissoes);

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
                resp += "                         <button type='button' class='btn btn-danger btn-block' data-toggle='modal' data-target='#exampleModalCenter'>Detalhes</button> ";
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

        ltrMissoesEmConstrucao.Text = resp;
    }

    /*public void carregarTodasAsMissoes(List<Missao> listaDeMissoes)
    {

    }*/

}
