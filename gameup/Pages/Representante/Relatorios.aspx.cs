using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Representante_Relatorios : System.Web.UI.Page
{
    private static Usuario usuarioLogado;
    private static MissaoUsuario missUsuarioLogado;
    protected void Page_Load(object sender, EventArgs e)
    {
        validarSessao();
        ltlGerarGrafico.Text = "<div id='curve_chart_Sema' style=' min-height:400px; '></div>";
        if (!IsPostBack)
        {
            carregarMissoes();
        }
    }

    //RELATORIO DE REPRESENTANTE

    //grafico semanal
    public string ObterDadosDoUsuarioSema()
    {
        DataTable dados = new DataTable();

        DataSet gerargraficosetor1 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaEmpresa(usuarioLogado.Emp_id, 0);
        DataSet gerargraficosetor2 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaEmpresa(usuarioLogado.Emp_id, 1);
        DataSet gerargraficosetor3 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaEmpresa(usuarioLogado.Emp_id, 2);
        DataSet gerargraficosetor4 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaEmpresa(usuarioLogado.Emp_id, 3);
        DataSet gerargraficosetor5 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaEmpresa(usuarioLogado.Emp_id, 4);
        DataSet gerargraficosetor6 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaEmpresa(usuarioLogado.Emp_id, 5);
        DataSet gerargraficosetor7 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaEmpresa(usuarioLogado.Emp_id, 6);

        string pontos1 = gerargraficosetor1.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia1 = gerargraficosetor1.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda1 = gerargraficosetor1.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string pontos2 = gerargraficosetor2.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia2 = gerargraficosetor2.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda2 = gerargraficosetor2.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string pontos3 = gerargraficosetor3.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia3 = gerargraficosetor3.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda3 = gerargraficosetor3.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string pontos4 = gerargraficosetor4.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia4 = gerargraficosetor4.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda4 = gerargraficosetor4.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string pontos5 = gerargraficosetor5.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia5 = gerargraficosetor5.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda5 = gerargraficosetor5.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string pontos6 = gerargraficosetor6.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia6 = gerargraficosetor6.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda6 = gerargraficosetor6.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string pontos7 = gerargraficosetor7.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia7 = gerargraficosetor7.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda7 = gerargraficosetor7.Tables[0].Rows[0]["qtd_moedas"].ToString();

        CultureInfo culture = new CultureInfo("pt-BR");
        DateTimeFormatInfo dtfi = culture.DateTimeFormat;

        //DateTime dia7 = Convert.ToDateTime("2020-06-24");

        //DateTime dia7 = Convert.ToDateTime(gerargraficosetor7.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());
        //DateTime dia6 = Convert.ToDateTime(gerargraficosetor6.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());
        //DateTime dia5 = Convert.ToDateTime(gerargraficosetor5.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());
        //DateTime dia4 = Convert.ToDateTime(gerargraficosetor4.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());
        //DateTime dia3 = Convert.ToDateTime(gerargraficosetor3.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());
        //DateTime dia2 = Convert.ToDateTime(gerargraficosetor2.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());

        DateTime dia1 = DateTime.Now;
        DateTime dia2 = dia1.AddDays(-1);
        DateTime dia3 = dia1.AddDays(-2);
        DateTime dia4 = dia1.AddDays(-3);
        DateTime dia5 = dia1.AddDays(-4);
        DateTime dia6 = dia1.AddDays(-5);
        DateTime dia7 = dia1.AddDays(-6);


        string dia7s = dtfi.GetDayName(dia7.DayOfWeek);
        string dia6s = dtfi.GetDayName(dia6.DayOfWeek);
        string dia5s = dtfi.GetDayName(dia5.DayOfWeek);
        string dia4s = dtfi.GetDayName(dia4.DayOfWeek);
        string dia3s = dtfi.GetDayName(dia3.DayOfWeek);
        string dia2s = dtfi.GetDayName(dia2.DayOfWeek);
        string dia1s = dtfi.GetDayName(dia1.DayOfWeek);


        //testedata = testedata.Substring(0, 1).ToUpper() + testedata.Substring(1);
        //coluna dos dados
        dados.Columns.Add(new DataColumn("Data", typeof(string)));
        dados.Columns.Add(new DataColumn("Moedas", typeof(string)));
        dados.Columns.Add(new DataColumn("Pontos", typeof(string)));
        dados.Columns.Add(new DataColumn("Experiencia", typeof(string)));
        // Os dados que serão mostrados no charts

        if (moeda1 == "" || pontos1 == "" || experiencia1 == "")
        {
            moeda1 = "0";
            pontos1 = "0";
            experiencia1 = "0";
        }
        if (moeda2 == "" || pontos2 == "" || experiencia2 == "")
        {
            moeda2 = "0";
            pontos2 = "0";
            experiencia2 = "0";
        }
        if (moeda3 == "" || pontos3 == "" || experiencia3 == "")
        {
            moeda3 = "0";
            pontos3 = "0";
            experiencia3 = "0";
        }
        if (moeda4 == "" || pontos4 == "" || experiencia4 == "")
        {
            moeda4 = "0";
            pontos4 = "0";
            experiencia4 = "0";
        }
        if (moeda5 == "" || pontos5 == "" || experiencia5 == "")
        {
            moeda5 = "0";
            pontos5 = "0";
            experiencia5 = "0";
        }
        if (moeda6 == "" || pontos6 == "" || experiencia6 == "")
        {
            moeda6 = "0";
            pontos6 = "0";
            experiencia6 = "0";
        }
        if (moeda7 == "" || pontos7 == "" || experiencia7 == "")
        {
            moeda7 = "0";
            pontos7 = "0";
            experiencia7 = "0";
        }

        dados.Rows.Add(new object[] { dia7s, moeda7, pontos7, experiencia7 });
        dados.Rows.Add(new object[] { dia6s, moeda6, pontos6, experiencia6 });
        dados.Rows.Add(new object[] { dia5s, moeda5, pontos5, experiencia5 });
        dados.Rows.Add(new object[] { dia4s, moeda4, pontos4, experiencia4 });
        dados.Rows.Add(new object[] { dia3s, moeda3, pontos3, experiencia3 });
        dados.Rows.Add(new object[] { dia2s, moeda2, pontos2, experiencia2 });
        dados.Rows.Add(new object[] { dia1s, moeda1, pontos1, experiencia1 });

        string strDados;

        strDados = "[['Data','Moedas', 'Pontos', 'Experiencia'],";

        foreach (DataRow dr in dados.Rows)
        {
            strDados = strDados + "[";
            strDados = strDados + "'" + dr[0] + "'" + "," + dr[1] + "," + dr[2] + "," + dr[3];
            strDados = strDados + "],";
        }
        strDados = strDados + "]";


        return strDados;
    }


    //grafico trimestre
    public string ObterDadosDoUsuarioTri()
    {
        DataTable dados = new DataTable();


        DataSet gerargraficosetor1 = MissaoUsuarioBD.ContarXpPontoMoedaPorData1Empresa(usuarioLogado.Emp_id, 0);
        DataSet gerargraficosetor2 = MissaoUsuarioBD.ContarXpPontoMoedaPorData1Empresa(usuarioLogado.Emp_id, 1);
        DataSet gerargraficosetor3 = MissaoUsuarioBD.ContarXpPontoMoedaPorData1Empresa(usuarioLogado.Emp_id, 2);

        string pontos1 = gerargraficosetor1.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia1 = gerargraficosetor1.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda1 = gerargraficosetor1.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string pontos2 = gerargraficosetor2.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia2 = gerargraficosetor2.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda2 = gerargraficosetor2.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string pontos3 = gerargraficosetor3.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia3 = gerargraficosetor3.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda3 = gerargraficosetor3.Tables[0].Rows[0]["qtd_moedas"].ToString();

        CultureInfo culture = new CultureInfo("pt-BR");
        DateTimeFormatInfo dtfi = culture.DateTimeFormat;

        //DateTime mes3 = Convert.ToDateTime(gerargraficosetor3.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());
        //DateTime mes2 = Convert.ToDateTime(gerargraficosetor2.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());
        //DateTime mes1 = Convert.ToDateTime(gerargraficosetor1.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());
        DateTime mes1 = DateTime.Now;
        DateTime mes2 = mes1.AddMonths(-1);
        DateTime mes3 = mes1.AddMonths(-2);
        
        string mes3s = dtfi.GetMonthName(mes3.Month);
        string mes2s = dtfi.GetMonthName(mes2.Month);
        string mes1s = dtfi.GetMonthName(mes1.Month);

        if (moeda1 == "" || pontos1 == "" || experiencia1 == "")
        {
            moeda1 = "0";
            pontos1 = "0";
            experiencia1 = "0";
        }
         if (moeda2 == "" || pontos2 == "" || experiencia2 == "")
        {
            moeda2 = "0";
            pontos2 = "0";
            experiencia2 = "0";
        }
         if (moeda3 == "" || pontos3 == "" || experiencia3 == "")
        {
            moeda3 = "0";
            pontos3 = "0";
            experiencia3 = "0";
        }

        //coluna dos dados
        dados.Columns.Add(new DataColumn("Data", typeof(string)));
        dados.Columns.Add(new DataColumn("Moedas", typeof(string)));
        dados.Columns.Add(new DataColumn("Pontos", typeof(string)));
        dados.Columns.Add(new DataColumn("Experiencia", typeof(string)));
        // Os dados que serão mostrados no charts

        dados.Rows.Add(new object[] { mes3s, moeda3, pontos3, experiencia3 });
        dados.Rows.Add(new object[] { mes2s, moeda2, pontos2, experiencia2 });
        dados.Rows.Add(new object[] { mes1s, moeda1, pontos1, experiencia1 });

        string strDados;

        strDados = "[['Data','Moedas', 'Pontos', 'Experiencia'],";

        foreach (DataRow dr in dados.Rows)
        {
            strDados = strDados + "[";
            strDados = strDados + "'" + dr[0] + "'" + "," + dr[1] + "," + dr[2] + "," + dr[3];
            strDados = strDados + "],";
        }
        strDados = strDados + "]";


        return strDados;
    }


    //grafico semestral
    public string ObterDadosDoUsuarioSem()
    {
        DataTable dados = new DataTable();

        DataSet gerargraficosetor1 = MissaoUsuarioBD.ContarXpPontoMoedaPorData1Empresa(usuarioLogado.Emp_id, 0);
        DataSet gerargraficosetor2 = MissaoUsuarioBD.ContarXpPontoMoedaPorData1Empresa(usuarioLogado.Emp_id, 1);
        DataSet gerargraficosetor3 = MissaoUsuarioBD.ContarXpPontoMoedaPorData1Empresa(usuarioLogado.Emp_id, 2);
        DataSet gerargraficosetor4 = MissaoUsuarioBD.ContarXpPontoMoedaPorData1Empresa(usuarioLogado.Emp_id, 3);
        DataSet gerargraficosetor5 = MissaoUsuarioBD.ContarXpPontoMoedaPorData1Empresa(usuarioLogado.Emp_id, 4);
        DataSet gerargraficosetor6 = MissaoUsuarioBD.ContarXpPontoMoedaPorData1Empresa(usuarioLogado.Emp_id, 5);

        string pontos1 = gerargraficosetor1.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia1 = gerargraficosetor1.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda1 = gerargraficosetor1.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string pontos2 = gerargraficosetor2.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia2 = gerargraficosetor2.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda2 = gerargraficosetor2.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string pontos3 = gerargraficosetor3.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia3 = gerargraficosetor3.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda3 = gerargraficosetor3.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string pontos4 = gerargraficosetor4.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia4 = gerargraficosetor4.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda4 = gerargraficosetor4.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string pontos5 = gerargraficosetor5.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia5 = gerargraficosetor5.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda5 = gerargraficosetor5.Tables[0].Rows[0]["qtd_moedas"].ToString();

        string pontos6 = gerargraficosetor6.Tables[0].Rows[0]["qtd_pontos"].ToString();
        string experiencia6 = gerargraficosetor6.Tables[0].Rows[0]["qtd_exp"].ToString();
        string moeda6 = gerargraficosetor6.Tables[0].Rows[0]["qtd_moedas"].ToString();


        CultureInfo culture = new CultureInfo("pt-BR");
        DateTimeFormatInfo dtfi = culture.DateTimeFormat;

        //DateTime mes6 = Convert.ToDateTime(gerargraficosetor6.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());
        //DateTime mes5 = Convert.ToDateTime(gerargraficosetor5.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());
        //DateTime mes4 = Convert.ToDateTime(gerargraficosetor4.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());
        //DateTime mes3 = Convert.ToDateTime(gerargraficosetor3.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());
        //DateTime mes2 = Convert.ToDateTime(gerargraficosetor2.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());
        //DateTime mes1 = Convert.ToDateTime(gerargraficosetor1.Tables[0].Rows[0]["mus_dt_conclusao"].ToString());

        DateTime mes1 = DateTime.Now;
        DateTime mes2 = mes1.AddMonths(-1);
        DateTime mes3 = mes1.AddMonths(-2);
        DateTime mes4 = mes1.AddMonths(-3);
        DateTime mes5 = mes1.AddMonths(-4);
        DateTime mes6 = mes1.AddMonths(-5);

        

        string mes6s = dtfi.GetMonthName(mes6.Month);
        string mes5s = dtfi.GetMonthName(mes5.Month);
        string mes4s = dtfi.GetMonthName(mes4.Month);
        string mes3s = dtfi.GetMonthName(mes3.Month);
        string mes2s = dtfi.GetMonthName(mes2.Month);
        string mes1s = dtfi.GetMonthName(mes1.Month);



        if (moeda1 == "" || pontos1 == "" || experiencia1 == "")
        {
            moeda1 = "0";
            pontos1 = "0";
            experiencia1 = "0";
        }
         if (moeda2 == "" || pontos2 == "" || experiencia2 == "")
        {
            moeda2 = "0";
            pontos2 = "0";
            experiencia2 = "0";
        }
         if (moeda3 == "" || pontos3 == "" || experiencia3 == "")
        {
            moeda3 = "0";
            pontos3 = "0";
            experiencia3 = "0";
        }
         if (moeda4 == "" || pontos4 == "" || experiencia4 == "")
        {
            moeda4 = "0";
            pontos4 = "0";
            experiencia4 = "0";
        }
         if (moeda5 == "" || pontos5 == "" || experiencia5 == "")
        {
            moeda5 = "0";
            pontos5 = "0";
            experiencia5 = "0";
        }
         if (moeda6 == "" || pontos6 == "" || experiencia6 == "")
        {
            moeda6 = "0";
            pontos6 = "0";
            experiencia6 = "0";
        }
        //coluna dos dados
        dados.Columns.Add(new DataColumn("Data", typeof(string)));
        dados.Columns.Add(new DataColumn("Moedas", typeof(string)));
        dados.Columns.Add(new DataColumn("Pontos", typeof(string)));
        dados.Columns.Add(new DataColumn("Experiencia", typeof(string)));
        // Os dados que serão mostrados no charts
        dados.Rows.Add(new object[] { mes6s, moeda6, pontos6, experiencia6 });
        dados.Rows.Add(new object[] { mes5s, moeda5, pontos5, experiencia5 });
        dados.Rows.Add(new object[] { mes4s, moeda4, pontos4, experiencia4 });
        dados.Rows.Add(new object[] { mes3s, moeda3, pontos3, experiencia3 });
        dados.Rows.Add(new object[] { mes2s, moeda2, pontos2, experiencia2 });
        dados.Rows.Add(new object[] { mes1s, moeda1, pontos1, experiencia1 });

        string strDados;

        strDados = "[['Data','Moedas', 'Pontos', 'Experiencia'],";

        foreach (DataRow dr in dados.Rows)
        {
            strDados = strDados + "[";
            strDados = strDados + "'" + dr[0] + "'" + "," + dr[1] + "," + dr[2] + "," + dr[3];
            strDados = strDados + "],";
        }
        strDados = strDados + "]";


        return strDados;
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

    //Criação do grafico de missoes (validadas, aguardando e em andamento) está sendo chamado em 'grafico  Missoes'
    protected string obterDados()
    {
        DataSet listaDeMissoesUsu2 = MissaoBD.procurarTodasMissaoUsuarioColaboradorEmpresa(usuarioLogado.Emp_id);
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
        DataSet listaDeMissoesUsu = MissaoBD.procurarTodasMissaoUsuarioColaboradorEmpresa(usuarioLogado.Emp_id);
        int contAg = 0;
        int contEm = 0;
        int contVa = 0;
        List<MissaoUsuario> listaDeMisUsu = new List<MissaoUsuario>();
        MissaoUsuario usuarioM = new MissaoUsuario();

        foreach (DataRow usu in listaDeMissoesUsu.Tables[0].Rows)
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




    protected void btnGerarGrafico_Click(object sender, EventArgs e)
    {
        if (dropdownMenuButton.SelectedValue.ToString().Equals("sem"))
        {
            ltlGerarGrafico.Text = "<div id='curve_chart_Sem' style=' min-height: 380px; '></div>";

        }
        else if (dropdownMenuButton.SelectedValue.ToString().Equals("tri"))
        {
            ltlGerarGrafico.Text = "<div id='curve_chart_Tri' style=' min-height: 380px; '></div>";

        }
        else if (dropdownMenuButton.SelectedValue.ToString().Equals("sema"))
        {
            ltlGerarGrafico.Text = "<div id='curve_chart_Sema' style=' min-height: 380px; '></div>";
        }
    }
}