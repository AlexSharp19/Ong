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
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Grupo14_ONG_DA.DataAccess.Context context)
        {
            context.TypeEntities.AddOrUpdate(x => x.Id,
                new TypeEntity() { Active = true, Description = "ONG" },
                new TypeEntity() { Active = true, Description = "Project" },
                new TypeEntity() { Active = true, Description = "ONGpartner" } 
            );

            context.ONGtypes.AddOrUpdate(x => x.Id,
                new ONGtype() { Name = "Comedor" },
                new ONGtype() { Name = "Refugio" },
                new ONGtype() { Name = "Biblioteca" }
            );

            context.Provinces.AddOrUpdate(x => x.Id,
                new Province() { Name = "Buenos Aires" },
                new Province() { Name = "Catamarca" },
                new Province() { Name = "Chaco" },
                new Province() { Name = "Chubut" },
                new Province() { Name = "Ciudad Autónoma de Buenos Aires" },
                new Province() { Name = "Córdoba" },
                new Province() { Name = "Corrientes" },
                new Province() { Name = "Entre Rios" },
                new Province() { Name = "Formosa" },
                new Province() { Name = "Jujuy" },
                new Province() { Name = "La Pampa" },
                new Province() { Name = "La Rioja" },
                new Province() { Name = "Mendoza" },
                new Province() { Name = "Misiones" },
                new Province() { Name = "Neuquen" },
                new Province() { Name = "Rio Negro" },
                new Province() { Name = "Salta" },
                new Province() { Name = "San Juan" },
                new Province() { Name = "San Luis" },
                new Province() { Name = "Santa Cruz" },
                new Province() { Name = "Santa Fe" },
                new Province() { Name = "Santiago del Estero" },
                new Province() { Name = "Tierra del Fuego" },
                new Province() { Name = "Tucumán" }
            );

            context.Rols.AddOrUpdate(x => x.Id,
                new Rol() { name = "Admin" }
            );




        }
    }
}
