using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET.ViniciusNunes.WebApp.Domain
{
    public class LivroEmprestimo
    {
        public int Id { get; set; }
        public DateTime dataEmprestimo { get; set; }
        public DateTime dataDevolucao { get; set; }
        public int livroId { get; set; }
    }
}