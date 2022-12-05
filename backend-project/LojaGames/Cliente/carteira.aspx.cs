using LojaGames.Classes.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaGames.Cliente
{
    public partial class carteira : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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

            DaoConta daoConta = new DaoConta();
            double carteira = daoConta.buscaCarteira(int.Parse(Session["idUsuario"].ToString()));
            txbSaldo.Text = carteira.ToString();
        }

        protected void Btn_Pagar(object sender, EventArgs e)
        {
            double adcFundos = double.Parse(txbAdcFundos.Text);
            int idUsuario = int.Parse(Session["idUsuario"].ToString());

            DaoConta daoConta = new DaoConta();
            bool retorno = daoConta.adcFundos(idUsuario, adcFundos);

            if (retorno == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Saldo atualizado!'); window.location.href='carteira.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Erro ao atualizar seu saldo. Entre em contato com o suporte.'); window.location.href='carteia.aspx';", true);
            }
        }
    }
}