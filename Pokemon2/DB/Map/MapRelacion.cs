using Pokemon2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Pokemon2.DB.Map
{
    public class MapRelacion : EntityTypeConfiguration<RelacionEntradorPokemon>
    {
        public MapRelacion()
        {
            ToTable("RelacionEntradorPokemon");
            HasKey(o => o.IdRelacion);

            HasRequired(o => o.Entrenador).WithMany(o => o.Relacion).HasForeignKey(o=>o.EntrenadorId);
            HasRequired(o => o.Pokemon).WithMany().HasForeignKey(o=>o.PokemonId);
        }
    }
}