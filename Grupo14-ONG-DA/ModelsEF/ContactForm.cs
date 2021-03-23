using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo14_ONG_DA.ModelsEF
{
    public class ContactForm
    {
            
            public int Id { get; set; }
            [Required]
            [StringLength(255)]
            public string Name  { get; set; }
            
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            
            [Required]
            [StringLength(255)]
            public string Subject { get; set; }
            
            [Required]
            public string Text { get; set; }
            
    }
}
