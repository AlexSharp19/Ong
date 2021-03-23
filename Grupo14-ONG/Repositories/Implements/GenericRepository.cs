using Grupo14_ONG_DA.DataAccess;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Grupo14_ONG.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        protected readonly Context context;
        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(Context context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            var lst = dbSet.ToList();
            return lst;
        }

        public virtual TEntity GetById(int id)
        {
            var entity = dbSet.Find(id);
            return entity;
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);

        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

    }
}