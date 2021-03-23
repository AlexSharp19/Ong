using Grupo14_ONG_DA.DataAccess;
using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.Repositories.Implements
{
    public class ProjectRepository: GenericRepository<Project>, IProjectRepository
    {

        public ProjectRepository(Context context) : base(context)
        {

        }


        public List<Project> GetAll(bool isActive)
        {
            var lst = dbSet.Where(x => x.IsActive == isActive).ToList();
            return lst;
        }

        public void InsertMultiMediaProject(List<MultiMedia> ListMultiMedia,int ProjectId)
        {
            TypeEntity EntityProject = context.TypeEntities.Where(entity => entity.Id == (int)TypeEntity.enumTypeEntity.Project).FirstOrDefault();
            
            using (var Transaction = context.Database.BeginTransaction())
            {
                try
                {                 
                        foreach (var item in ListMultiMedia)
                        {
                            EntityMultimedia entityMultimedia = new EntityMultimedia()
                            {
                                EntityId = ProjectId,
                                TypeEntity = EntityProject
                            };


                        MultiMedia existMultimedia = context.MultiMedias.FirstOrDefault(x => x.Url == item.Url);
                        if (existMultimedia == null)
                        {
                            context.MultiMedias.Add(item);
                            entityMultimedia.MultiMedia = item;
                        }
                        else
                        {
                            entityMultimedia.MultiMedia = existMultimedia;

                        }

                        context.EntityMultimedias.Add(entityMultimedia);
                        }
                    
                    Transaction.Commit();
                }
                catch
                {
                    Transaction.Rollback();
                }
            }
        }

        public void UpdateMultimedias(List<MultiMedia> l, int ProjectId)
        {

            using (var Transaction = context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in l)
                    {
                        //si la imagen no existe la agrego
                        if (context.MultiMedias.FirstOrDefault(x => x.Url == item.Url) == null)
                        {
                            context.MultiMedias.Add(item);
                        }
                    }
                    context.SaveChanges();
                    //Obtengo los multimedia con su id y referencia a entity framework
                    List<MultiMedia> newMultimedias = new List<MultiMedia>();/*context.MultiMedias.Where(x => l.Contains(x)).ToList();*/
                    foreach (var item in l)
                    {
                        newMultimedias.Add(context.MultiMedias.FirstOrDefault(x => x.Url == item.Url));
                    }
                        //elimino los multimedias antiguos
                        context.EntityMultimedias.RemoveRange(context.EntityMultimedias.Where(x => x.TypeEntity.Id == 2 && x.EntityId == ProjectId));
                        TypeEntity EntityProject = context.TypeEntities.Where(entity => entity.Id == (int)TypeEntity.enumTypeEntity.Project).FirstOrDefault();

                        foreach (var i in newMultimedias)
                        {
                            EntityMultimedia em = new EntityMultimedia()
                            {
                                EntityId = ProjectId,
                                MultiMedia = i,
                                TypeEntity = EntityProject
                            };

                            context.EntityMultimedias.Add(em);
                        }

                    Transaction.Commit();
                }
                catch
                {
                    Transaction.Rollback();
                    throw;
                }
            }


        }

    }
}