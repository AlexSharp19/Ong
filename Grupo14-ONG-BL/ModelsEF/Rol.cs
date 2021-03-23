using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo14_ONG_DA.ModelsEF
{
    public class Rol
    {
        public string name { get; set; }
        public int Id { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
