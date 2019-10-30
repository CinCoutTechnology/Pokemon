using Pokemon2.DB.Map;
using Pokemon2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pokemon2.DB
{
    public class PokemonContext : DbContext
    {
        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }

        public DbSet<Pokemon> Pokemones { get; set; }

        public DbSet<RelacionEntradorPokemon> RelacionEntradorPokemones { get; set; }

        public DbSet<TipoPokemon> TipoPokemones { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new MapEntrenador());
            modelBuilder.Configurations.Add(new MapCiudad());
            modelBuilder.Configurations.Add(new MapPokemon());
            modelBuilder.Configurations.Add(new MapRelacion());
            modelBuilder.Configurations.Add(new MapTipoPokemon());
        }
    }
}