namespace Library;

public class Entrenador
{
    public string Nombre { get; private set; }
    public List<Pokemon> miCatalogo = new List<Pokemon>();
    public List<Item> misItems = new List<Item>();
    public void AgregarPokemon(string nombre)
    {
        Pokemon pokemon = miCatalogo.Find(pokemon => pokemon.Nombre == nombre);
        if (pokemon == null)
        {
            Pokemon pokemonNuevo = Pokedex.BuscarPokemon(nombre);
            miCatalogo.Add(pokemonNuevo);
        }
    }
    public void QuitarPokemon(string nombre)
    {
        Pokemon pokemon = miCatalogo.Find(pokemon => pokemon.Nombre == nombre);
        if (pokemon != null)
        {
           miCatalogo.Remove(pokemon);
        }
    }
    public Entrenador(string nombre)
    {
        this.Nombre = nombre;
    }
}