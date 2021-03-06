using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo14_ONG.Repositories
{
    public interface ISystemRepository
    {
       SystemONG GetSystem();
       void InsertOrUpdateSystem(SystemONG systemONG);
       void InsertOrUpdateMultiMediaSystem(List<MultiMedia> ListMultiMedia); 
    }
}
