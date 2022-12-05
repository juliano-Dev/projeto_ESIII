using LojaGames.Classes.BAS;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;

namespace LojaGames.Classes.DAO
{
    public class DaoConta
    {
        public void cadastrarConta(Conta conta, int idUsuario)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;

            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO conta ");
            sb.Append("(idConta, idUsuario, idTipoConta, login, senha, carteira, dataCadastro) ");
            sb.Append("VALUES (s_conta.nextval, :idUsuario, :idTipoConta, :login, :senha, :carteira, :dataCadastro) ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":idUsuario", idUsuario);
            cmd.Parameters.Add(":idTipoConta", conta.IdTipoConta);
            cmd.Parameters.Add(":login", conta.Login);
            cmd.Parameters.Add(":senha", conta.Senha);
            cmd.Parameters.Add(":carteira", conta.Carteira);
            cmd.Parameters.Add(":dataCadastro", conta.DataCadastro);

            try
            {
                dr = cmd.ExecuteReader();
            }
            finally
            {
                if (dr != null) dr.Close();
            }
        }

        public bool editarConta(Conta conta, int idUsuario)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            bool retorno;

            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE conta ");
            sb.Append("SET login = :login, senha = :senha ");
            sb.Append("WHERE idUsuario = :idUsuario ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":login", conta.Login);
            cmd.Parameters.Add(":senha", conta.Senha);
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

        public bool comprarJogo(int idJogo, int idUsuario)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            bool retorno;

            double carteira = buscaCarteira(idUsuario);
            double preco = buscaPreco(idJogo);

            if (carteira > preco)
            {
                double novaCarteira = carteira - preco;

                StringBuilder sb = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();

                sb.Append("INSERT INTO biblioteca ");
                sb.Append("(idBiblioteca, idConta, idJogo, dataAquisicao) ");
                sb.Append("VALUES (s_biblioteca.nextval, (SELECT idConta FROM conta WHERE idUsuario = :idUsuario), :idJogo, sysdate) ");

                sb2.Append("UPDATE conta ");
                sb2.Append("SET carteira = :novaCarteira ");
                sb2.Append("WHERE idUsuario = :idUsuario ");

                conn.Open();

                OracleCommand cmd = new OracleCommand(sb.ToString(), conn);
                OracleCommand cmd2 = new OracleCommand(sb2.ToString(), conn);

                cmd.Parameters.Add(":idUsuario", idUsuario);
                cmd.Parameters.Add(":idJogo", idJogo);
                cmd2.Parameters.Add(":novaCarteira", novaCarteira);
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
            } else
            {
                retorno = false;
            }

            return retorno;
        }

        public bool addDesejo(int idJogo, int idUsuario)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            bool retorno;

            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO listaDesejo ");
            sb.Append("(idListaDesejo, idConta, idJogo, dataAdicao) ");
            sb.Append("VALUES (s_listaDesejo.nextval, (SELECT idConta FROM conta WHERE idUsuario = :idUsuario), :idJogo, sysdate) ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":idUsuario", idUsuario);
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

        public double buscaCarteira(int idUsuario)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            double carteira = 0;

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT carteira ");
            sb.Append("FROM conta ");
            sb.Append("WHERE idUsuario = :idUsuario ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":idUsuario", idUsuario);

            try
            {
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    carteira = double.Parse(dr["carteira"].ToString());
                }
            }
            finally
            {
                if (dr != null) dr.Close();
            }

            return carteira;
        }

        public double buscaPreco(int idJogo)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            double preco = 0;

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT preco ");
            sb.Append("FROM jogo ");
            sb.Append("WHERE idJogo = :idJogo ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":idJogo", idJogo);

            try
            {
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    preco = double.Parse(dr["preco"].ToString());
                }
            }
            finally
            {
                if (dr != null) dr.Close();
            }

            return preco;
        }

        public bool adcFundos(int idUsuario, double adcFundos)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;
            bool retorno;

            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE conta ");
            sb.Append("SET carteira = (carteira + :adcFundos) ");
            sb.Append("WHERE idConta = (SELECT idConta FROM conta WHERE idUsuario = :idUsuario) ");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":adcFundos", adcFundos);
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
    }
}