using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.ViewModels
{
    public class HomeViewModel
    {

        public string Address { get; set; }

        public string Phone { get; set; }

        public string WelcomeText { get; set; }

        public List<MultiMediaViewModel> SlideImg { get; set; }


       public List<ProjectListViewModel> Projects { get; set; }

        public HomeViewModel(SystemONG systemONG , List<MultiMediaViewModel> listMultiMediaFiles)
        {
            Address = systemONG.Adress;
            Phone = systemONG.Phone;
            WelcomeText = systemONG.WelcomeMessage;
            SlideImg = listMultiMediaFiles; 
        }

    }
}