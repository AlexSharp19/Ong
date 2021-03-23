using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 6)]
        public string Password { get; set; }

    }
}