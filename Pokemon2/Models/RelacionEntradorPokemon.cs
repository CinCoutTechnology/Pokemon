namespace Pokemon2.Models
{
    public class RelacionEntradorPokemon
    {
        public int IdRelacion { get; set; }
        public Entrenador Entrenador { get; set; }
        public int EntrenadorId { get; set; }
        public Pokemon Pokemon { get; set; }
        public int PokemonId { get; set; }

    }
}