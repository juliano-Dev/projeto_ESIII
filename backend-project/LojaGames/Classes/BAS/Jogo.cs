using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaGames.Classes.BAS
{
    public class Jogo
    {
        public int IdJogo { get; set; }
        public String NomeJogo { get; set; }
        public String Genero { get; set; }
        public String Plataforma { get; set; }
        public double Preco { get; set; }
        public String DataLancamento { get; set; }

        public Jogo()
        {

        }
    }
}