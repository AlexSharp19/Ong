using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.ViewModels
{
    public class ONGtypeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ONGtypeViewModel()
        {

        }

        public ONGtypeViewModel(ONGtype ONGtype)
        {
            this.Id = ONGtype.Id;
            this.Name = ONGtype.Name;
        }

        public ONGtype ToEntity()
        {
            ONGtype ONGtype = new ONGtype();

            ONGtype.Id = Id;
            ONGtype.Name = Name;

            return ONGtype;
        }
    }
}