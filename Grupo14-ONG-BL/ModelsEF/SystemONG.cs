
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Grupo14_ONG_DA.ModelsEF
{
    public class SystemONG 
    {

        public int Id { get; set; }

        [Required]
        public string UrlLogo { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public string Adress { get; set; }
        
        [Required]       
        public string WelcomeMessage { get; set; }

        public DateTime LastModified { get; set; }

        public virtual User User { get; set; }

    }
}