using Pokemon2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;


namespace Pokemon2.DB.Map
{
    public class MapPokemon : EntityTypeConfiguration<Pokemon>
    {
        public MapPokemon()
        {
            ToTable("Pokemon");
            HasKey(o => o.IdPokemon);

            HasRequired(a => a.TipoPokemon)
                .WithMany()
                .HasForeignKey(a => a.TipoPokemonId);
        }
    }
}