using LojaGames.Classes.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaGames.Cliente
{
    public partial class listaDesejo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string acao = Request.QueryString["acao"];

            if (!Page.IsPostBack)
            {
                listaDesejos();

                if (Session["idUsuario"] == null)
                {
                    string idUsuario = Request.QueryString["idUsuario"];

                    if (idUsuario == null || idUsuario == "")
                    {
                        Response.Write("<script>window.location='../';</script>");
                    }
                    else
                    {
                        Session["idUsuario"] = idUsuario;
                    }
                }

                if ("RemoverJogo".Equals(acao))
                {
                    int idJogo = int.Parse(Request.QueryString["idJogo"]);
                    int idUsuario = int.Parse(Session["idUsuario"].ToString());

                    DaoJogo daoJogo = new DaoJogo();
                    bool retorno = daoJogo.removerJogoDesejo(idJogo, idUsuario);

                    if (retorno == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Jogo removido com sucesso!'); window.location.href='listaDesejo.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Erro ao rermover jogo. Entre em contato com o suporte.'); window.location.href='listaDesejo.aspx';", true);
                    }
                }
            }
        }

        protected void listaDesejos()
        {
            int idUsuario = int.Parse(Session["idUsuario"].ToString());
            gridListaDesejos.DataSource = DaoJogo.fillTable("SELECT j.idJogo, j.nomeJogo, j.genero, j.plataforma, j.dataLancamento FROM jogo j, listaDesejo ld WHERE j.idJogo = ld.idJogo AND ld.idConta = (SELECT idConta FROM conta WHERE idUsuario = '" + idUsuario + "')");
            gridListaDesejos.DataBind();
        }
    }
}