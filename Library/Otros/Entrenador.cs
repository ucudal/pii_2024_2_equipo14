namespace Library;

public class Entrenador
{
    public string Nombre { get; private set; }
    public List<Pokemon> miCatalogo = new List<Pokemon>();
    public List<Pokemon> misMuertos = new List<Pokemon>();
    public bool MiTurno { get; set; }
    public int Turnos { get; set; }
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
    public void QuitarPokemon(Pokemon pokemon)
    {
        if (this.miCatalogo.Contains(pokemon))
        {
            this.miCatalogo.Remove(pokemon);
        }
    }
    public void QuitarItem(Item item)
    {
        if (this.MisItems.Contains(item))
        {
            this.MisItems.Remove(item);
        }
    }

    public void AgregarMuerto(Pokemon pokemon)
    {
        if (!this.misMuertos.Contains(pokemon))
        {
            this.misMuertos.Add(pokemon);
        }
    }
    
    public void QuitarMuerto(Pokemon pokemon)
    {
        if (this.miCatalogo.Contains(pokemon))
        {
            this.miCatalogo.Remove(pokemon);
        }
    }

    public void Recuperar(Pokemon pokemon)
    {
     
        this.miCatalogo.Add(pokemon);
        
    }
    public Pokemon PokemonActual { get; set; }
    public Entrenador(string nombre)
    {
        this.Nombre = nombre;
    }
}