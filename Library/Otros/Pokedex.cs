using System.Runtime.CompilerServices;

namespace Library;

public static class Pokedex
{
    public static List<Pokemon> listaPokemons = new List<Pokemon>
    {
        new Pokemon("Bulbasaur", new Planta(), new Florecer(), new Zzz()),
        new Pokemon("Caterpie", new Bicho(), new Mordisco(), new Off()),
        new Pokemon("Charmander", new Fuego(), new Volcan(), new Incendio()),
        new Pokemon("Cranidos", new Roca(), new Derrumbe(), new Maniqui()),
        new Pokemon("Cubone", new Tierra(), new Terremoto(), new Zzz()),
        new Pokemon("Darumaka", new Hielo(), new Iceberg(), new Maniqui()),
        new Pokemon("Diglett", new Tierra(), new Terremoto(), new Maniqui()),
        new Pokemon("Dratini", new Dragon(), new Volcan(), new Incendio()),
        new Pokemon("Duskull", new Fantasma(), new Danza(), new Off()),
        new Pokemon("Eevee", new Normal(), new Florecer(), new Zzz()),
        new Pokemon("Goomy", new Dragon(), new Volcan(), new Off()),
        new Pokemon("Greavard", new Fantasma(), new Danza(), new Incendio()),
        new Pokemon("Koffing", new Veneno(), new Mordisco(), new Off()),
        new Pokemon("Machop", new Lucha(), new Golpe(), new Zzz()),
        new Pokemon("Mew", new Psiquico(), new Rayo(), new Maniqui()),
        new Pokemon("Nidoran", new Veneno(), new Tsunami(), new Off()),
        new Pokemon("Oddish", new Planta(), new Florecer(), new Maniqui()),
        new Pokemon("Pikachu", new Electrico(), new Rayo(), new Incendio()),
        new Pokemon("Ponyta", new Psiquico(), new Golpe(), new Maniqui()),
        new Pokemon("Psyduck", new Agua(), new Tsunami(), new Zzz()),
        new Pokemon("Rockruff", new Roca(), new Derrumbe(), new Incendio()),
        new Pokemon("Skarmory", new Volador(), new Viento(), new Off()),
        new Pokemon("Snorlax", new Normal(), new Iceberg(), new Zzz()),
        new Pokemon("Squirtle", new Agua(), new Tsunami(), new Maniqui()),
        new Pokemon("Timburr", new Lucha(), new Golpe(), new Incendio()),
        new Pokemon("Vanillite", new Hielo(), new Iceberg(), new Off()),
        new Pokemon("Voltorb", new Electrico(), new Rayo(), new Zzz()),
        new Pokemon("Vullaby", new Volador(), new Viento(), new Incendio()),
        new Pokemon("Vulpix", new Fuego(), new Derrumbe(), new Incendio()),
        new Pokemon("Wurmple", new Bicho(), new Mordisco(), new Maniqui())

    };

    public static Pokemon BuscarPokemon(string nombre)
    {
        foreach (Pokemon pokemon in listaPokemons)
        {
            if (pokemon.Nombre == nombre)
            {
                return pokemon;
            }
        }
        return null;
    }
    
}