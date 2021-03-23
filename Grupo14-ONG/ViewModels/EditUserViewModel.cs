using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.ViewModels
{
    public class EditUserViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo letras")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo letras")]
        public string LastName { get; set; }

        [StringLength(16,MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public EditUserViewModel(User oUser)
        {
            this.Id = oUser.Id;
            this.Name = oUser.Name;
            this.LastName = oUser.LastName;
            this.Email = oUser.Email;
        }

        public User ToEntity()
        {
            User user = new User();
            user.Name = this.Name;
            user.LastName = this.LastName;
            user.Email = this.Email;
            return user;
        }
        public User ToEntityModify(User u)
        {
            u.Name = this.Name;
            u.LastName = this.LastName;
            u.Email = this.Email;
            return u;
        }
        public EditUserViewModel()
        {

        }

    }
}