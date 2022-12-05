using LojaGames.Classes.BAS;
using LojaGames.Classes.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaGames.Admin
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

                if ("ExcluirJogo".Equals(acao))
                {
                    int idJogo = int.Parse(Request.QueryString["idJogo"]);

                    DaoJogo daoJogo = new DaoJogo();
                    bool retorno = daoJogo.excluirJogo(idJogo);

                    if (retorno == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Jogo excluído com sucesso!'); window.location.href='home.aspx';", true);
                    } else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Erro ao excluir. Entre em contato com o suporte.'); window.location.href='home.aspx';", true);
                    }
                }
            }
        }

        protected void listaJogos()
        {
            gridJogos.DataSource = DaoJogo.fillTable("SELECT idJogo, nomeJogo, genero, plataforma, preco, dataLancamento FROM jogo");
            gridJogos.DataBind();
        }

        protected void gridJogos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridJogos.EditIndex = e.NewEditIndex;
            listaJogos();
        }

        protected void gridJogos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idJogo     = Convert.ToInt32(((Label)gridJogos.Rows[e.RowIndex].FindControl("labelIdJogo")).Text);
            string nomeJogo   = ((TextBox)gridJogos.Rows[e.RowIndex].FindControl("txbNomeJogo")).Text;
            string genero     = ((TextBox)gridJogos.Rows[e.RowIndex].FindControl("txbGenero")).Text;
            string plataforma = ((TextBox)gridJogos.Rows[e.RowIndex].FindControl("txbPlataforma")).Text;
            double preco      = Convert.ToDouble(((TextBox)gridJogos.Rows[e.RowIndex].FindControl("txbPreco")).Text);

            Jogo jogo = new Jogo();
            jogo.IdJogo     = idJogo;
            jogo.NomeJogo   = nomeJogo;
            jogo.Genero     = genero;
            jogo.Plataforma = plataforma;
            jogo.Preco      = preco;

            DaoJogo daoJogo = new DaoJogo();
            bool retorno = daoJogo.editarJogo(jogo);

            if (retorno == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Jogo editado com sucesso!'); window.location.href='home.aspx';", true);
            } else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Houve um erro ao editar o jogo. Entre em contato com o suporte.'); window.location.href='home.aspx';", true);
            }

            gridJogos.EditIndex = -1;
            listaJogos();
        }
    }
}