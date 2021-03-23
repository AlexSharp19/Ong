using Grupo14_ONG_DA.ModelsEF;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Grupo14_ONG.ViewModels
{    public class CreateONGPartnerViewModel
    {
        public int Id { get; set; }

        public int Province_Id { get; set; }

        public string Province_Name { get; set; }

        public int OngType_Id { get; set; }

        public string OngType_Name { get; set; }

        [Display(Name = "Mostrar en Web")]
        public bool IsActive { get; set; }
        public List<ONGtypeViewModel> ONGtype { get; set; }
        

        [Required(ErrorMessage = "Seleccione un tipo de ONG"), Display(Name = "Tipo ONG")]
        public string selectedONGType { get; set; }
        [Required, Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required, Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Required, Display(Name = "Direccion")]
        public string Address { get; set; }

        [Required, Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required, Display(Name = "Ciudad")]
        public string City { get; set; }

        public List<ProvinceViewModel> Provinces { get; set; }

        [Required(ErrorMessage = "Seleccione una Provincia"), Display(Name = "Provincia")]
        public int selectedProvince { get; set; }




        [Required, Display(Name = "Id MercadoPago")]
        public string IdMercadoPago { get; set; }


        [Required]
        public string images { get; set; }
        /*Receives model Project and return the 
        ProjectViewModel with the loaded data.*/
        public List<MultiMediaViewModel> multimediaList { get; set; }

      


        public List<MultiMediaViewModel> MultimediasViewModels { get; set; } 

        public string UrlImg1 { get; set; }
        public string UrlImg2 { get; set; }
        public string UrlImg3 { get; set; }




        //public string[] EditUrlImg
        //{
        //    get
        //    {
        //        return UrlImg;
        //    }
        //    set
        //    {
        //        UrlImg = value;
        //    }
        //} 


        public CreateONGPartnerViewModel()
        {

        }






        public ONGpartner ToEntityModify(ONGpartner model)
        {
            model.Name = this.Name;
            model.Address = this.Address;
            model.Phone = this.Phone;
            model.Email = this.Email;
            model.City = this.City;
            model.Description = this.Description;

            return model;
        }

        public CreateONGPartnerViewModel(ONGpartner model)
        {
            this.Name = model.Name;
            this.Address = model.Address;
            this.Phone = model.Phone;
            this.Email = model.Email;
            this.City = model.City;
            this.Province_Id = model.Province.Id;
            this.Province_Name = model.Province.Name;
            this.OngType_Id = model.ONGtype.Id;
            this.OngType_Name = model.ONGtype.Name;
            this.Description = model.Description;
            this.IdMercadoPago = model.IdMercadoPago;
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