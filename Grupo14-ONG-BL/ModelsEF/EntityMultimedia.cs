using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo14_ONG_DA.ModelsEF
{
    public class EntityMultimedia
    {
        public int Id { get; set; }
        
        public virtual TypeEntity TypeEntity { get; set; }

        public int EntityId { get; set; }

        public virtual MultiMedia MultiMedia { get; set; }

    }
}
