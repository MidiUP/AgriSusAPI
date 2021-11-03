using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIAgriSus.ViewModels
{
    public class ProdutoViewModel
    {


        [Required]
        public int AgricultorId { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public double quantidade { get; set; }

        [Required]
        public double valor { get; set; }

        [Required]
        public string descricao { get; set; }

    }
}

