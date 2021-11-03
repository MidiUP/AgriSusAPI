﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIAgriSus.ViewModels
{
    public class userfisicoViewModel
    {
        [Required]
        public string nome { get; set; }
        [Required]
        public string cpf { get; set; }
        [Required]
        public string endereco { get; set; }
        [Required]
        public string telefone { get; set; }
        [Required]
        public string senha { get; set; }
    }
}
