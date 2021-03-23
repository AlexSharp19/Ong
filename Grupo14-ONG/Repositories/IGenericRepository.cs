using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo14_ONG.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);

        TEntity GetById(int id);

        List<TEntity> GetAll();

        void Update(TEntity entity);

    }
}
