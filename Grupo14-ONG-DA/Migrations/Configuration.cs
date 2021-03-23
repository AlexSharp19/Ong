namespace Grupo14_ONG_DA.Migrations
{
    using Grupo14_ONG_DA.ModelsEF;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Grupo14_ONG_DA.DataAccess.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Grupo14_ONG_DA.DataAccess.Context context)
        {
            context.TypeEntities.AddOrUpdate(x => x.Id,
                new TypeEntity() { Id = 1, Active = true, Description = "ONG"},
                new TypeEntity() { Id = 2, Active = true, Description = "Project"},
                new TypeEntity() { Id = 3, Active = true, Description = "ONGpartner"}
            );

            context.ONGtypes.AddOrUpdate(x => x.Id,
                new ONGtype() { Id = 1, Name = "Comedor"},
                new ONGtype() { Id = 2, Name = "Refugio"},
                new ONGtype() { Id = 3, Name = "Biblioteca"}
            );

            context.Provinces.AddOrUpdate(x => x.Id,
                new Province() { Id = 1, Name = "Buenos Aires"},
                new Province() { Id = 2, Name = "Catamarca" },
                new Province() { Id = 3, Name = "Chaco" },
                new Province() { Id = 4, Name = "Chubut" },
                new Province() { Id = 5, Name = "Ciudad Autónoma de Buenos Aires" },
                new Province() { Id = 6, Name = "Córdoba" },
                new Province() { Id = 7, Name = "Corrientes" },
                new Province() { Id = 8, Name = "Entre Rios" },
                new Province() { Id = 9, Name = "Formosa" },
                new Province() { Id = 10, Name = "Jujuy" },
                new Province() { Id = 11, Name = "La Pampa" },
                new Province() { Id = 12, Name = "La Rioja" },
                new Province() { Id = 13, Name = "Mendoza" },
                new Province() { Id = 14, Name = "Misiones" },
                new Province() { Id = 15, Name = "Neuquen" },
                new Province() { Id = 16, Name = "Rio Negro" },
                new Province() { Id = 17, Name = "Salta" },
                new Province() { Id = 18, Name = "San Juan" },
                new Province() { Id = 19, Name = "San Luis" },
                new Province() { Id = 20, Name = "Santa Cruz" },
                new Province() { Id = 21, Name = "Santa Fe" },
                new Province() { Id = 22, Name = "Santiago del Estero" },
                new Province() { Id = 23, Name = "Tierra del Fuego" },
                new Province() { Id = 24, Name = "Tucumán" }
            );

            context.Rols.AddOrUpdate(x => x.Id,
                new Rol() { Id = 1, name = "Admin"}
            );

            context.TypeMultimediaFiles.AddOrUpdate(x => x.Id,
                new TypeMultimediaFile() { Id = 1 },
                new TypeMultimediaFile() { Id = 2 },
                new TypeMultimediaFile() { Id = 3 }
            );
        }
    }
}
