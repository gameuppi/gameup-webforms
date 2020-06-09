using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Colaborador_Desenvolvimento : System.Web.UI.Page
{
    private static Usuario usuarioLogado;
    private static MissaoUsuario missUsuarioLogado;
    protected void Page_Load(object sender, EventArgs e)
    {
        validarSessao();

        if (!IsPostBack)
        {
            carregarPerfil();
            carregarMissoes();
            obterDadosPontos();
        }


    }
    //criação de grafico de xp, pontos e moedas por mes 

    protected string obterDadosPontos()
    {
        DataSet listaXpPontosMoedas = MissaoUsuarioBD.ContarXpPontoMoedaPorData(usuarioLogado.Usu_id);

        string qtdXp = listaXpPontosMoedas.Tables[0].Rows[0]["qtd_exp"].ToString();
        string qtdPontos = listaXpPontosMoedas.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string qtdMoedas = listaXpPontosMoedas.Tables[0].Rows[0]["qtd_moedas"].ToString();

        DataTable dados = new DataTable();

        //coluna dos dados
        dados.Columns.Add(new DataColumn("Task", typeof(string)));
        dados.Columns.Add(new DataColumn("Hours per Day", typeof(string)));
        // Os dados que serão mostrados no charts
        dados.Rows.Add(new object[] { "xp ", qtdXp });
        dados.Rows.Add(new object[] { " pontos", qtdPontos });
        dados.Rows.Add(new object[] { "moedas ", qtdMoedas });

        string strDados;

        strDados = "[['Task','Hours per Day'],";

        foreach (DataRow dr in dados.Rows)
        {
            strDados = strDados + "[";
            strDados = strDados + "'" + dr[0] + "'" + "," + dr[1];
            strDados = strDados + "],";
        }
        strDados = strDados + "]";


        return strDados;
    }

    // Obter dados de pontos xp e moedas dos ultimos 3meses
    protected string obterDadosPontosVariosMeses()
    {
        DataSet listaXpPontosMoedas1 = MissaoUsuarioBD.ContarXpPontoMoedaPorData(usuarioLogado.Usu_id);
        DataSet listaXpPontosMoedas2 = MissaoUsuarioBD.ContarXpPontoMoedaPorData2(usuarioLogado.Usu_id);
        DataSet listaXpPontosMoedas3 = MissaoUsuarioBD.ContarXpPontoMoedaPorData3(usuarioLogado.Usu_id);
        string qtdXp1 = listaXpPontosMoedas1.Tables[0].Rows[0]["qtd_exp"].ToString();
        string qtdPontos1 = listaXpPontosMoedas1.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string qtdMoedas1 = listaXpPontosMoedas1.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string qtdXp2 = listaXpPontosMoedas2.Tables[0].Rows[0]["qtd_exp"].ToString();
        string qtdPontos2 = listaXpPontosMoedas2.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string qtdMoedas2 = listaXpPontosMoedas2.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string qtdXp3 = listaXpPontosMoedas3.Tables[0].Rows[0]["qtd_exp"].ToString();
        string qtdPontos3 = listaXpPontosMoedas3.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string qtdMoedas3 = listaXpPontosMoedas3.Tables[0].Rows[0]["qtd_moedas"].ToString();

        DataTable dados = new DataTable();

        //coluna dos dados
        dados.Columns.Add(new DataColumn("xp", typeof(string)));
        dados.Columns.Add(new DataColumn("moedas", typeof(string)));
        dados.Columns.Add(new DataColumn("pontos", typeof(string)));
        string strDados;

        strDados = "[['Task','Hours per Day'],";

        foreach (DataRow dr in dados.Rows)
        {
            strDados = strDados + "[";
            strDados = strDados + "'" + dr[0] + "'" + "," + dr[1] + "'" + "," + dr[2];
            strDados = strDados + "],";
        }
        strDados = strDados + "]";


        return strDados;
    }










    //Criação do grafico de missoes (validadas, aguardando e em andamento) está sendo chamado em 'grafico  Missoes'
    protected string obterDados()
    {
        DataSet listaDeMissoesUsu2 = MissaoBD.procurarTodasMissaoUsuarioColaborador(usuarioLogado.Usu_id);
        int contAg = 0;
        int contEm = 0;
        int contVa = 0;
        List<MissaoUsuario> listaDeMisUsu = new List<MissaoUsuario>();
        MissaoUsuario usuarioM = new MissaoUsuario();

        foreach (DataRow usu in listaDeMissoesUsu2.Tables[0].Rows)
        {
            usuarioM = new MissaoUsuario();


            if (StatusMissaoEnum.AG_VALIDACAO.ToString().Equals(usu["mus_status"].ToString()))
            {
                usuarioM.Status = StatusMissaoEnum.AG_VALIDACAO;
                contAg++;
            }

            if (StatusMissaoEnum.EM_ANDAMENTO.ToString().Equals(usu["mus_status"].ToString()))
            {
                usuarioM.Status = StatusMissaoEnum.EM_ANDAMENTO;
                contEm++;
            }
            else if (StatusMissaoEnum.VALIDADA.ToString().Equals(usu["mus_status"].ToString()))
            {
                usuarioM.Status = StatusMissaoEnum.VALIDADA;
                contVa++;
            }
            listaDeMisUsu.Add(usuarioM);
        }

        DataTable dados = new DataTable();

        //coluna dos dados
        dados.Columns.Add(new DataColumn("Task", typeof(string)));
        dados.Columns.Add(new DataColumn("Hours per Day", typeof(string)));
        // Os dados que serão mostrados no charts
        dados.Rows.Add(new object[] { "Missões aceitas", contVa });
        dados.Rows.Add(new object[] { "Missões a fazer", contEm });
        dados.Rows.Add(new object[] { "Missões pendentes", contAg });

        string strDados;

        strDados = "[['Task','Hours per Day'],";

        foreach (DataRow dr in dados.Rows)
        {
            strDados = strDados + "[";
            strDados = strDados + "'" + dr[0] + "'" + "," + dr[1];
            strDados = strDados + "],";
        }
        strDados = strDados + "]";


        return strDados;
    }




    //metodo que faz a verificação e contagem dos tipos de missao
    public void carregarMissoes()
    {
        DataSet listaDeMissoesUsu = MissaoUsuarioBD.teste(usuarioLogado.Usu_id, 2020, 06);
        DataSet listaDeMissoesUsu2 = MissaoBD.procurarTodasMissaoUsuarioColaborador(usuarioLogado.Usu_id);
        int contAg = 0;
        int contEm = 0;
        int contVa = 0;
        List<MissaoUsuario> listaDeMisUsu = new List<MissaoUsuario>();
        MissaoUsuario usuarioM = new MissaoUsuario();

        foreach (DataRow usu in listaDeMissoesUsu2.Tables[0].Rows)
        {
            usuarioM = new MissaoUsuario();


            if (StatusMissaoEnum.AG_VALIDACAO.ToString().Equals(usu["mus_status"].ToString()))
            {
                usuarioM.Status = StatusMissaoEnum.AG_VALIDACAO;
                contAg++;
            }

            if (StatusMissaoEnum.EM_ANDAMENTO.ToString().Equals(usu["mus_status"].ToString()))
            {
                usuarioM.Status = StatusMissaoEnum.EM_ANDAMENTO;
                contEm++;
            }
            else if (StatusMissaoEnum.VALIDADA.ToString().Equals(usu["mus_status"].ToString()))
            {
                usuarioM.Status = StatusMissaoEnum.VALIDADA;
                contVa++;
            }






            listaDeMisUsu.Add(usuarioM);
        }
        lblAgAvalidacao.Text = $"{contAg}";
        lblEmAvalidacao.Text = $"{contEm}";
        lblVaAvalidacao.Text = $"{contVa}";
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

            if (usuarioLogado.Tus_id != 1 && usuarioLogado.Tus_id != 2) // Colaborador ou Gerente
            {
                Response.Redirect("../Visitante/Login.aspx");
            }

        }
    }
    void carregarPerfil()
    {

        lblMoedas.Text = usuarioLogado.Usu_qtdMoeda.ToString();
        lblPontos.Text = usuarioLogado.Usu_qtdPontos.ToString();
        lblXp.Text = usuarioLogado.Usu_qtdXp.ToString();

    }







}