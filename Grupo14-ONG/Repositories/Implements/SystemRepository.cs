using Grupo14_ONG_DA.DataAccess;
using Grupo14_ONG_DA.ModelsEF;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace Grupo14_ONG.Repositories.Implements
{
    public class SystemRepository : GenericRepository<SystemONG>, ISystemRepository
    {
        public object DataTime { get; private set; }

        public SystemRepository(Context context) : base(context){

        }

            
        /*Obtain the data from the database systems, if it does not exist, 
         return a default system*/    
        public SystemONG GetSystem()
        {
            if(context.Systems.FirstOrDefault() == null){
                return CreateSystemGeneric();
            }
            else{
                return context.Systems.FirstOrDefault();
            }
        }

       
        public void InsertOrUpdateSystem(SystemONG systemONG)
        {
           if(systemONG.Id == 0){
                context.Entry(systemONG).State = EntityState.Added;
            }
            else{
                context.Entry(systemONG).State = EntityState.Modified;
            }
                    
        }

        public void InsertOrUpdateMultiMediaSystem(List<MultiMedia> ListMultiMedia) 
        {
            bool UpdateMultiMedia = true;
            
            TypeEntity EntitySystem = context.TypeEntities.First();                             //Obtengo el tipo de entidad
            SystemONG currentSystem = GetSystem();                                              //Obtengo los valores de la entidad.

           var currentListMultiMediaFile = context.EntityMultimedias                            //Obtengo todos los multimedias asociados.
                                    .Where(i => i.EntityId == currentSystem.Id && i.TypeEntity.Id == EntitySystem.Id)
                                    .Select(i => i.MultiMedia)
                                    .Include(i=> i.EntityMultimedias)
                                    .ToList();

            if(currentListMultiMediaFile.Count == 0){
                UpdateMultiMedia = false;
            }

            using (var Transaction = context.Database.BeginTransaction())
            {
                try
                {
                    if (UpdateMultiMedia)
                    {

                        context.EntityMultimedias.RemoveRange(context.EntityMultimedias.Where(x=>x.EntityId==currentSystem.Id));
                        context.MultiMedias.RemoveRange(currentListMultiMediaFile);                                                  
                                             
                    }
                   
                        foreach (var item in ListMultiMedia)
                        {
                            EntityMultimedia entityMultimedia = new EntityMultimedia()
                            {
                                EntityId = currentSystem.Id,
                                MultiMedia = item,
                                TypeEntity = EntitySystem 

                            };

                            
                            
                           
                            context.MultiMedias.Add(item);
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
        
        private SystemONG CreateSystemGeneric()
        {
            SystemONG SystemGeneric = new SystemONG()
            {
                Id = 0,
                UrlLogo = "www.URLlogoPorDefecto.com",
                Adress = "Direccion por defecto",
                Phone = "123456789",
                WelcomeMessage = "Sistema por defecto NO database , agregue un registro de sistema!!!",
                LastModified = System.DateTime.Now,
                User = null
            };

            return SystemGeneric;
        }

       

       
    }
}