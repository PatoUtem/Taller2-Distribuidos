namespace API_taller2.Models
{
    public class DataPokemon
    {
        public int id { get; set; }
        public string nombre { get; set; }
        // forms[name, https://pokeapi.co/api/v2/pokemon-form/1/], abilities[ability[name]], ubicacion[location_area_encounters[ir a url[location_area]]], sprite[]
        public int altura { get; set; }
        public int peso { get; set; }
        public List<string> tipos { get; set; }
        public List<string> formas { get; set; }
        public List<string> habilidades { get; set; }
        public List<string> ubicacion { get; set; }
        public string imagen { get; set; }

    }
}
