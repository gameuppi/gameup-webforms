using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Colaborador_PainelPrincipal : System.Web.UI.Page
{
    private static Usuario usuarioLogado;

    protected void Page_Load(object sender, EventArgs e)
    {
        validarSessao();
        TableRow tr;
        TableCell tcPosicao;
        TableCell tcNome;
        TableCell tcPontos;


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
                txtApelido1.Text = usuarioLogado.Usu_apelido;
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

            if (usuarioLogado.Tus_id != 1) // Gerente
            {
                Response.Redirect("../Visitante/Login.aspx");
            }

        }
    }


    public string ObterDadosDoUsuarioSema()
    {
        DataTable dados = new DataTable();

        DataSet gerargraficosetor1 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaColaborador(usuarioLogado.Usu_id, 0);
        DataSet gerargraficosetor2 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaColaborador(usuarioLogado.Usu_id, 1);
        DataSet gerargraficosetor3 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaColaborador(usuarioLogado.Usu_id, 2);
        DataSet gerargraficosetor4 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaColaborador(usuarioLogado.Usu_id, 3);
        DataSet gerargraficosetor5 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaColaborador(usuarioLogado.Usu_id, 4);
        DataSet gerargraficosetor6 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaColaborador(usuarioLogado.Usu_id, 5);
        DataSet gerargraficosetor7 = MissaoUsuarioBD.ContarXpPontoMoedaPorSemanaColaborador(usuarioLogado.Usu_id, 6);

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


}