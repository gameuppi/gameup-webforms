using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Visitante_Login : System.Web.UI.Page
{
    static List<Usuario> listaUsuarios = new List<Usuario>();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public Usuario criarObjUsuario(DataSet usuario)
    {
        Usuario usu = new Usuario();
        
        usu.Usu_id = Convert.ToInt32(usuario.Tables[0].Rows[0]["usu_id"].ToString());
        usu.Usu_nome = usuario.Tables[0].Rows[0]["usu_nome"].ToString();
        usu.Usu_email = usuario.Tables[0].Rows[0]["usu_email"].ToString();
        usu.Usu_senha = usuario.Tables[0].Rows[0]["usu_senha"].ToString();
        usu.Usu_apelido = usuario.Tables[0].Rows[0]["usu_apelido"].ToString();
        usu.Usu_qtdMoeda = Convert.ToInt32(usuario.Tables[0].Rows[0]["usu_qtdMoeda"].ToString());
        usu.Usu_qtdPontos = Convert.ToInt32(usuario.Tables[0].Rows[0]["usu_qtdPontos"].ToString());
        usu.Usu_qtdXp = Convert.ToInt32(usuario.Tables[0].Rows[0]["usu_qtdXp"].ToString());
        usu.Tus_id = Convert.ToInt32(usuario.Tables[0].Rows[0]["tus_id"].ToString());
        usu.Set_id = Convert.ToInt32(usuario.Tables[0].Rows[0]["set_id"].ToString());
        usu.Emp_id = Convert.ToInt32(usuario.Tables[0].Rows[0]["emp_id"].ToString());

        return usu;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();
        usu.Usu_email = txtEmail.Text;
        usu.Usu_senha = txtSenha.Text;


        switch ( UsuarioDB.Login(usu))
        {
            case 1:
                Usuario usuario = criarObjUsuario(UsuarioBD.procurarUsuarioPorEmail(usu.Usu_email));

                Session["USUARIO"] = usuario;

                if (usuario.Tus_id == 1)
                {
                    Response.Redirect("../Colaborador/PainelPrincipal.aspx");
                } else if (usuario.Tus_id == 2)
                {
                    Response.Redirect("../Gerente/GerenciarMissoes.aspx");
                }
                else if (usuario.Tus_id == 3)
                {
                    Response.Redirect("../Representante/GerenciarColaboradores.aspx");
                }
                else if (usuario.Tus_id == 4)
                {
                    Response.Redirect("../Administrador/PainelPrincipal.aspx");
                }
                else if (usuario.Tus_id == 5)
                {
                    Response.Redirect("../Moderador/PainelPrincipal.aspx");
                }


                break;
            case -1:
                ltlMsg.Text = "Ops... E-mail ou senha inválido!";
                break;
            case -2:
                ltlMsg.Text = "Ops... E-mail ou senha inválido!";
                break;
        }
    }
}