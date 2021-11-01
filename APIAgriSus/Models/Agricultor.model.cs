using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAgriSus.Models
{
    public class Agricultor
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string cnpj { get; set; }

        public string endereco { get; set; }

        public string telefone { get; set; }

        public float avaliacao { get; set; }

        public float numeroDeAvaliacao { get; set; }

        public string motivacao { get; set; }

        public string imagem { get; set; }



    }
}
