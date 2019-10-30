using Pokemon2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Pokemon2.DB.Map
{
    public class MapEntrenador : EntityTypeConfiguration<Entrenador>
    {
        public MapEntrenador()
        {
            ToTable("Entrenador");
            HasKey(a => a.IdEntrenador);

            HasRequired(a => a.Ciudad)
                .WithMany()
                .HasForeignKey(a => a.CiudadId);
        }
    }
}