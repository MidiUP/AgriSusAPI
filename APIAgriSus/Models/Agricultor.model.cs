using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIAgriSus.Models
{
    [Index(nameof(cnpj), IsUnique = true)]
    [Index(nameof(telefone), IsUnique = true)]
    public class Agricultor
    {
        [Key()]
        [Required]
        public int id { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public string cnpj { get; set; }

        [Required]
        public string senha { get; set; }

        [Required]
        public string endereco { get; set; }

        [Required]
        public string telefone { get; set; }

        [Required]
        public float avaliacao { get; set; }

        [Required]
        public float numeroDeAvaliacao { get; set; }

        [Required]
        public string motivacao { get; set; }


        public string imagem { get; set; }




    }
}
