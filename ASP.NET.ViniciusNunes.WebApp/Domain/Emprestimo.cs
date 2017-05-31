using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET.ViniciusNunes.WebApp.Domain
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public string dataEmprestimo { get; set; }
        public string dataDevolucao { get; set; }
        public int livroId { get; set; }
    }
}