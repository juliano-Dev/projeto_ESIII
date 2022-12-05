using LojaGames.Classes.BAS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;

namespace LojaGames.Classes.DAO
{
    public class DaoJogo
    {
        public bool cadastrarJogo(Jogo jogo)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            bool retorno;

            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO jogo ");
            sb.Append("(idJogo, nomeJogo, genero, plataforma, preco, dataLancamento) ");
            sb.Append("VALUES (s_jogo.nextval, :nomeJogo, :genero, :plataforma, :preco, :dataLancamento) ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":nomeJogo", jogo.NomeJogo);
            cmd.Parameters.Add(":genero", jogo.Genero);
            cmd.Parameters.Add(":plataforma", jogo.Plataforma);
            cmd.Parameters.Add(":preco", jogo.Preco);
            cmd.Parameters.Add(":dataLancamento", jogo.DataLancamento);

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

        public bool editarJogo(Jogo jogo)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            bool retorno;

            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE jogo ");
            sb.Append("SET nomeJogo = :nomeJogo, genero = :genero, plataforma = :plataforma, preco = :preco ");
            sb.Append("WHERE idJogo = :idJogo ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":nomeJogo", jogo.NomeJogo);
            cmd.Parameters.Add(":genero", jogo.Genero);
            cmd.Parameters.Add(":plataforma", jogo.Plataforma);
            cmd.Parameters.Add(":preco", jogo.Preco);
            cmd.Parameters.Add(":idJogo", jogo.IdJogo);

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

        public bool excluirJogo(int idJogo)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            bool retorno;

            StringBuilder sb = new StringBuilder();

            sb.Append("DELETE FROM jogo ");
            sb.Append("WHERE idJogo = :idJogo ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":idJogo", idJogo);

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

        public bool removerJogoDesejo(int idJogo, int idUsuario)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            bool retorno;

            StringBuilder sb = new StringBuilder();

            sb.Append("DELETE FROM listaDesejo ");
            sb.Append("WHERE idJogo = :idJogo AND idConta = (SELECT idConta FROM conta WHERE idUsuario = :idUsuario) ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":idJogo", idJogo);
            cmd.Parameters.Add(":idUsuario", idUsuario);

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

                for(int i = 0; i < dr.FieldCount; i++)
                {
                    dcColumn = new DataColumn();
                    dcColumn.ColumnName = schemaTable.Rows[i]["ColumnName"].ToString();
                    tabela.Columns.Add(dcColumn);
                }

                while(dr.Read())
                {
                    drRow = tabela.NewRow();
                    for(int i = 0; i < dr.FieldCount; i++)
                    {
                        drRow[i] = dr.GetValue(i);
                    }
                    tabela.Rows.Add(drRow);
                }
            }
            catch(Exception e) { return null; }
            finally { if (dr != null) dr.Close(); }

            return tabela;
        }
    }
}