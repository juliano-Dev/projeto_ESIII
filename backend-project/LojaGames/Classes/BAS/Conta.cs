using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaGames.Classes.BAS
{
    public class Conta
    {
        public int IdConta { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoConta { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        public double Carteira { get; set; }
        public String DataCadastro { get; set; }

        public Conta()
        {
        
        }
        public Conta(int tipoConta, string login, string senha)
        {
            IdTipoConta  = tipoConta;
            Login        = login;
            Senha        = senha;
            Carteira     = 0;
            DataCadastro = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}