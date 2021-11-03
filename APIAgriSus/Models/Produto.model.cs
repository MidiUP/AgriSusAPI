using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIAgriSus.Models
{
    public class Produto
    {
        [Key()]
        public int id { get; set; }

        [Required]
        [ForeignKey("Agricultor")]
        public int AgricultorId { get; set; }
        public virtual Agricultor Agricultor { get; set; }

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
