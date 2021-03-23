using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.ViewModels
{
    public class PartialFooterViewModel
    {
        public string Address { get; set; }

        public string DateOfTheDay { get; set; }

        public string UrlLogo { get; set; }

        public string Phone { get; set; }

        public PartialFooterViewModel(SystemONG systemONG)
        {
            Address = systemONG.Adress;
            DateOfTheDay = (DateTime.Now).ToString("dd-M-yyyy");
            UrlLogo = systemONG.UrlLogo;
            Phone = systemONG.Phone;

        }
    }
}