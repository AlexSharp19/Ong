using Grupo14_ONG_DA.DataAccess;
using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.Repositories.Implements
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {

        public UserRepository(Context context) : base(context)
        {

        }

        public User GetLogin(string email)
        {
            var lst = context.Users.Include("Rols").FirstOrDefault(x => x.Email == email && x.IsActive == true);

            User oUser = lst;
            
            return oUser;
        }

        public User ChangeState(User u)
        {         
            context.Entry(u).State = System.Data.Entity.EntityState.Modified;
            return u;
        }
    }
}