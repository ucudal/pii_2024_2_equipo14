namespace PokemonP2;

public class Jugador
{
    private string nombre;
    private List<Pokemon> misPokemons = new List<Pokemon>();
    private int turnos = 0;

    public int Turnos
    {
        set
        {
            this.turnos = value;
        }
    }

    public void AgregarPokemon(Pokemon pokemon)
    {
        if (Pokedex.listaPokemons.Contains(pokemon) && !this.misPokemons.Contains(pokemon) && this.misPokemons.Count < 6)
        {
            this.misPokemons.Add(pokemon);
        }
    }

    public void EliminarPokemon(Pokemon pokemon)
    {
        if (this.misPokemons.Contains(pokemon))
        {
            this.misPokemons.Remove(pokemon);
        }
    }
}