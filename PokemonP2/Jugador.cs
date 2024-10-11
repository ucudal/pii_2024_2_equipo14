namespace PokemonP2;

public class Jugador
{
    private string nombre;
    private List<IPokemon> misPokemons = new List<IPokemon>();
    private IPokemon pokemonActual;
    private bool turno;
    private bool turnoAnteriorEspecial;
    private int turnos;

    public List<IPokemon> GetMisPokemons()
    {
        return this.misPokemons;
    }

    public IPokemon PokemonActual
    {
        get { return pokemonActual; }
        set { this.pokemonActual = value; }
    }
    public bool Turno { get; set; }
    public int Turnos { get; set; }

    public Jugador(string nombre)
    {
        this.nombre = nombre;
    }
    public void AgregarPokemon(IPokemon pokemon)
    {
        if (Combate.enCombate == false && Pokedex.listaPokemons.Contains(pokemon) && !this.misPokemons.Contains(pokemon) && this.misPokemons.Count < 6)
        {
            this.misPokemons.Add(pokemon);
        }
    }
    public void EliminarPokemon(IPokemon pokemon)
    {
        if (Combate.enCombate == false)
        {
            this.misPokemons.Remove(pokemon);
        }
    }

    public void Atacar(Jugador jugador)
    {
        if (Combate.enCombate && this.turno && Combate.GetJugadoresActuales().Contains(jugador) && jugador.PokemonActual.VidaTotal > 0)
        {
            IPokemon pokemonAtacado = jugador.PokemonActual;
            jugador.PokemonActual.VidaTotal -= Ataque.CalcularAtaque(this.pokemonActual, pokemonAtacado);
            this.turno = false;
            this.turnos += 1;
            this.turnoAnteriorEspecial = false;
            jugador.Turno = true;
        }
        if (jugador.PokemonActual.VidaTotal == 0)
        {
            jugador.misPokemons.Remove(pokemonActual);
        }

        if (jugador.misPokemons.Count == 0)
        {
            Combate.Finalizar();
            for (int i = 0; i < this.misPokemons.Count; i++)
            {
                this.misPokemons.Remove(this.misPokemons[i]);
            }
        }
    }

    public void AtacarEspecial(Jugador jugador)
    {
        if (Combate.enCombate && this.turno && turnos > 1 && this.turnoAnteriorEspecial == false &&
            Combate.GetJugadoresActuales().Contains(jugador) && jugador.PokemonActual.VidaTotal > 0)
        {
            jugador.PokemonActual.VidaTotal -= this.PokemonActual.Tipo.AtaqueEspecial;
            this.turno = false;
            this.turnos += 1;
            this.turnoAnteriorEspecial = true;
            jugador.Turno = true;
        }
    }
    public void CambiarPokemon(IPokemon pokemon)
    {
        if (this.misPokemons.Contains(pokemon) && this.PokemonActual != pokemon)
        {
            this.PokemonActual = pokemon;
            this.turno = false;
        }
    }
}