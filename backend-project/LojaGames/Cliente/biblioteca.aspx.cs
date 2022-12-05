using LojaGames.Classes.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaGames.Cliente
{
    public partial class biblioteca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                listaBiblioteca();

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
            }
        }

        protected void listaBiblioteca()
        {
            int idUsuario = int.Parse(Session["idUsuario"].ToString());
            gridBiblioteca.DataSource = DaoJogo.fillTable("SELECT j.idJogo, j.nomeJogo, j.genero, j.plataforma, j.dataLancamento FROM jogo j, biblioteca b WHERE j.idJogo = b.idJogo AND b.idConta = (SELECT idConta FROM conta WHERE idUsuario = '" + idUsuario + "')");
            gridBiblioteca.DataBind();
        }
    }
}