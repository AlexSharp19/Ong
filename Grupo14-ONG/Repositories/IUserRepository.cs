using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo14_ONG.Repositories
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User GetLogin(string email);

        User ChangeState(User u);
    }
}
