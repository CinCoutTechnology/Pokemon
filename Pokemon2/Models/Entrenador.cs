using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokemon2.Models
{
    public class Entrenador
    {
        public int IdEntrenador { get; set; }
        public string Nombre { get; set; }
        public Ciudad Ciudad { get; set; }
        public int CiudadId { get; set; }

        public List<RelacionEntradorPokemon> Relacion { get; set; }
    }
}