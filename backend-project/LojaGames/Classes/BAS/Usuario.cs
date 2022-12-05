using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaGames.Classes.BAS
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public String NomeUsuario { get; set; }
        public String DataNascimento { get; set; }
        public String Email { get; set; }
        public String Cpf { get; set; }
        public String Telefone { get; set; }

        public Usuario()
        {

        }

        public Usuario(string nomeUsuario, string dataNascimento, string email, string cpf, string telefone)
        {
            NomeUsuario    = nomeUsuario;
            DataNascimento = dataNascimento;
            Email          = email;
            Cpf            = cpf;
            Telefone       = telefone;
        }
    }
}