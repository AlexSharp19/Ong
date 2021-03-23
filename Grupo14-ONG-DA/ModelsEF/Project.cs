using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo14_ONG_DA.ModelsEF
{
    public class Project
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]  
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime LastModified { get; set; }

        public User User { get; set; }

        
    }
}
