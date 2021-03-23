using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo14_ONG_DA.ModelsEF
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<SystemONG> SystemONG { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual Rol Rols { get; set; }
    }

}