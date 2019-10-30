using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokemon2.Models
{
    public class Pokemon
    {
        public int IdPokemon { get; set; }
        public string Nombre { get; set; }
        public TipoPokemon TipoPokemon { get; set; }
        public int TipoPokemonId { get; set; }

    }
}