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
    public partial class cadastro_cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Cadastrar_Cliente(object sender, EventArgs e)
        {
            string nome     = txbNome.Text;
            DateTime data   = DateTime.Parse(txbDataNasc.Text);
            string dataNasc = data.ToString("dd/MM/yyyy");
            string email    = txbEmail.Text;
            string cpf      = txbCpf.Text;
            string telefone = txbTelefone.Text;
            string login    = txbLogin.Text;
            string senha    = txbSenha.Text;

            Usuario usuario = new Usuario(nome, dataNasc, email, cpf, telefone);
            DaoUsuario daoUsuario = new DaoUsuario();
            bool retornaUsuario = daoUsuario.cadastrarUsuario(usuario);

            if (retornaUsuario == false)
            {
                int idUsuario = daoUsuario.buscarUsuario(cpf);
                Conta conta = new Conta(2, login, senha);
                DaoConta daoConta = new DaoConta();
                daoConta.cadastrarConta(conta, idUsuario);

                Response.Write("<script>alert('Usuário cadastrado com sucesso!');window.location='Default.aspx';</script>");
            } else
            {
                Response.Write("<script>alert('O CPF digitado já está cadastrado em nossa loja.');window.location='cadastro_cliente.aspx';</script>");
            }
        }
    }
}