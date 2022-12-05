using LojaGames.Classes.BAS;
using LojaGames.Classes.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaGames
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sair = Request.QueryString["sair"];

            if (sair != null && sair.Equals("true"))
            {
                Session.Clear();
            }
        }

        protected void Btn_Entrar(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string senha = txtSenha.Text;

            Conta conta = new Conta();
            conta.Login = login;
            conta.Senha = senha;

            DaoLogin daoLogin = new DaoLogin();
            conta = daoLogin.buscarLogin(conta);

            int idUsuario = conta.IdUsuario;

            // 1 = admin, 2 = cliente
            if (conta.IdTipoConta == 1)
            {
                Response.Redirect("./Admin/home.aspx?idUsuario=" + idUsuario);
            }
            else if (conta.IdTipoConta == 2)
            {
                Response.Redirect("./Cliente/home.aspx?idUsuario=" + idUsuario);
            }
            else
            {
                Response.Write("<script>alert('Usuário e/ou senha inválido(s)');window.location='./';</script>");
            }
        }
    }
}