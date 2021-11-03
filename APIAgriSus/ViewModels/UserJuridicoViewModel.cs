﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIAgriSus.ViewModels
{
    public class UserJuridicoViewModel
    {
        [Required]
        public string nomeUser { get; set; }
        [Required]
        public string cnpj{ get; set; }
        [Required]
        public string endereco { get; set; }
        [Required]
        public string telefone { get; set; }
    }
}