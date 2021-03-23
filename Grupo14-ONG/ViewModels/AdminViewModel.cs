using Grupo14_ONG_DA.ModelsEF;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Grupo14_ONG.ViewModels
{
    public class AdminViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="URL obligatoria")]
        public string UrlLogo { get; set; }

        [Required(ErrorMessage ="Telefono obligatorio")]
        [RegularExpression ("[0-9]*" , ErrorMessage ="Caracteres no validos")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Direccion obligatoria")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Mensaje de bienvenida obligatorio")]
        public string WelcomeMessage { get; set; }

        [Required(ErrorMessage = "URL imagen obligatoria")]

        public string images { get; set; }
        public virtual List<MultiMediaViewModel> ListMultiMediaViewModel { get; set; }


        public AdminViewModel()
        {

        }
        public AdminViewModel(SystemONG systemONG,List<MultiMediaViewModel> multiMediaViewModels)
        {
            Id = systemONG.Id;
            UrlLogo = systemONG.UrlLogo;
            Phone = systemONG.Phone;
            Adress = systemONG.Adress;
            WelcomeMessage = systemONG.WelcomeMessage;
            ListMultiMediaViewModel = multiMediaViewModels;
        }

        public SystemONG toEntity()
        {
            SystemONG systemONG = new SystemONG
            {
                Id = this.Id,
                UrlLogo = this.UrlLogo,
                Phone = this.Phone,
                Adress = this.Adress,
                WelcomeMessage = this.WelcomeMessage,
                LastModified = System.DateTime.Now,
                User = null
            };
            return systemONG;
        }
       
    }

}