namespace Library;

public class Entrenador
{
    public string Nombre { get; private set; }
    public List<Pokemon> miCatalogo = new List<Pokemon>();
    public List<Item> MisItems
    {
        get
        {
            return MisItems;
        }
        set
        {
            if (Batalla.EnBatalla)
            {
                MisItems = value;
            }
        }
        
    }
    public void AgregarPokemon(string nombre)
    {
        bool encontrado = false;
        foreach (Pokemon pokemon in this.miCatalogo)
        {
            if (pokemon.Nombre == nombre)
            {
                encontrado = true;
            }
        }
        if (encontrado == false && miCatalogo.Count <= 6 && Batalla.EnBatalla == false)
        {
            Pokemon pokemonNuevo = Pokedex.BuscarPokemon(nombre);
            miCatalogo.Add(pokemonNuevo);
        }
        
    }
    public void QuitarPokemon(string nombre)
    {
        foreach (Pokemon pokemon in this.miCatalogo)
        {
            if (pokemon.Nombre == nombre && Batalla.EnBatalla == false)
            {
                this.miCatalogo.Remove(pokemon);
            }
        }
    }
    public Entrenador(string nombre)
    {
        this.Nombre = nombre;
    }
}