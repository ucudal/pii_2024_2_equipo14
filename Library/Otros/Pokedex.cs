using System.Runtime.CompilerServices;

namespace Library;

public static class Pokedex
{
    public static List<Pokemon> listaPokemons = new List<Pokemon>
    {
        new Bulbasaur(), new Caterpie(), new Charmander(),
        new Cranidos(), new Darumaka(), new Diglett(), new Dratini(), new Duskull(), new Eevee(), new Goomy(),
        new Greavard(), new Koffing(), new Machop(), new Mew(), new Nidoran(), new Oddish(), new Pikachu(),
        new Ponyta(), new Psyduck(), new Rockruff(), new Skarmory(), new Snorlax(), new Squirtle(), new Timburr(),
        new Vanillite(), new Voltorb(), new Vullaby(), new Vulpix(), new Wurmple()
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