namespace PokemonP2;

public class Jugador
{
    private string nombre;
    private List<IPokemon> misPokemons = new List<IPokemon>();
    private IPokemon pokemonActual;
    private bool turno;
    private bool turnoAnteriorEspecial;
    private int turnos;

    public string GetNombre()
    {
        return this.nombre;
    }

    public List<IPokemon> GetMisPokemons()
    {
        return this.misPokemons;
    }

    public IPokemon PokemonActual
    {
        get { return pokemonActual; }
        set { this.pokemonActual = value; }
    }

    public bool Turno
    {
        get { return this.turno;}
        set { this.turno = value; }
    }

    public int Turnos
    {
        get
        {
            return this.turnos;
        }
        set
        {
            this.turnos = value;
        }
    }

    public Jugador(string nombre)
    {
        this.nombre = nombre;
    }
    public void AgregarPokemon(IPokemon pokemon)
    {
        if (Combate.enCombate == false && !this.misPokemons.Contains(pokemon) && this.misPokemons.Count < 6)
        {
            this.misPokemons.Add(pokemon);
        }
    }
    public void EliminarPokemon(IPokemon pokemon)
    {
        if (Combate.enCombate == false && this.misPokemons.Contains(pokemon))
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
            this.Turno = false;
            this.Turnos += 1;
            this.turnoAnteriorEspecial = false;
            jugador.Turno = true;
            Console.WriteLine($"Es el turno {this.turnos} de {this.nombre}.");
            Console.WriteLine($"{this.nombre} con {this.pokemonActual.Nombre} atacó a {jugador.pokemonActual.Nombre} de {jugador.GetNombre()}.");
            Console.WriteLine($"La nueva vida de {jugador.pokemonActual.Nombre} es de {jugador.PokemonActual.VidaTotal}");
            
        }
        else
        {
          Console.WriteLine("No se ha podido concretar el ataque.");
        }
        if (jugador.PokemonActual.VidaTotal <= 0)
        {
            Console.WriteLine($"{jugador.PokemonActual.Nombre} ha muerto.");
            jugador.misPokemons.Remove(pokemonActual);
        }

        if (jugador.misPokemons.Count == 0)
        {
            Combate.FinalizarCombate();
            for (int i = 0; i < this.misPokemons.Count; i++)
            {
                this.misPokemons.Remove(this.misPokemons[i]);
            }
        }
    }

    public void AtacarEspecial(Jugador jugador)
    {
        if (Combate.enCombate && this.turno && this.turnos >= 1 && this.turnoAnteriorEspecial == false &&
            Combate.GetJugadoresActuales().Contains(jugador) && jugador.PokemonActual.VidaTotal > 0)
        {
            jugador.PokemonActual.VidaTotal -= this.PokemonActual.Tipo.AtaqueEspecial;
            this.Turno = false;
            this.Turnos += 1;
            this.turnoAnteriorEspecial = true;
            jugador.Turno = true;
            Console.WriteLine($"Es el turno {this.turnos} de {this.nombre}.");
            Console.WriteLine($"{this.nombre} con {this.pokemonActual.Nombre} usó el ataque especial contra {jugador.pokemonActual.Nombre} de {jugador.GetNombre()}.");
            Console.WriteLine($"La nueva vida de {jugador.pokemonActual.Nombre} es de {jugador.PokemonActual.VidaTotal}");
        }
        else
        {
            Console.WriteLine("No se ha podido concretar el ataque.");
        }
        if (jugador.PokemonActual.VidaTotal <= 0)
        {
            Console.WriteLine($"{jugador.PokemonActual} ha muerto.");
            jugador.misPokemons.Remove(pokemonActual);
        }

        if (jugador.misPokemons.Count == 0)
        {
            Combate.FinalizarCombate();
            for (int i = 0; i < this.misPokemons.Count; i++)
            {
                this.misPokemons.Remove(this.misPokemons[i]);
            }
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