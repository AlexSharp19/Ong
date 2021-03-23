using Grupo14_ONG_DA.ModelsEF;
using System.Runtime.Remoting.Contexts;

namespace Grupo14_ONG.Repositories.Implements
{
    public class ONGtypeRepository : GenericRepository<ONGtype>, IOngTypeRepository
    {


        public ONGtypeRepository(Grupo14_ONG_DA.DataAccess.Context context) : base(context)
        {
        }
    }
}