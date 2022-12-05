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
    public partial class admins : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string acao = Request.QueryString["acao"];

            if (!Page.IsPostBack)
            {
                listaAdmins();

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

                if ("ExcluirAdministrador".Equals(acao))
                {
                    int idUsuario = int.Parse(Request.QueryString["idUsuario"]);

                    DaoUsuario daoUsuario = new DaoUsuario();
                    bool retorno = daoUsuario.excluirUsuario(idUsuario);

                    if (retorno == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Administrador excluído com sucesso!'); window.location.href='admins.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Erro ao excluir administrador. Entre em contato com o suporte.'); window.location.href='admins.aspx';", true);
                    }
                }
            }
        }
        protected void listaAdmins()
        {
            gridAdmins.DataSource = DaoJogo.fillTable("SELECT u.idUsuario, u.nomeUsuario, u.dataNascimento, u.email, u.cpf, u.telefone, c.dataCadastro FROM usuario u, conta c WHERE u.idUsuario = c.idUsuario AND c.idTipoConta = 1");
            gridAdmins.DataBind();
        }

        protected void gridAdmins_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridAdmins.EditIndex = e.NewEditIndex;
            listaAdmins();
        }

        protected void gridAdmins_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idUsuario = Convert.ToInt32(((Label)gridAdmins.Rows[e.RowIndex].FindControl("labelIdUsuario")).Text);
            string nomeUsuario = ((TextBox)gridAdmins.Rows[e.RowIndex].FindControl("txbNomeUsuario")).Text;
            string email = ((TextBox)gridAdmins.Rows[e.RowIndex].FindControl("txbEmail")).Text;
            string telefone = ((TextBox)gridAdmins.Rows[e.RowIndex].FindControl("txbTelefone")).Text;

            Usuario usuario = new Usuario();
            usuario.IdUsuario = idUsuario;
            usuario.NomeUsuario = nomeUsuario;
            usuario.Email = email;
            usuario.Telefone = telefone;

            DaoUsuario daoUsuario = new DaoUsuario();
            bool retorno = daoUsuario.editarUsuario(usuario);

            if (retorno == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Administrador editado com sucesso!'); window.location.href='admins.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Houve um erro ao editar o administrador. Entre em contato com o suporte.'); window.location.href='admins.aspx';", true);
            }

            gridAdmins.EditIndex = -1;
            listaAdmins();
        }
    }
}