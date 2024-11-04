namespace Library.Otros;

public class Entrenador
{
    public string Nombre { get; private set; }
    public List<Pokemon> miCatalogo = new List<Pokemon>();

    public void AgregarPokemon(string nombre)
    {
        Pokemon pokemon = Pokedex.BuscarPokemon(nombre);
        miCatalogo.Add(pokemon);
    }

    public void QuitarPokemon(string nombre)
    {
        
    }
}