using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET.ViniciusNunes.WebApp.Domain
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Ano { get; set; }
        public bool Emprestado { get; set; }
    }
}