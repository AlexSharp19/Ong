using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.ViewModels
{
    public class ProjectCreatViewModel
    {
        [Required(ErrorMessage = "Nombre del Proyecto Requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Descripción del Proyecto Requerido")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Cargar como minimo un Archivo, y como maximo cinco.")]
        public virtual List<string> MultiMedias { get; set; }
    }
}