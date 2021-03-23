using Grupo14_ONG_DA.DataAccess;
using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.Repositories.Implements
{
    public class RolRepository: GenericRepository<Rol>, IRolRepository
    {
        public RolRepository(Context context) : base(context)
        {

        }
    }
}