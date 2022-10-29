using API_taller2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace API_taller2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        private IConfiguration configuration { get; }
        private string limiteBusqueda;
        private string urlAPIpokemon;


        public PokemonController(IConfiguration configuration)
        {

            this.configuration = configuration;
            limiteBusqueda = configuration.GetValue<string>("@limite");
            urlAPIpokemon = configuration.GetValue<string>("urlBusqueda");

        }

        /*
        *** Nombre de la Funcion: ExtraerData
        *** Parametros: string Desde
        * Descripcion: La funcion utiliza la API de pokeapi para extraer data especifica de los pokemones, la cual se puede ver en el Modelo DataPokemon. 
                       Extrae data con un limite de 10 y desde el id ingresado en la variable desde
        * Return: Retorna un Json con la data de los pokemones

        */

        private async Task<List<DataPokemon>> ExtraerData(string desde)
        {

            string url = urlAPIpokemon;
            url = url.Replace("@limite", limiteBusqueda);
            url = url.Replace("@desde", desde);

            var client = new RestClient(url);
            var request = new RestRequest();

            request.Method = Method.Get;

            var response = await client.GetAsync(request);

            DataListaPokemon dataAPIpokemon = JsonConvert.DeserializeObject<DataListaPokemon>(response.Content);
            List<DataPokemon> dataPokemons = new List<DataPokemon>();
            if (response.IsSuccessStatusCode)
            {

                foreach (var item in dataAPIpokemon.results)
                {
                    var urlPokemon = item.url;
                    var client2 = new RestClient(urlPokemon);
                    var request2 = new RestRequest();

                    request2.Method = Method.Get;

                    var response2 = await client2.GetAsync(request2);

                    DataAPIpokemon datapokemon = JsonConvert.DeserializeObject<DataAPIpokemon>(response2.Content);

                    if (response2.IsSuccessStatusCode)
                    {
                        List<string> tipos = new List<string>();
                        foreach (var tipo in datapokemon.types)
                        {
                            tipos.Add(tipo.type.name);
                        }

                        List<string> formas = new List<string>();
                        foreach (var forma in datapokemon.forms)
                        {
                            formas.Add(forma.name);
                        }

                        List<string> habilidades = new List<string>();
                        foreach (var habilidad in datapokemon.abilities)
                        {
                            habilidades.Add(habilidad.ability.name);
                        }

                        var urlUbicaion = datapokemon.location_area_encounters;
                        var client3 = new RestClient(urlUbicaion);
                        var request3 = new RestRequest();

                        request3.Method = Method.Get;

                        var response3 = await client3.GetAsync(request3);

                        List<UbicacionesPokemon> dataubicacion = JsonConvert.DeserializeObject<List<UbicacionesPokemon>>(response3.Content);

                        List<string> ubicaciones = new List<string>();
                        if (response3.IsSuccessStatusCode)
                        {
                            foreach (var ubicacion in dataubicacion)
                            {
                                ubicaciones.Add(ubicacion.location_area.name);
                            }
                        }



                        DataPokemon Pokemon = new DataPokemon()
                        {
                            id = datapokemon.id,
                            nombre = datapokemon.name,
                            altura = datapokemon.height,
                            peso = datapokemon.weight,
                            imagen = datapokemon.sprites.front_default,
                            tipos = tipos,
                            formas = formas,
                            habilidades = habilidades,
                            ubicacion = ubicaciones
                        };
                        dataPokemons.Add(Pokemon);
                    }

                }

            }
            return dataPokemons;


        }

        /*
        *** Nombre de la Funcion: GetInfoPkemones
        *** Parametros: string Desde
        * Descripcion: funcion que recibe la peticion GET para extraer la data de los pokemones, desde el ID ingresado en la variable del mismo nombre.
        * Return: Retorna un Json con la data de los pokemones y el ID de inicio de los siguientes 10 pokemones en la varible next.

        */
        [HttpGet]
        public async Task<IActionResult> GetInfoPkemones(string desde)
        {

            var respuesta = await ExtraerData(desde);

            int siguiente = Int32.Parse(desde) + Int32.Parse(limiteBusqueda);



            return Ok(new { respuesta, next = siguiente });
        }

    }
}
