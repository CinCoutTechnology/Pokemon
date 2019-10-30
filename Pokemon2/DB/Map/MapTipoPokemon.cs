using Pokemon2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Pokemon2.DB.Map
{
    public class MapTipoPokemon : EntityTypeConfiguration<TipoPokemon>
    {
        public MapTipoPokemon()
        {
            ToTable("TipoPokemon");
            HasKey(a => a.IdTipoPokemon);
        }
    }
}