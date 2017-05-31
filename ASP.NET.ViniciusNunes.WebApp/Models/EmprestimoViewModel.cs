using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET.ViniciusNunes.WebApp.Models
{
    public class EmprestimoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira a data de emprestimo")]
        public string dataEmprestimo { get; set; }

        [Required(ErrorMessage = "Insira a data de devolução")]
        public string dataDevolucao { get; set; }

        [Required]
        public int livroId { get; set; }
    }
}