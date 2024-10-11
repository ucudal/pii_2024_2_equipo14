namespace PokemonP2;

public class Pokedex
{
    public static List<Pokemon> listaPokemons = new List<Pokemon>();

    private void CrearPokemons()
    {
        Pokemon squirtle = new Pokemon("Squirtle", 35, new Agua(), 70, 70);
        listaPokemons.Add(squirtle);
        Pokemon charmander = new Pokemon("Charmander", 40, new Fuego(), 70, 70);
        listaPokemons.Add(charmander);
        Pokemon bulbasaur = new Pokemon("Bulbasaur", 30, new Planta(), 80, 80);
        listaPokemons.Add(bulbasaur);
    }
   
  
}