using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET.ViniciusNunes.WebApp.Models
{
    public class LivroViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]        
        public string Nome { get; set; }

        [Required]
        [StringLength(60)]        
        public string Autor { get; set; }

        [Required]
        [StringLength(60)]        
        public string Editora { get; set; }

        [Required]
        [StringLength(4, ErrorMessage = "Ano deve conter 4 dígitos")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Ano deve conter apenas números")]
        public string Ano { get; set; }

        public bool Emprestado { get; set; }
    }
}