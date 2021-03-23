using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo14_ONG_DA.ModelsEF
{
    public class ONGtype
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ONGpartner> ONGpartners { get; set; }
    }
}
