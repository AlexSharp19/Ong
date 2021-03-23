using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo14_ONG_DA.ModelsEF
{
    public class TypeEntity
    {
        public int Id { get; set; }


        public string Description { get; set; }


        public bool Active { get; set; }

        public virtual ICollection<EntityMultimedia> EntityMultimedias { get; set; }

        public enum enumTypeEntity
        {
            ONG = 1,
            Project = 2,
            ONGPartner = 3,
        }
    }
}
