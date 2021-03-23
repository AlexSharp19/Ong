using Grupo14_ONG_DA.DataAccess;
using Grupo14_ONG_DA.ModelsEF;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;
using System.Diagnostics;

namespace Grupo14_ONG.Repositories.Implements
{
    public class MultiMediaRepository : GenericRepository<MultiMedia>, IMultiMediaRepository
    {

        
        public MultiMediaRepository(Context context) : base(context)
        {
  

        }

        public void Insert(MultiMedia Obj, int TypeEntityId, int EntityId)
        {
    
            using (var Transaction = context.Database.BeginTransaction()) {
               
                try
                {
                   TypeEntity TypeEntity = context.TypeEntities.Find(TypeEntityId);

                    EntityMultimedia entityMultimedia = new EntityMultimedia(){
                        EntityId = EntityId,
                        MultiMedia = Obj,
                        TypeEntity = TypeEntity
                    };

                    dbSet.Add(Obj);
                    context.EntityMultimedias.Add(entityMultimedia);

                    Transaction.Commit();                      
                }
                catch {
                    Transaction.Rollback();
                
                }                     
            }
            
        }

        public List<MultiMedia> GetAll(int TypeEntityId, int EntityId)
        {

          return context.EntityMultimedias.Where(i => i.EntityId == EntityId &&
                                                 i.TypeEntity.Id == TypeEntityId
                                                 && i.MultiMedia.Url != "")
                                                 .Select(i => i.MultiMedia)                                               
                                                 .ToList();
           
        }

        public void Update(MultiMedia Obj, int TypeEntityId, int EntityId)
        {
            using (var Transaction = context.Database.BeginTransaction())
            {

                try
                {
                    MultiMedia multiMedia = dbSet.Find(Obj.Id);

                    
                    EntityMultimedia entityMulti = context.EntityMultimedias.Where(i => i.EntityId == EntityId
                                                    && i.MultiMedia.Id == Obj.Id).SingleOrDefault();
                    context.EntityMultimedias.Remove(entityMulti);
                    dbSet.Remove(multiMedia);

                    if (Obj.Url != "") {
                        Obj = new MultiMedia() { Url = Obj.Url, TypeFile = Obj.TypeFile };

                        TypeEntity TypeEntity = context.TypeEntities.Find(TypeEntityId);

                        EntityMultimedia entityMultimedia = new EntityMultimedia()
                        {
                            EntityId = EntityId,
                            MultiMedia = Obj,
                            TypeEntity = TypeEntity
                        };

                        dbSet.Add(Obj);
                        context.EntityMultimedias.Add(entityMultimedia);

                    }


                    Transaction.Commit();

                }
                catch{
                    Transaction.Rollback();
                }
            }
        }

        public MultiMedia GetFirst(int TypeEntityId, int EntityId)
        {
            try
            {
                return context.EntityMultimedias.Where(i => i.EntityId == EntityId && i.TypeEntity.Id == TypeEntityId)
                                                .Select(i => i.MultiMedia).FirstOrDefault();

            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex.Message);
                return null;
            }

        }

        public MultiMedia DefaultMultiMedia()
        {
            return new MultiMedia
            {
                Url = "www.defaultImg.com",
                TypeFile = "Image",


            };
        }
    }
}