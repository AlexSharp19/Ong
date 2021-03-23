using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.ViewModels
{
    public class ProjectListViewModel
    {
        public int ProjectId { get; set; }

        public string Title { get; set; }

        public MultiMediaViewModel Image { get; set; }

        public ProjectListViewModel()
        {

        }

        public ProjectListViewModel(Project project, MultiMedia multimedia)
        {
            this.ProjectId = project.Id;
            this.Title = project.Name;
            this.Image = new MultiMediaViewModel(multimedia);
        }
    }
}