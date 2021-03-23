using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo14_ONG_DA.ModelsEF
{
    public class ONGpartner
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string IdMercadoPago { get; set; }

        public virtual Province Province { get; set; }

        public virtual ONGtype ONGtype { get; set; }

    }
}
