using Grupo14_ONG.Filters;
using Grupo14_ONG.UnitWork;
using Grupo14_ONG.ViewModels;
using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupo14_ONG.Controllers
{
    public class OngPartnerController : Controller
    {
        private readonly UnitOfWork uow = new UnitOfWork();
        public ActionResult Index()
        {
            List<ONGpartner> Partners = new List<ONGpartner>();
            Partners = uow.OngPartnerRepository.GetAll(true);
            if (Session["User"] != null && ((User)Session["User"]).Rols.name == "Admin") {

               
                Partners = uow.OngPartnerRepository.GetAll();


            }



            List<ONGPartnerListViewModel> PartnersViewModel = new List<ONGPartnerListViewModel>();

            foreach (ONGpartner Partner in Partners)
            {

                int type = (int)TypeEntity.enumTypeEntity.ONGPartner;
                MultiMedia multimedia = uow.MultiMediaRepository.GetFirst(type, Partner.Id);

                if (multimedia != null)
                {
                    ONGPartnerListViewModel partnerVM = new ONGPartnerListViewModel(Partner, multimedia);
                    PartnersViewModel.Add(partnerVM);
                }

            }

            return View(PartnersViewModel);
        }

        public ActionResult Details(int id)
        {

            ONGpartner ong = uow.OngPartnerRepository.GetById(id);
            if (ong != null)
            {
                int type = (int)TypeEntity.enumTypeEntity.ONGPartner;
                List<MultiMedia> multimedias = uow.MultiMediaRepository.GetAll(type, id);

                ONGPartnerViewModel response = new ONGPartnerViewModel();
                response.LoadONGPartnerViewModel(ong, multimedias);


                return View(response);
            }


            return RedirectToAction("Index", "OngPartner");
        }



        [VerifyRole(role = "Admin")]
        public ActionResult Create()
        {
            ONGPartnerViewModel vm = new ONGPartnerViewModel();


            // PROVINCE
            List<Province> ListProv = uow.ProvinceRepository.GetAll();
            List<ProvinceViewModel> ListprovinceViewModels = new List<ProvinceViewModel>();

            foreach (Province p in ListProv)
            {
                ProvinceViewModel pvm = new ProvinceViewModel(p);

                ListprovinceViewModels.Add(pvm);

            }

            vm.Provinces = ListprovinceViewModels;

            // ONGType

            List<ONGtype> ListONGtype = uow.ONGTypeRepository.GetAll();
            List<ONGtypeViewModel> ListONGtypeVM = new List<ONGtypeViewModel>();

            foreach (ONGtype i in ListONGtype)
            {
                ONGtypeViewModel Ovm = new ONGtypeViewModel(i);

                ListONGtypeVM.Add(Ovm);


            }
            vm.ONGtypes = ListONGtypeVM;

            return View(vm);
        }


        [HttpPost, VerifyRole(role = "Admin")]
        public ActionResult Create(ONGPartnerViewModel vm)
        {

            ONGpartner Ong = vm.ToEntity();
            Ong.ONGtype = uow.ONGTypeRepository.GetById(Convert.ToInt32(vm.selectedONGType));
            Ong.Province = uow.ProvinceRepository.GetById(Convert.ToInt32(vm.selectedProvince));

            if (!ModelState.IsValid)
            {

                return View(vm);
            }
            else
            {


                uow.OngPartnerRepository.Insert(Ong);
                uow.Save();

                if (Ong.Id != 0)
                {
                    List<MultiMedia> ListMultiMedias = new List<MultiMedia>();
                    ListMultiMedias = CommonFunctions.CommonFunctions.stringToMultimedias(vm.images);
                    uow.OngPartnerRepository.InsertMultiMediaOngPartner(ListMultiMedias, Ong.Id);
                    uow.Save();


                }

                return RedirectToAction("Index", "OngPartner");
            }


        }




        public ActionResult Edit(int id)
        {
            ONGpartner Ong = uow.OngPartnerRepository.GetById(id);
            if (Ong != null)
            {
                int type = (int)TypeEntity.enumTypeEntity.ONGPartner;
                List<MultiMedia> multimedias = uow.MultiMediaRepository.GetAll(type, id);

                ONGPartnerViewModel response = new ONGPartnerViewModel();
                response.LoadONGPartnerViewModel(Ong, multimedias);





                // PROVINCE
                List<Province> ListProv = uow.ProvinceRepository.GetAll();
                List<ProvinceViewModel> ListprovinceViewModels = new List<ProvinceViewModel>();

                foreach (Province p in ListProv)
                {
                    ProvinceViewModel pvm = new ProvinceViewModel(p);

                    ListprovinceViewModels.Add(pvm);

                }

                response.Provinces = ListprovinceViewModels;

                // ONGType

                List<ONGtype> ListONGtype = uow.ONGTypeRepository.GetAll();
                List<ONGtypeViewModel> ListONGtypeVM = new List<ONGtypeViewModel>();

                foreach (ONGtype i in ListONGtype)
                {
                    ONGtypeViewModel Ovm = new ONGtypeViewModel(i);

                    ListONGtypeVM.Add(Ovm);


                }
                response.ONGtypes = ListONGtypeVM;





                return View(response);
            }

            return RedirectToAction("Index", "OngPartner");
        }

        [HttpPost]
        public ActionResult Edit(ONGPartnerViewModel vm)
        {
            if (!ModelState.IsValid)
            {
               // vm.multimediaList = CommonFunctions.CommonFunctions.stringToMultimedias(vm.images);
                return View(vm);
            }
            else
            {

                ONGpartner Ong = vm.ToEntity();
                Ong.ONGtype = uow.ONGTypeRepository.GetById(Convert.ToInt32(vm.selectedONGType));
                Ong.Province = uow.ProvinceRepository.GetById(Convert.ToInt32(vm.selectedProvince));
                uow.OngPartnerRepository.Update(Ong);
                uow.Save();
                if (Ong.Id != 0)
                {
                    List<MultiMedia> newMultimedias = CommonFunctions.CommonFunctions.stringToMultimedias(vm.images);
                    uow.OngPartnerRepository.UpdateMultiMediaOngPartner(newMultimedias, Ong.Id);
                    if (uow.Save())
                    {
                        Response.Write("<script>");
                        Response.Write("window.onload = function() { Swal.fire({ icon: 'success',title: 'Realizado!',text: 'El proyecto se modifico correctamente'})}");
                        Response.Write("</script>");
                        return RedirectToAction("Index", "OngPartner");
                    }
                    else
                    {
                        Response.Write("<script>");
                        Response.Write("window.onload = function() { Swal.fire({ icon: 'error',title: 'Error!',text: 'El proyecto no pudo ser modificado'})}");
                        Response.Write("</script>");
                        return View(vm);
                    }

                }
            }
            return View(vm);
        }


    }
}