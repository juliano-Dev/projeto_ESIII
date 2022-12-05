using LojaGames.Classes.BAS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;

namespace LojaGames.Classes.DAO
{
    public class DaoUsuario
    {
        public bool cadastrarUsuario(Usuario usuario)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            bool retornaUsuario;

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT cpf ");
            sb.Append("FROM usuario ");
            sb.Append("WHERE cpf = :cpf ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":cpf", usuario.Cpf);

            try
            {
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    retornaUsuario = true;
                }
                else
                {
                    // Cria novo usuário
                    sb.Clear();
                    sb.Append("INSERT INTO usuario ");
                    sb.Append("(idUsuario, nomeUsuario, dataNascimento, email, cpf, telefone) ");
                    sb.Append("VALUES (s_usuario.nextval, :nomeUsuario, :dataNascimento, :email, :cpf, :telefone) ");

                    cmd.CommandText = sb.ToString();

                    cmd.Parameters.Add(":nomeUsuario", usuario.NomeUsuario);
                    cmd.Parameters.Add(":dataNascimento", usuario.DataNascimento);
                    cmd.Parameters.Add(":email", usuario.Email);
                    cmd.Parameters.Add(":cpf", usuario.Cpf);
                    cmd.Parameters.Add(":telefone", usuario.Telefone);

                    dr = cmd.ExecuteReader();

                    retornaUsuario = false;
                }
            }
            finally
            {
                if (dr != null) dr.Close();
            }
            return retornaUsuario;
        }

        public int buscarUsuario(string cpf)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            int retornaUsuario = 0;

            StringBuilder sb = new StringBuilder();

            sb.Clear();
            sb.Append("SELECT idUsuario ");
            sb.Append("FROM usuario ");
            sb.Append("WHERE cpf = :cpf ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":cpf", cpf);

            try
            {
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    retornaUsuario = int.Parse(dr["idUsuario"].ToString());
                }

            }
            finally
            {
                if (dr != null) dr.Close();
            }
            return retornaUsuario;
        }

        public bool editarUsuario(Usuario usuario)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            bool retorno;

            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE usuario ");
            sb.Append("SET nomeUsuario = :nomeUsuario, email = :email, telefone = :telefone ");
            sb.Append("WHERE idUsuario = :idUsuario ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":idUsuario", usuario.IdUsuario);
            cmd.Parameters.Add(":nomeUsuario", usuario.NomeUsuario);
            cmd.Parameters.Add(":email", usuario.Email);
            cmd.Parameters.Add(":telefone", usuario.Telefone);

            try
            {
                dr = cmd.ExecuteReader();

                retorno = true;
            }
            catch
            {
                retorno = false;
            }
            finally
            {
                if (dr != null) dr.Close();
            }

            return retorno;
        }

        public bool excluirUsuario(int idUsuario)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            bool retorno;

            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            sb.Append("DELETE FROM conta ");
            sb.Append("WHERE idUsuario = :idUsuario ");

            sb2.Append("DELETE FROM usuario ");
            sb2.Append("WHERE idUsuario = :idUsuario ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);
            OracleCommand cmd2 = new OracleCommand(sb2.ToString(), conn);

            cmd.Parameters.Add(":idUsuario", idUsuario);
            cmd2.Parameters.Add(":idUsuario", idUsuario);

            try
            {
                dr = cmd.ExecuteReader();
                dr = cmd2.ExecuteReader();

                retorno = true;
            }
            catch
            {
                retorno = false;
            }
            finally
            {
                if (dr != null) dr.Close();
            }

            return retorno;
        }

        public static DataTable fillTable(String sql)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            OracleCommand cmd = new OracleCommand(sql, conn);

            DataTable tabela = new DataTable();

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                DataTable schemaTable = dr.GetSchemaTable();
                DataColumn dcColumn;
                DataRow drRow;

                for (int i = 0; i < dr.FieldCount; i++)
                {
                    dcColumn = new DataColumn();
                    dcColumn.ColumnName = schemaTable.Rows[i]["ColumnName"].ToString();
                    tabela.Columns.Add(dcColumn);
                }

                while (dr.Read())
                {
                    drRow = tabela.NewRow();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        drRow[i] = dr.GetValue(i);
                    }
                    tabela.Rows.Add(drRow);
                }
            }
            catch (Exception e) { return null; }
            finally { if (dr != null) dr.Close(); }

            return tabela;
        }
    }
}