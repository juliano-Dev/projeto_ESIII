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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                exibeUsuario();

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

        protected void exibeUsuario()
        {
            int idUsuario = int.Parse(Session["idUsuario"].ToString());
            gridUsuario.DataSource = DaoUsuario.fillTable("SELECT u.idUsuario, c.login, c.senha, u.nomeUsuario, u.email, u.telefone FROM conta c JOIN usuario u ON c.idUsuario = u.idUsuario WHERE u.idUsuario = '" + idUsuario + "'");
            gridUsuario.DataBind();
        }

        protected void gridUsuario_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridUsuario.EditIndex = e.NewEditIndex;
            exibeUsuario();
        }

        protected void gridUsuario_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idUsuario = Convert.ToInt32(((Label)gridUsuario.Rows[e.RowIndex].FindControl("labelIdUsuario")).Text);
            string login = ((TextBox)gridUsuario.Rows[e.RowIndex].FindControl("txbLogin")).Text;
            string senha = ((TextBox)gridUsuario.Rows[e.RowIndex].FindControl("txbSenha")).Text;
            string nomeUsuario = ((TextBox)gridUsuario.Rows[e.RowIndex].FindControl("txbNomeUsuario")).Text;
            string email = ((TextBox)gridUsuario.Rows[e.RowIndex].FindControl("txbEmail")).Text;
            string telefone = ((TextBox)gridUsuario.Rows[e.RowIndex].FindControl("txbTelefone")).Text;

            Conta conta = new Conta();
            conta.Login = login;
            conta.Senha = senha;
            Usuario usuario = new Usuario();
            usuario.IdUsuario = idUsuario;
            usuario.NomeUsuario = nomeUsuario;
            usuario.Email = email;
            usuario.Telefone = telefone;

            DaoConta daoConta = new DaoConta();
            bool retornoConta = daoConta.editarConta(conta, idUsuario);
            DaoUsuario daoUsuario = new DaoUsuario();
            bool retornoUsuario = daoUsuario.editarUsuario(usuario);

            if (retornoConta == true && retornoUsuario == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Perfil editado com sucesso!'); window.location.href='perfil.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Houve um erro ao editar o perfil. Entre em contato com o suporte.'); window.location.href='perfil.aspx';", true);
            }

            gridUsuario.EditIndex = -1;
            exibeUsuario();
        }
    }
}