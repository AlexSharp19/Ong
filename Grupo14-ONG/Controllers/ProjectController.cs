using Grupo14_ONG.ViewModels;
using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Grupo14_ONG.UnitWork;
using Grupo14_ONG.Filters;
using System.Diagnostics;

namespace Grupo14_ONG.Controllers
{
    public class ProjectController : Controller
    {
        private readonly UnitOfWork uow = new UnitOfWork();

        public ActionResult Index()
        {
            List<Project> projects = new List<Project>();
            if((Grupo14_ONG_DA.ModelsEF.User)Session["User"] != null && ((Grupo14_ONG_DA.ModelsEF.User)Session["User"]).Rols.name == "Admin")
            {
                projects = uow.ProjectRepository.GetAll(); //si es user trae proyectos activos e inactivos 
            }
            else
            {
                projects = uow.ProjectRepository.GetAll(true); 
            }
    
            List<ProjectListViewModel> projectVMlist = new List<ProjectListViewModel>();

            foreach (Project project in projects)
            {
                int typeEntity = (int)TypeEntity.enumTypeEntity.Project;
                MultiMedia multimedia = uow.MultiMediaRepository.GetFirst(typeEntity, project.Id);
                
                if (multimedia != null)
                {
                    ProjectListViewModel projectVM = new ProjectListViewModel(project, multimedia);
                    projectVMlist.Add(projectVM);
                }
            }

            return View(projectVMlist);
        }


        [VerifyRole(role = "Admin")]
        [HttpGet]
        public ActionResult Create() 
        {
            return View(new ProjectViewModel());
        }


        [VerifyRole(role = "Admin")]
        [HttpPost]
        public ActionResult Create(ProjectViewModel projectViewModel)
        {
            projectViewModel.LastModified = DateTime.Now;
            projectViewModel.IsActive = true;

            if (!ModelState.IsValid)
            {
                return View(projectViewModel);
            }
            else
            {
                Project project = projectViewModel.ToEntity();
                
                project.User = uow.UserRepository.ChangeState((User)Session["User"]);
                uow.ProjectRepository.Insert(project);
                uow.Save();

                if (project.Id != 0) 
                {
                    List<MultiMedia> ListMultiMedias = new List<MultiMedia>();
                    ListMultiMedias = CommonFunctions.CommonFunctions.stringToMultimedias(projectViewModel.images);
                    uow.ProjectRepository.InsertMultiMediaProject(ListMultiMedias, project.Id);
                    uow.Save();
                }
                Debug.WriteLine("Valido el proyecto");
            }

            return RedirectToAction("Index", "Project");
        }

 
        public ActionResult Details(int id)
        {
            Project project = uow.ProjectRepository.GetById(id);

            int type = (int)TypeEntity.enumTypeEntity.Project;
            List<MultiMedia> multimedias = uow.MultiMediaRepository.GetAll(type,id);

            ProjectViewModel response = new ProjectViewModel();
            response.loadProject(project, multimedias);

            return View(response);
        }


        [VerifyRole(role = "Admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Project project = uow.ProjectRepository.GetById(id);
            int type = (int)TypeEntity.enumTypeEntity.Project;
            List<MultiMedia> multimedias = uow.MultiMediaRepository.GetAll(type, id);

            ProjectViewModel response = new ProjectViewModel();
            response.loadProject(project, multimedias);


            return View(response);
        }


        [VerifyRole(role = "Admin")]
        [HttpPost]
        public ActionResult Edit(ProjectViewModel projectViewModel)
        {
            projectViewModel.LastModified = DateTime.Now;
            //sobreescribo projecto
            if (ModelState.IsValid) 
            {
                try
                {
                    Project Project = uow.ProjectRepository.GetById(projectViewModel.Id);
                    Project = projectViewModel.ToEntityModify(Project);
                    uow.ProjectRepository.Update(Project);
                    uow.Save();

                    List<MultiMedia> newMultimedias = CommonFunctions.CommonFunctions.stringToMultimedias(projectViewModel.images);
                    uow.ProjectRepository.UpdateMultimedias(newMultimedias, Project.Id);
                    if (uow.Save())
                    {
                        Response.Write("<script>");
                        Response.Write("window.onload = function() { Swal.fire({ icon: 'success',title: 'Realizado!',text: 'El proyecto se modifico correctamente'})}");
                        Response.Write("</script>");
                        return Edit(projectViewModel.Id);
                    }
                    else
                    {
                        Response.Write("<script>");
                        Response.Write("window.onload = function() { Swal.fire({ icon: 'error',title: 'Error!',text: 'El proyecto no pudo ser modificado'})}");
                        Response.Write("</script>");
                        return View(projectViewModel);
                    }
                 
                }
                catch (Exception)
                {
                    return View(projectViewModel);
                }

            }
            else
            {
                return View(projectViewModel);
            }
     
        }

        protected override void Dispose(bool disposing)
        {
            uow.Dispose();
            base.Dispose(disposing);
        }
    }
}
