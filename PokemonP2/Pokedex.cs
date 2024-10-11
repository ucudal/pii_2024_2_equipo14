namespace PokemonP2;

public class Pokedex
{
    public static List<IPokemon> listaPokemons = new List<IPokemon>();

    private static void CrearPokemons()
    {
        Squirtle squirtle = new Squirtle();
        listaPokemons.Add(squirtle);
        Charmander charmander = new Charmander();
        listaPokemons.Add(charmander);
        Bulbasaur bulbasaur = new Bulbasaur();
        listaPokemons.Add(bulbasaur);
    }
    
}