using Grupo14_ONG_DA.ModelsEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.ViewModels
{
    public class MultiMediaViewModel
    {

        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string AlterText { get; set; }
        public string TypeFile { get; set; }
        public MultiMediaViewModel()
        {
            this.AlterText = "Multimedia ONG";
        }

        public MultiMediaViewModel(MultiMedia multiMedia)
        {
            this.Id = multiMedia.Id;
            this.TypeFile = multiMedia.TypeFile;
            this.Url = multiMedia.Url;
            this.AlterText = "Multimedia ONG";
        }
        public MultiMedia ToEntity()
        {
            MultiMedia multiMedia = new MultiMedia();
            multiMedia.Id = Id;
            multiMedia.Url = Url;
            return multiMedia;
        }
    }
}