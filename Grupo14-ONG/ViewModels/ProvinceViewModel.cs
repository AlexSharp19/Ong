using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.ViewModels
{
    public class ProvinceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProvinceViewModel()
        {

        }

        public ProvinceViewModel(Province province)
        {
            this.Id = province.Id;
            this.Name = province.Name;
        }

        public Province ToEntity()
        {
            Province province = new Province();

            province.Id = Id;
            province.Name = Name;

            return province;
        }
    }
}