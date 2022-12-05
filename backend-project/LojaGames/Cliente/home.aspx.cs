using LojaGames.Classes.BAS;
using LojaGames.Classes.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaGames.Cliente
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string acao = Request.QueryString["acao"];

            if (!Page.IsPostBack)
            {
                listaJogos();

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

                if ("ComprarJogo".Equals(acao))
                {
                    int idJogo = int.Parse(Request.QueryString["idJogo"]);
                    int idUsuario = int.Parse(Session["idUsuario"].ToString());

                    DaoConta daoConta = new DaoConta();
                    bool retorno = daoConta.comprarJogo(idJogo, idUsuario);

                    if (retorno == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Jogo adicionado à sua biblioteca!'); window.location.href='home.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Saldo insuficiente!'); window.location.href='home.aspx';", true);
                    }
                } else if ("AddDesejo".Equals(acao))
                {
                    int idJogo = int.Parse(Request.QueryString["idJogo"]);
                    int idUsuario = int.Parse(Session["idUsuario"].ToString());

                    DaoConta daoConta = new DaoConta();
                    bool retorno = daoConta.addDesejo(idJogo, idUsuario);

                    if (retorno == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Jogo adicionado à sua lista de desejos!'); window.location.href='home.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Erro ao adicionar jogo à sua lista de desejos. Entre em contato com o suporte.'); window.location.href='home.aspx';", true);
                    }
                }
            }
        }

        protected void listaJogos()
        {
            gridJogos.DataSource = DaoJogo.fillTable("SELECT idJogo, nomeJogo, genero, plataforma, preco, dataLancamento FROM jogo");
            gridJogos.DataBind();
        }
    }
}