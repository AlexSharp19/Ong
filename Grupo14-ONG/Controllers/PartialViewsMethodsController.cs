using Grupo14_ONG.ViewModels;
using System;
using System.Web.Mvc;
using Grupo14_ONG.UnitWork;
using Grupo14_ONG_DA.ModelsEF;

namespace Grupo14_ONG.Controllers
{
    public class PartialViewsMethodsController : Controller
    {

        private readonly UnitOfWork unitOfWork = new UnitOfWork();
        private readonly SystemONG systemONG;
        public PartialViewsMethodsController()
        {
            systemONG = unitOfWork.SystemRepository.GetSystem();
        }

        [ChildActionOnly]
        public PartialViewResult _PartialFooter()
        {      
           
            PartialFooterViewModel partialFooterViewModel = new PartialFooterViewModel(systemONG);
           
            return PartialView("_PartialFooter", partialFooterViewModel);
        }

        [ChildActionOnly]
        public PartialViewResult _PartialHeader()
        {

            PartialHeaderViewModel partialHeaderViewModel = new PartialHeaderViewModel(systemONG);
          
            return PartialView("_PartialHeader", partialHeaderViewModel);
        }
    }
}