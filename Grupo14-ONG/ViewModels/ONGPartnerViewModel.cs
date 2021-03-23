using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.ViewModels
{
    public class ONGPartnerViewModel
    {
        public int Id { get; set; }

        [Required, Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required, Display(Name = "Direccion")]
        public string Address { get; set; }

        [Required, Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required, Display(Name = "Ciudad")]
        public string City { get; set; }

        [Required, Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Required, Display(Name = "Id MercadoPago")]
        public string IdMercadoPago { get; set; }



        public List<ProvinceViewModel> Provinces { get; set; }

        [Required(ErrorMessage = "Seleccione una Provincia"), Display(Name = "Provincia")]
        public int selectedProvince { get; set; }


        public List<ONGtypeViewModel> ONGtypes { get; set; }


        [Required(ErrorMessage = "Seleccione un tipo de ONG"), Display(Name = "Tipo ONG")]
        public int selectedONGType { get; set; }


        [Required]
        public string images { get; set; }
        /*Receives model Project and return the 
        ProjectViewModel with the loaded data.*/
        public List<MultiMediaViewModel> multimediaList { get; set; }

        [Display(Name = "Mostrar en Web")]
        public bool IsActive { get; set; }


        public ProvinceViewModel Province { get; set; }
        public ONGtypeViewModel ONGtype { get; set; }


        public ONGPartnerViewModel()
        {

        }



        public void LoadONGPartnerViewModel(ONGpartner partner, List<MultiMedia> multiMedias)
        {
            this.Id = partner.Id;
            this.Name = partner.Name;
            this.Address = partner.Address;
            this.Phone = partner.Phone;
            this.Email = partner.Email;
            this.City = partner.City;
            this.Description = partner.Description;
            this.IdMercadoPago = partner.IdMercadoPago;
            this.selectedProvince = partner.Province.Id;
            this.selectedONGType = partner.ONGtype.Id;
            this.ONGtype = new ONGtypeViewModel(partner.ONGtype);
            this.Province = new ProvinceViewModel(partner.Province);
            this.multimediaList = new List<MultiMediaViewModel>();
            this.loadMultimedias(multiMedias);
            this.IsActive = partner.IsActive;
        }


        public void loadMultimedias(List<MultiMedia> l)
        {
            foreach (MultiMedia item in l)
            {
                this.multimediaList.Add(new MultiMediaViewModel(item));
            }

        }

        public ONGpartner ToEntity()
        {
            ONGpartner partner = new ONGpartner();

            partner.Id = Id;
            partner.Name = Name;
            partner.Address = Address;
            partner.Phone = Phone;
            partner.Email = Email;
            partner.City = City;
            partner.Description = Description;
            partner.IdMercadoPago = IdMercadoPago;
            partner.IsActive = IsActive;
    

            return partner;
        }
    }
}