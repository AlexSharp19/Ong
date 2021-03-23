using Grupo14_ONG.Filters;
using Grupo14_ONG.Models.ViewModels;
using Grupo14_ONG.Security;
using Grupo14_ONG.UnitWork;
using Grupo14_ONG.ViewModels;
using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Grupo14_ONG.Controllers
{

    public class UserController : Controller
    {

        private readonly UnitOfWork uow = new UnitOfWork();

        // GET: User
        public ActionResult Index()
        {
            var users = new List<User>();
            users = uow.UserRepository.GetAll();
           
            List<UserViewModel> userVMlist = new List<UserViewModel>();

            foreach (User u in users)
            {
                UserViewModel userVM = new UserViewModel(u);
                userVMlist.Add(userVM);
            }

            List<UserViewModel> listVM = new List<UserViewModel>(userVMlist);
            return View(listVM);
        }

        [VerifyLogin]
        public ActionResult Login()
        {
            
            return View();
        }

        [VerifyLogin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                User oUser = uow.UserRepository.GetLogin(model.Email);
                string pass = EncryptDecrypt.EncryptPlainTextToCipherText(model.Password);
                if (oUser != null)
                {
                    if (oUser.Password == pass)
                    {
                        Session["User"] = oUser;
                    }
                    if (Session["User"] != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                   
                    Response.Write("<script>");
                    Response.Write("window.onload = function() { Swal.fire({ icon: 'error',title: 'Error Usuario!',text: 'Datos no Correctos'})}");
                    Response.Write("</script>");

                }
                else
                {
                    Response.Write("<script>");
                    Response.Write("window.onload = function() { Swal.fire({ icon: 'error',title: 'Error Usuario!',text: 'Usuario no Existe'})}");
                    Response.Write("</script>");
                }
            }

            return View(model);

        }

        [VerifyRole(role = "Admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            User oUser = uow.UserRepository.GetById(id);
            EditUserViewModel model = new EditUserViewModel(oUser);
            return View(model);
        }

        [VerifyRole(role = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                try
                {
                    User oUser = uow.UserRepository.GetById(model.Id);
                    oUser = model.ToEntityModify(oUser);
                    if (model.Password != null && model.Password.Trim() != "")
                    {
                        oUser.Password = EncryptDecrypt.EncryptPlainTextToCipherText(model.Password);
                    }
                    uow.UserRepository.Update(oUser);
                    if (uow.Save())
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                catch(Exception ex)
                {
                    Response.Write("<script>alert('" + Server.HtmlEncode("Ocurrio un error"+ex.Message) + "')</script>");
                }
              
             
            }
            return View(model);       
        }

        [VerifyRole(role = "Admin")]
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            User usuario = uow.UserRepository.GetById(Id);
            if (usuario != null)
            {
                usuario.IsActive = false;
                uow.UserRepository.Update(usuario);
                uow.Save();
                Response.Write("<script>");
                Response.Write("window.onload = function() { Swal.fire({ icon: 'error',title: 'Error Usuario!',text: 'Datos no Correctos'})}");
                Response.Write("</script>");
            }
            return RedirectToAction("Index", "User");
        }

        [VerifyRole]
        [HttpGet]
        public ActionResult Me()
        {
                UserViewModel u = new UserViewModel(((User)Session["User"]));
                return View(u);
        }


        [HttpGet]
        public ActionResult Register()
        {

            RegisterUserViewModel u = new RegisterUserViewModel();
            u.Rols = uow.RolRepository.GetAll();

            return View(u);
        }


        [HttpPost]
        public ActionResult Register(RegisterUserViewModel Vm)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User();
                newUser = Vm.ToEntity();
                newUser.Password = EncryptDecrypt.EncryptPlainTextToCipherText(newUser.Password);
                newUser.Rols = uow.RolRepository.GetById(Convert.ToInt32(Vm.selectedRol));
                uow.UserRepository.Insert(newUser);

                if (uow.Save())
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(Vm);
                }
            }
            return View(Vm);
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            uow.Dispose();
            base.Dispose(disposing);
        }

    }
}