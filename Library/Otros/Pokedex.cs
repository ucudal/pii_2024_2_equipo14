namespace Library;

public static class Pokedex
{
    public static List<Pokemon> listaPokemons = new List<Pokemon>
    {
        new Pokemon("Bulbasaur", new Planta()), new Pokemon("Caterpie", new Bicho()),
        new Pokemon("Charmander", new Fuego()), new Pokemon("Cranidos", new Roca()),
        new Pokemon("Cubone", new Tierra()), new Pokemon("Darumaka", new Hielo()),
        new Pokemon("Diglett", new Tierra()), new Pokemon("Dratini", new Dragon()),
        new Pokemon("Duskull", new Fantasma()), new Pokemon("Eevee", new Normal()),
        new Pokemon("Goomy", new Dragon()), new Pokemon("Greavard", new Fantasma()),
        new Pokemon("Koffing", new Veneno()), new Pokemon("Machop", new Lucha()),
        new Pokemon("Mew", new Psiquico()), new Pokemon("Nidoran", new Veneno()),
        new Pokemon("Oddish", new Planta()), new Pokemon("Pikachu", new Electrico()),
        new Pokemon("Ponyta", new Psiquico()), new Pokemon("Psyduck", new Agua()),
        new Pokemon("Rockruff", new Roca()), new Pokemon("Skarmory", new Volador()),
        new Pokemon("Snorlax", new Normal()), new Pokemon("Squirtle", new Agua()),
        new Pokemon("Timburr", new Lucha()), new Pokemon("Vanillite", new Hielo()),
        new Pokemon("Voltorb", new Electrico()), new Pokemon("Vullaby", new Volador()),
        new Pokemon("Vulpix", new Fuego()), new Pokemon("Wurmple", new Bicho())
    };

    public static Pokemon BuscarPokemon(string nombre)
    {
        foreach (Pokemon pokemon in listaPokemons)
        {
            if (pokemon.Nombre == nombre)
            {
                
                Pokemon nuevoPokemon = new Pokemon(pokemon.Nombre, pokemon.Tipo);
                return nuevoPokemon;
                //hacer clone
            }
        }
        return null;
    }
    
}