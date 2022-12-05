using LojaGames.Classes.BAS;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;

namespace LojaGames.Classes.DAO
{
    public class DaoLogin
    {
        public DaoLogin()
        {

        }
        public Conta buscarLogin(Conta conta)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = XE; PASSWORD = admin; USER ID = system");
            OracleDataReader dr = null;

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT idConta, idUsuario, idTipoConta, login, senha, carteira, dataCadastro ");
            sb.Append("FROM conta ");
            sb.Append("WHERE login = :login ");
            sb.Append("AND senha = :senha");

            conn.Open();

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);

            cmd.Parameters.Add(":login", conta.Login);
            cmd.Parameters.Add(":senha", conta.Senha);

            try
            {
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    conta.IdConta = int.Parse(dr["idConta"].ToString());
                    conta.IdUsuario = int.Parse(dr["idUsuario"].ToString());
                    conta.IdTipoConta = int.Parse(dr["idTipoConta"].ToString());
                    conta.Login = dr["login"].ToString();
                    conta.Senha = dr["senha"].ToString();
                    conta.Carteira = double.Parse(dr["carteira"].ToString());
                    conta.DataCadastro = dr["dataCadastro"].ToString();
                }
            }
            finally
            {
                if (dr != null) dr.Close();
            }
            return conta;
        }
    }
}