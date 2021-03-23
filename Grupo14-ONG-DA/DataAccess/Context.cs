using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Grupo14_ONG_DA.DataAccess
{  
        public class Context : DbContext
        {
            public Context(): base("ONG_F")
            { 
            
            }

             public virtual DbSet<SystemONG> Systems { get; set; }
             public virtual DbSet<User> Users { get; set; }
             public virtual DbSet<Rol> Rols { get; set; }
             public virtual DbSet<Project> Projects { get; set; }
             public virtual DbSet<MultiMedia> MultiMedias { get; set; }
             public virtual DbSet<ContactForm> ContactForms { get; set; }
             public virtual DbSet<TypeMultimediaFile> TypeMultimediaFiles { get; set; }
             public virtual DbSet<TypeEntity> TypeEntities { get; set; }
             public virtual DbSet<EntityMultimedia> EntityMultimedias { get; set; }
             public virtual DbSet<ONGpartner> ONGpartners { get; set; }
             public virtual DbSet<Province> Provinces { get; set; }
             public virtual DbSet<ONGtype> ONGtypes { get; set; }
        }

}
