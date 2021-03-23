using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo14_ONG.Repositories
{
    public interface IMultiMediaRepository : IGenericRepository<MultiMedia>
    {
        void Insert(MultiMedia Obj, int TypeEntityId, int EntityId);

        List<MultiMedia> GetAll(int TypeEntityId, int EntityId);

        void Update(MultiMedia Obj, int TypeEntityId, int EntityId);

       MultiMedia GetFirst( int TypeEntityId, int EntityId);

       MultiMedia DefaultMultiMedia();

    }
}
