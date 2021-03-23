using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Grupo14_ONG_DA.ModelsEF;
using Newtonsoft.Json;

namespace Grupo14_ONG.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nombre Proyecto")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
        [Required]
        public string images { get; set; }
        /*Receives model Project and return the 
        ProjectViewModel with the loaded data.*/
        public List<MultiMediaViewModel> multimediaList{get;set;}
        public bool IsActive { get; set; }

        [Required]
        public DateTime LastModified { get; set; }

        public void loadProject(Project p, List<MultiMedia> l) {
            this.Id = p.Id;
            this.Description = p.Description;
            this.IsActive = p.IsActive;
            this.LastModified = p.LastModified;
            this.Name = p.Name;
            this.multimediaList = new List<MultiMediaViewModel>();
            this.loadMultimedias(l);
        }

        public void loadMultimedias(List<MultiMedia> l) {
            foreach (MultiMedia item in l)
            {
                this.multimediaList.Add(new MultiMediaViewModel(item));
            }

        }
        public Project ToEntityModify(Project u)
        {
            u.Name = this.Name;
            u.Description = this.Description;
            u.IsActive = this.IsActive;
            u.LastModified = this.LastModified;
            return u;
        }
        public Project ToEntity()
        {
            Project project = new Project();
            
            project.Id = Id;
            project.Name = Name;
            project.Description = Description;
            project.IsActive = IsActive;
            project.LastModified = LastModified;

            return project;
        }

    }
}