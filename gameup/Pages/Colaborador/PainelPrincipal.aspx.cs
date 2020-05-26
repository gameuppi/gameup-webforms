using System;
using System.Collections.Generic;
using System.Data;
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
}