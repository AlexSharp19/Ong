using Grupo14_ONG_DA.DataAccess;
using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.Repositories.Implements
{
    public class OngPartnerRepository : GenericRepository<ONGpartner>, IOngPartnerRepository
    {

        public OngPartnerRepository(Context context) : base(context)
        {

        }


        public List<ONGpartner> GetAll(bool isActive)
        {
            var lst = dbSet.Where(x => x.IsActive == isActive).ToList();
            return lst;
        }



        public void InsertMultiMediaOngPartner(List<MultiMedia> ListMultiMedia, int OngPartnerId)
        {

            TypeEntity EntityProject = context.TypeEntities.Where(entity => entity.Id == (int)TypeEntity.enumTypeEntity.ONGPartner).FirstOrDefault();

            using (var Transaction = context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in ListMultiMedia)
                    {
                        EntityMultimedia entityMultimedia = new EntityMultimedia()
                        {
                            EntityId = OngPartnerId,
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

        public void UpdateMultiMediaOngPartner(List<MultiMedia> l, int OngPartnerId)
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
                    context.EntityMultimedias.RemoveRange(context.EntityMultimedias.Where(x => x.TypeEntity.Id == (int)TypeEntity.enumTypeEntity.ONGPartner && x.EntityId == OngPartnerId));
                    TypeEntity EntityProject = context.TypeEntities.Where(entity => entity.Id == (int)TypeEntity.enumTypeEntity.ONGPartner).FirstOrDefault();

                    foreach (var i in newMultimedias)
                    {
                        EntityMultimedia em = new EntityMultimedia()
                        {
                            EntityId = OngPartnerId,
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