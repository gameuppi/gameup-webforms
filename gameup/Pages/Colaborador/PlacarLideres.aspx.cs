using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Colaborador_PlacarLideres : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TableRow tr;
        TableCell tcPosicao;
        TableCell tcNome;
        TableCell tcPontos;


        DataSet listaDeUsuariosDs = PlacarLideresBD.procurarUsuariosPlacarGeral(1);
        List<Usuario> listaDeUsuarios = new List<Usuario>();
        Usuario usuario = new Usuario();

        foreach (DataRow usu in listaDeUsuariosDs.Tables[0].Rows)
        {
            usuario = new Usuario();
            usuario.Nome = usu["usu_nome"].ToString();
            usuario.QtdPontos = Convert.ToInt32(usu["usu_qtd_pontos"].ToString());
            listaDeUsuarios.Add(usuario);
        }

        int pos = 1;

        foreach(Usuario usu in listaDeUsuarios)
        {
            // Preenche top 3
            if (pos == 1)
            {
                lbl1Posicao.Text = usu.Nome;
                lblPontos1Posicao.Text = usu.QtdPontos.ToString();
            } else if (pos == 2)
            {
                lbl2Posicao.Text = usu.Nome;
                lblPontos2Posicao.Text = usu.QtdPontos.ToString();
            } else if (pos == 3)
            {
                lbl3Posicao.Text = usu.Nome;
                lblPontos3Posicao.Text = usu.QtdPontos.ToString();
            }

            // Preenche placar geral
            tcPosicao = new TableCell();
            tcNome = new TableCell();
            tcPontos = new TableCell();
            tr = new TableRow();

            tcPosicao.Text = pos.ToString();
            tcNome.Text = usu.Nome;
            tcPontos.Text = usu.QtdPontos.ToString();
            tr.Controls.Add(tcPosicao);
            tr.Controls.Add(tcNome);
            tr.Controls.Add(tcPontos);
            
            pos++;

            tblPlacarGeral.Controls.Add(tr);
        }

    }
}