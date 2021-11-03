using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIAgriSus.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string login { get; set; }

        [Required]
        public string senha { get; set; }
    }
}
