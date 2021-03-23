using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Grupo14_ONG_DA.ModelsEF
{   
    public class MultiMedia
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public string TypeFile { get; set; } 

        public virtual ICollection<EntityMultimedia> EntityMultimedias { get; set; }
        
    }
}