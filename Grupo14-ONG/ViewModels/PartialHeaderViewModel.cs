using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.ViewModels
{
    public class PartialHeaderViewModel
    {
        public string UrlLogo { get; set; }

        public PartialHeaderViewModel(SystemONG systemONG)
        {
            UrlLogo = systemONG.UrlLogo;
        }
    }
}