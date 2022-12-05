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
    public partial class cadastrar_jogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void Btn_Cadastrar_Jogo(object sender, EventArgs e)
        {
            string nomeJogo   = txbNomeJogo.Text;
            string genero     = txbGenero.Text;
            string plataforma = txbPlataforma.Text;
            double preco      = Convert.ToDouble(txbPreco.Text);
            DateTime data     = DateTime.Parse(txbDataLanc.Text);
            string dataLanc   = data.ToString("dd/MM/yyyy");

            Jogo jogo = new Jogo();
            jogo.NomeJogo = nomeJogo;
            jogo.Genero = genero;
            jogo.Plataforma = plataforma;
            jogo.Preco = preco;
            jogo.DataLancamento = dataLanc;

            DaoJogo daoJogo = new DaoJogo();
            bool retorno = daoJogo.cadastrarJogo(jogo);

            if (retorno == true)
            {
                Response.Write("<script>alert('Jogo cadastrado com sucesso!');window.location='cadastrar_jogo.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('Houve um erro ao cadastrar o jogo. Entre em contato com o suporte.');window.location='cadastrar_jogo.aspx';</script>");
            }
        }
    }
}