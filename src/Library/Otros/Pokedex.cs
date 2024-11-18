namespace Library;
/// <summary>
/// Esta es la clase estática Pokedex. Se encarga de tener todos los Pokémons disponibles para usar.
/// </summary>
public static class Pokedex
{
    /// <summary>
    /// Atributo estático tipo Lista que contiene todos los Pokémons disponibles.
    /// </summary>
    ///
    ///
    /// 
    /// eliminar listaPokemons
    /// cambiarlo para que agregue los ataques segun el tipo
    /// 
    public static List<Pokemon> listaPokemons = new List<Pokemon>
    {
        new Pokemon("Bulbasaur", "Planta", new Ataque("Florecer", 10,70,"Planta"), new Incendio()),
        new Pokemon("Oddish", "Planta", new Ataque("Florecer", 20,80,"Planta"), new Paralizar()),
        new Pokemon("Wurmple", "Bicho", new Ataque("Mordisco", 10,70,"Bicho"), new Envenenar()),
        new Pokemon("Caterpie", "Bicho", new Ataque("Mordisco", 10,90,"Bicho"), new Dormir()),
        new Pokemon("Charmander", "Fuego", new Ataque("Fogata",40,60,"Fuego"), new Incendio()),
        new Pokemon("Vulpix", "Fuego", new Ataque("Fogata",20,70,"Fuego"), new Paralizar()),
        new Pokemon("Cranidos", "Roca", new Ataque("Derrumne",40,70,"Roca"), new Envenenar()),
        new Pokemon("Rockruff", "Roca", new Ataque("Derrumbe",30,80,"Roca"), new Dormir()),
        new Pokemon("Cubone", "Tierra", new Ataque("Terremoto",40,50,"Tierra"), new Incendio()),
        new Pokemon("Diglett", "Tierra",new Ataque("Terremoto",30,60,"Tierra"), new Paralizar()),
        new Pokemon("Darumaka", "Hielo",new Ataque("Iceberg",20,60,"Hielo"), new Envenenar()),
        new Pokemon("Vanillite", "Hielo",new Ataque("Iceberg",10,70,"Hielo"), new Dormir()),
        new Pokemon("Dratini", "Dragón",new Ataque("Volcán",30,60,"Dragón"),new Incendio()),
        new Pokemon("Goomy", "Dragón",new Ataque("Volcán",20,70,"Dragón"),new Paralizar()), 
        new Pokemon("Duskull", "Fantasma",new Ataque("Danza",10,90,"Fantasma"),new Envenenar()), 
        new Pokemon("Greavard", "Fantasma",new Ataque("Danza",30,80,"Fantasma"),new Dormir()),
        new Pokemon("Eevee", "Normal",new Ataque("Patada",30,50,"Normal"),new Incendio()),
        new Pokemon("Snorlax", "Normal",new Ataque("Patada",20,70,"Normal"),new Paralizar()), 
        new Pokemon("Nidoran", "Veneno",new Ataque("Cicuta",30,90,"Veneno"), new Envenenar()),
        new Pokemon("Koffing", "Veneno",new Ataque("Cicuta",20,80,"Veneno"), new Dormir()),
        new Pokemon("Machop", "Lucha", new Ataque("Golpe",40,50,"Lucha"), new Incendio()),
        new Pokemon("Timburr", "Lucha", new Ataque("Golpe",30,60,"Lucha"), new Paralizar()), 
        new Pokemon("Mew", "Psíquico", new Ataque("Hipnosis",30,80,"Psíquico"), new Envenenar()), 
        new Pokemon("Ponyta", "Psíquico", new Ataque("Hipnosis",20,90,"Psíquico"), new Dormir()),
        new Pokemon("Voltorb", "Eléctrico",new Ataque("Rayo",30,60,"Eléctrico"),new Incendio()),
        new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,70,"Eléctrico"),new Paralizar() ),
        new Pokemon("Psyduck", "Agua",new Ataque("Tsunami",30,50,"Agua"),new Envenenar()),
        new Pokemon("Squirtle", "Agua", new Ataque("Tsunami",20,60,"Agua"),new Dormir()),
        new Pokemon("Skarmory", "Volador",new Ataque("Viento",20,90,"Volador"),new Incendio()),
        new Pokemon("Vullaby", "Volador",new Ataque("Viento",30,80,"Volador"),new Paralizar())
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
                if (ataqueEspecialBase is Paralizar)
                {
                    return new Pokemon(pokemon.Nombre, pokemon.Tipo, ataqueCopia, new Paralizar());
                }
                if (ataqueEspecialBase is Envenenar)
                {
                    return new Pokemon(pokemon.Nombre, pokemon.Tipo, ataqueCopia, new Envenenar());
                }
                if (ataqueEspecialBase is Dormir)
                {
                    return new Pokemon(pokemon.Nombre, pokemon.Tipo, ataqueCopia, new Dormir());
                }

            }
        }
        return null;
    }
    
}