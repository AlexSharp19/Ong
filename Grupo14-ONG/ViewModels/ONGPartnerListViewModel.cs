using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.ViewModels
{
    public class ONGPartnerListViewModel
    {
        public int Id { get; set; }
        public MultiMediaViewModel Image { get; set; }
        public string Name { get; set; }
        public string ONGType { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ONGPartnerListViewModel()
        {

        }

        public ONGPartnerListViewModel(ONGpartner partner, MultiMedia multiMedia)
        {
            this.Id = partner.Id;
            this.Name = partner.Name;
            this.ONGType = partner.ONGtype.Name;
            this.Description = partner.Description;
            this.Image = new MultiMediaViewModel(multiMedia);
            this.IsActive = partner.IsActive;
        }
    }
}