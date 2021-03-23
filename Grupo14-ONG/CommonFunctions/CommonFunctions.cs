using Grupo14_ONG.ViewModels;
using Grupo14_ONG_DA.ModelsEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.CommonFunctions
{
    public class CommonFunctions
    {
        public static List<MultiMedia> stringToMultimedias(string multiMedias)
        {
            List<MultiMedia> response = new List<MultiMedia>();

            response = JsonConvert.DeserializeObject<List<MultiMedia>>(multiMedias);

            return response;
        }

    }
}