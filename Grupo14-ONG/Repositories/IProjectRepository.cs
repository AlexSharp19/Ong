using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo14_ONG.Repositories
{
    public interface IProjectRepository: IGenericRepository<Project>
    {
        List<Project> GetAll(bool isActive);

        void InsertMultiMediaProject(List<MultiMedia> ListMultiMedia, int IdProject);

        void UpdateMultimedias(List<MultiMedia> l, int ProjectId);

    }
}
