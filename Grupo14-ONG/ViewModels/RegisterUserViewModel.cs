using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Grupo14_ONG_DA.ModelsEF;

namespace Grupo14_ONG.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Ingrese un nombre"),Display(Name ="Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ingrese un apellido"), Display(Name = "Apellido")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress,ErrorMessage ="El formato del Email no es correcto"), Required(ErrorMessage ="Ingrese un email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Ingrese una contraseña"),DataType(DataType.Password, ErrorMessage = "Minimo 6 caracteres, maximo 16 caracteres"), Display(Name = "Contraseña")]
        public string Password { get; set; }


        [StringLength(16, MinimumLength = 6), Compare("Password",ErrorMessage ="Las contraseñas no coinciden"),Required(ErrorMessage = "Confirmar contraseña"), DataType(DataType.Password),Display(Name = "Confirmar contraseña")]
        public string Password2 { get; set; }

        public List<Rol> Rols { get; set; }

        [Required(ErrorMessage = "Seleccione un rol"), Display(Name = "Rol")]
        public string selectedRol { get; set; }
        public bool isActive { get; set; } = true;
        public User ToEntity() {

            return new User()
            {
                Email = this.Email,
                Password = this.Password,
                Name = this.Name,
                LastName = this.LastName,
                IsActive = this.isActive
            };
        }

    }

    
}