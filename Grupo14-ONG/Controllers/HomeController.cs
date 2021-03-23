using Grupo14_ONG.ViewModels;
using SendGrid;
using System;
using System.Diagnostics;
using System.Web.Mvc;
using Grupo14_ONG.Models.mailService;
using Grupo14_ONG.UnitWork;
using Grupo14_ONG_DA.ModelsEF;
using System.Collections.Generic;
using Grupo14_ONG.Filters;


namespace Grupo14_ONG.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();
        
        public ActionResult Index()
        {
            SystemONG currentSystem = unitOfWork.SystemRepository.GetSystem();

            List<MultiMedia> multimediaList = unitOfWork.MultiMediaRepository.GetAll((int)TypeEntity.enumTypeEntity.ONG, currentSystem.Id);
            List<MultiMediaViewModel> ListMultiMediaViewModel = new List<MultiMediaViewModel>();


            if (multimediaList.Count > 0)
            {
                foreach (var multimedia in multimediaList)
                {
                    ListMultiMediaViewModel.Add(new MultiMediaViewModel(multimedia));
                }
            }
            else
            {
                ListMultiMediaViewModel.Add(new MultiMediaViewModel( unitOfWork.MultiMediaRepository.DefaultMultiMedia()));
            }
           
            
            
            HomeViewModel homeViewModel = new HomeViewModel(currentSystem, ListMultiMediaViewModel);


            List<Project> projects = new List<Project>();
             projects = unitOfWork.ProjectRepository.GetAll();


            List<ProjectListViewModel> projectVMlist = new List<ProjectListViewModel>();
	        

            foreach (Project project in projects)
            {
                int typeEntity = (int)TypeEntity.enumTypeEntity.Project;
                MultiMedia multimedia = unitOfWork.MultiMediaRepository.GetFirst(typeEntity, project.Id);

                if (multimedia != null)
                {
                    ProjectListViewModel projectVM = new ProjectListViewModel(project, multimedia);
                    projectVMlist.Add(projectVM);
                }
            }

            homeViewModel.Projects = projectVMlist;

            return View(homeViewModel);   
        }
         
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult ContactForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactForm(ContactViewModel contactViewModel)
        {
            try
            {
                sendMailModel mail = new sendMailModel(contactViewModel);

                Response result = Services.mailService.sendMailNotification(mail).Result;

                if (result.IsSuccessStatusCode)
                {
                    return View();
                }
                else
                {
                    ModelState.AddModelError("errorContact", "No se ha podido enviar el mensaje");
                    return RedirectToAction("ContactForm");
                }                
            }
            catch (Exception)
            {
                ModelState.AddModelError("errorContact", "No se ha podido enviar el mensaje");
                return RedirectToAction("ContactForm");
            }
        }

        [VerifyRole(role = "Admin")] 
        [HttpGet]
        public ActionResult Admin()
        {
            Debug.WriteLine("admin inicial");
            SystemONG currentSystem = unitOfWork.SystemRepository.GetSystem();

            List<MultiMedia> ListMultiMedias = unitOfWork.MultiMediaRepository.GetAll((int)TypeEntity.enumTypeEntity.ONG, currentSystem.Id);
            List<MultiMediaViewModel> ListMultiMediaViewModel = new List<MultiMediaViewModel>();
          
            if (ListMultiMedias.Count > 0)
            {
                foreach (var item in ListMultiMedias)
                {
                    ListMultiMediaViewModel.Add(new MultiMediaViewModel(item));
                }
            }
               
            AdminViewModel adminViewModel = new AdminViewModel(currentSystem, ListMultiMediaViewModel);
            
            return View(adminViewModel);
        }
        [VerifyRole(role = "Admin")]
        [HttpPost]
        public ActionResult Admin(AdminViewModel adminViewModel)
        {
          
            if (!ModelState.IsValid){
                
                return View(adminViewModel);
            }
            else{

                 List<MultiMedia> ListMultiMedia = CommonFunctions.CommonFunctions.stringToMultimedias(adminViewModel.images);

                //Actualizo los datos de la base de datos.
                unitOfWork.SystemRepository.InsertOrUpdateSystem(adminViewModel.toEntity());
                unitOfWork.Save();

                unitOfWork.SystemRepository.InsertOrUpdateMultiMediaSystem(ListMultiMedia);
                unitOfWork.Save();

                Debug.WriteLine("Datos validos");
                return RedirectToAction("Index");
            }
        }

      

    }
}