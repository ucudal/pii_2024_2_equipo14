namespace Library;
/// <summary>
/// Esta es la clase estática Pokedex. Se encarga de tener todos los Pokémons disponibles para usar.
/// </summary>
public static class Pokedex
{
    /// <summary>
    /// Atributo estático tipo Lista que contiene todos los Pokémons disponibles.
    /// </summary>
    public static List<Pokemon> listaPokemons = new List<Pokemon>
    {
        new Pokemon("Bulbasaur", "Planta", new Ataque("Florecer", 10,70,"Planta"), new Incendio()),
        new Pokemon("Oddish", "Planta", new Ataque("Florecer", 20,80,"Planta"), new Maniqui()),
        new Pokemon("Wurmple", "Bicho", new Ataque("Mordisco", 10,70,"Bicho"), new Off()),
        new Pokemon("Caterpie", "Bicho", new Ataque("Mordisco", 10,90,"Bicho"), new Zzz()),
        new Pokemon("Charmander", "Fuego", new Ataque("Fogata",40,60,"Fuego"), new Incendio()),
        new Pokemon("Vulpix", "Fuego", new Ataque("Fogata",20,70,"Fuego"), new Maniqui()),
        new Pokemon("Cranidos", "Roca", new Ataque("Derrumne",40,70,"Roca"), new Off()),
        new Pokemon("Rockruff", "Roca", new Ataque("Derrumbe",30,80,"Roca"), new Zzz()),
        new Pokemon("Cubone", "Tierra", new Ataque("Terremoto",40,50,"Tierra"), new Incendio()),
        new Pokemon("Diglett", "Tierra",new Ataque("Terremoto",30,60,"Tierra"), new Maniqui()),
        new Pokemon("Darumaka", "Hielo",new Ataque("Iceberg",20,60,"Hielo"), new Off()),
        new Pokemon("Vanillite", "Hielo",new Ataque("Iceberg",10,70,"Hielo"), new Zzz()),
        new Pokemon("Dratini", "Dragón",new Ataque("Volcán",30,60,"Dragón"),new Incendio()),
        new Pokemon("Goomy", "Dragón",new Ataque("Volcán",20,70,"Dragón"),new Maniqui()), 
        new Pokemon("Duskull", "Fantasma",new Ataque("Danza",10,90,"Fantasma"),new Off()), 
        new Pokemon("Greavard", "Fantasma",new Ataque("Danza",30,80,"Fantasma"),new Zzz()),
        new Pokemon("Eevee", "Normal",new Ataque("Patada",30,50,"Normal"),new Incendio()),
        new Pokemon("Snorlax", "Normal",new Ataque("Patada",20,70,"Normal"),new Maniqui()), 
        new Pokemon("Nidoran", "Veneno",new Ataque("Cicuta",30,90,"Veneno"), new Off()),
        new Pokemon("Koffing", "Veneno",new Ataque("Cicuta",20,80,"Veneno"), new Zzz()),
        new Pokemon("Machop", "Lucha", new Ataque("Golpe",40,50,"Lucha"), new Incendio()),
        new Pokemon("Timburr", "Lucha", new Ataque("Golpe",30,60,"Lucha"), new Maniqui()), 
        new Pokemon("Mew", "Psíquico", new Ataque("Hipnosis",30,80,"Psíquico"), new Off()), 
        new Pokemon("Ponyta", "Psíquico", new Ataque("Hipnosis",20,90,"Psíquico"), new Zzz()),
        new Pokemon("Voltorb", "Eléctrico",new Ataque("Rayo",30,60,"Eléctrico"),new Incendio()),
        new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,70,"Eléctrico"),new Maniqui() ),
        new Pokemon("Psyduck", "Agua",new Ataque("Tsunami",30,50,"Agua"),new Off()),
        new Pokemon("Squirtle", "Agua", new Ataque("Tsunami",20,60,"Agua"),new Zzz()),
        new Pokemon("Skarmory", "Volador",new Ataque("Viento",20,90,"Volador"),new Incendio()),
        new Pokemon("Vullaby", "Volador",new Ataque("Viento",30,80,"Volador"),new Maniqui())
    };
    /// <summary>
    /// Se encarga de buscar un Pokémon en la Pokédex por su nombre.
    /// </summary>
    /// <param name="nombre">El nombre del Pokémon a buscar.</param>
    public static Pokemon BuscarPokemon(string nombre)
    {
        foreach (Pokemon pokemon in listaPokemons)
        {
            if (pokemon.Nombre == nombre)
            {
                Ataque ataqueBase = pokemon.Ataque;
                Ataque ataqueCopia = new Ataque(ataqueBase.Nombre, ataqueBase.Dano, ataqueBase.Precision,ataqueBase.Tipo);
                AtaqueEspecial ataqueEspecialBase = pokemon.AtaqueEspecial;
                if (ataqueEspecialBase is Incendio)
                {
                    return new Pokemon(pokemon.Nombre, pokemon.Tipo, ataqueCopia, new Incendio());
                }
                if (ataqueEspecialBase is Maniqui)
                {
                    return new Pokemon(pokemon.Nombre, pokemon.Tipo, ataqueCopia, new Maniqui());
                }
                if (ataqueEspecialBase is Off)
                {
                    return new Pokemon(pokemon.Nombre, pokemon.Tipo, ataqueCopia, new Off());
                }
                if (ataqueEspecialBase is Zzz)
                {
                    return new Pokemon(pokemon.Nombre, pokemon.Tipo, ataqueCopia, new Zzz());
                }

            }
        }
        return null;
    }
    
}