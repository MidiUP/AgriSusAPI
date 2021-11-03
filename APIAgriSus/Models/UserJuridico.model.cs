using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAgriSus.Models
{
    public class UserJuridico
    {
        public int id { get; set; }
        public string nomeUser { get; set; }
        public string cnpj { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
    }
}
