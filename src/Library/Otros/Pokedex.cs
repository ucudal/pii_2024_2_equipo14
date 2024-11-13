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
        new Pokemon("Bulbasaur", new Planta(), new Ataque("Florecer", 10,70), new Off()),
        new Pokemon("Oddish", new Planta(), new Ataque("Florecer", 10,70), new Off()),
        new Pokemon("Wurmple", new Bicho(), new Ataque("Mordisco", 15,70), new Off()),
        new Pokemon("Caterpie", new Bicho(), new Ataque("Mordisco", 15,70), new Off()),
        new Pokemon("Charmander", new Fuego(), new Ataque("Fogata",45,70), new Incendio()),
        new Pokemon("Vulpix", new Fuego(), new Ataque("Fogata",45,70), new Incendio()),
        new Pokemon("Cranidos", new Roca(), new Ataque("Fogata",45,70), new Off()),
        new Pokemon("Rockruff", new Roca(), new Ataque("Fogata",45,70), new Off()),
        new Pokemon("Cubone", new Tierra(), new Ataque("Terremoto",40,30), new Incendio()),
        new Pokemon("Diglett", new Tierra(),new Ataque("Terremoto",40,30), new Incendio()),
        new Pokemon("Darumaka", new Hielo(),new Ataque("Iceberg",20,60), new Maniqui()),
        new Pokemon("Vanillite", new Hielo(),new Ataque("Iceberg",20,60), new Maniqui()),
        new Pokemon("Dratini", new Dragon(),new Ataque("Dragón",30,40),new Maniqui()),
        new Pokemon("Goomy", new Dragon(),new Ataque("Dragón",30,40),new Maniqui()), 
        new Pokemon("Duskull", new Fantasma(),new Ataque("Danza",10,30),new Incendio()), 
        new Pokemon("Greavard", new Fantasma(),new Ataque("Danza",10,30),new Incendio()),
        new Pokemon("Eevee", new Normal(),new Ataque("Patada",30,50),new Maniqui()),
        new Pokemon("Snorlax", new Normal(),new Ataque("Patada",30,50),new Maniqui()), 
        new Pokemon("Nidoran", new Veneno(),new Ataque("Cicuta",30,90), new Incendio()),
        new Pokemon("Koffing", new Veneno(),new Ataque("Cicuta",30,90), new Incendio()),
        new Pokemon("Machop", new Lucha(), new Ataque("Golpe",40,40), new Off()),
        new Pokemon("Timburr", new Lucha(), new Ataque("Golpe",40,40), new Off()), 
        new Pokemon("Mew", new Psiquico(), new Ataque("Hipnosis",30,80), new Zzz()), 
        new Pokemon("Ponyta", new Psiquico(), new Ataque("Hipnosis",30,80), new Zzz()),
        new Pokemon("Voltorb", new Electrico(),new Ataque("Rayo",40,20),new Zzz()),
        new Pokemon("Pikachu", new Electrico(),new Ataque("Rayo",40,20),new Zzz() ),
        new Pokemon("Psyduck", new Agua(),new Ataque("Tsunami",30,40),new Maniqui()),
        new Pokemon("Squirtle", new Agua(), new Ataque("Tsunami",30,40),new Maniqui()),
        new Pokemon("Skarmory", new Volador(),new Ataque("Viento",25,50),new Incendio()),
        new Pokemon("Vullaby", new Volador(),new Ataque("Viento",25,50),new Incendio())
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
                return Pokedex.CrearCopia(pokemon);
             
            }
        }
        return null;
    }
    /// <summary>
    /// Se encarga de crear una copia profunda del Pokémon que recibe.
    /// </summary>
    /// <param name="pokemon">El Pokémon que se copia.</param>
    public static Pokemon CrearCopia(Pokemon pokemon)
    {
        string nombreCopia = pokemon.Nombre;
        
        if (pokemon.Tipo is Agua)
            return new Pokemon(nombreCopia, new Agua(),new Ataque("Tsunami",30,40),new Maniqui());
        if (pokemon.Tipo is Bicho)
            return new Pokemon(nombreCopia, new Bicho(), new Ataque("Mordisco", 15,70), new Off());
        if (pokemon.Tipo is Dragon)
            return new Pokemon(nombreCopia, new Dragon(),new Ataque("Dragón",30,40),new Maniqui());
        if (pokemon.Tipo is Electrico)
            return new Pokemon(nombreCopia, new Electrico(),new Ataque("Rayo",40,20),new Zzz());
        if (pokemon.Tipo is Fantasma)
            return new Pokemon(nombreCopia, new Fantasma(),new Ataque("Danza",10,30),new Incendio());
        if (pokemon.Tipo is Fuego)
            return new Pokemon(nombreCopia, new Fuego(), new Ataque("Fogata",45,70), new Incendio());
        if (pokemon.Tipo is Hielo)
            return new Pokemon(nombreCopia, new Hielo(),new Ataque("Iceberg",20,60), new Maniqui());
        if (pokemon.Tipo is Lucha)
            return new Pokemon(nombreCopia, new Lucha(), new Ataque("Golpe",40,40), new Off());
        if (pokemon.Tipo is Normal)
            return new Pokemon(nombreCopia, new Normal(),new Ataque("Patada",30,50),new Maniqui());
        if (pokemon.Tipo is Planta)
            return new Pokemon(nombreCopia, new Planta(), new Ataque("Florecer", 10,70), new Off());
        if (pokemon.Tipo is Psiquico)
            return new Pokemon(nombreCopia, new Psiquico(), new Ataque("Hipnosis",30,80), new Zzz());
        if (pokemon.Tipo is Roca)
            return new Pokemon(nombreCopia, new Roca(), new Ataque("Fogata",45,70), new Off());
        if (pokemon.Tipo is Tierra)
            return new Pokemon(nombreCopia, new Tierra(), new Ataque("Terremoto",40,30), new Incendio());
        if (pokemon.Tipo is Veneno)
            return new Pokemon(nombreCopia, new Veneno(),new Ataque("Cicuta",30,90), new Incendio());
        if (pokemon.Tipo is Volador)
            return new Pokemon(nombreCopia, new Volador(),new Ataque("Viento",25,50),new Incendio());
        return null;
    }
    
}