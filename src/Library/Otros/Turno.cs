namespace Library;
/// <summary>
/// Esta es la clase estática Turno. Se encarga de realizar la acción que decide el usuario.
/// </summary>
public static class Turno
{
    /// <summary>
    /// Se encarga de realizar la acción que el usuario decidió hacer.
    /// </summary>
    /// <param name="entrenador">El entrenador que elige acción.</param>
    /// <param name="accion">La acción a realizar.</param>
    /// <param name="entrenadorAtacado">El entrenador que no está en su turno.</param>
    /// <param name="ataque">El ataque a realizar.</param>
    /// <param name="pokemon">El Pokémon a cambiar.</param>
    /// <param name="item">El item a utilizar.</param>
    /// /// <param name="pokemon2">El Pokémon en el que se va usar el item.</param>
    
    public static void HacerAccion(Entrenador entrenador, string accion, Entrenador entrenadorAtacado, Ataque? ataque, string? pokemon, Item? item, Pokemon? pokemon2)
    {
        if (accion == "Atacar")
        {
            Atacar.Encuentro(entrenador,ataque,entrenadorAtacado);
        }
        if (accion == "Cambiar Pokémon")
        {
            CambiarPokemon.CambioDePokemon(entrenador, pokemon);
        }

        if (accion == "Usar Item")
        {
            UsarItem.UsoDeItem(entrenador,item,pokemon2);
        }
        entrenador.MiTurno = false;
        entrenadorAtacado.MiTurno = true;
        entrenador.Turnos += 1;
    }
    /// <summary>
    /// Se encarga de validar la acción que quiere realizar el entrenador.
    /// </summary>
    /// <param name="entrenador">El entrenador que elige acción.</param>
    /// <param name="accion">La acción a realizar.</param>

    public static bool ValidarAccion(Entrenador entrenador, string accion)
    {
        if (entrenador.MiTurno == false)
        {
            return false;
        }
        Pokemon pokemonActual = entrenador.PokemonActual;
        foreach (Pokemon pokemon in entrenador.GetMiCatalogo())
        {
            if (pokemon.Dormido && pokemon.TurnosDormido == entrenador.Turnos)
            {
                pokemon.Dormido = false;
            }

            if (pokemon.Envenenado)
            {
                pokemon.RecibirDano(pokemon.VidaTotal * 5 / 100);
            }

            if (pokemon.Quemado)
            {
                pokemon.RecibirDano(pokemon.VidaTotal * 10 / 100);
            }
        }
        if (accion == "Atacar")
        {
            Random random = new Random();
            int poderAtacar = random.Next(0, 3);
            if (pokemonActual.Dormido || (pokemonActual.Paralizado && poderAtacar != 0) || pokemonActual.VidaTotal == 0)
            {
                return false;
            }
        }
        if (accion == "Cambiar Pokémon")
        {
            if (entrenador.GetMiCatalogo().Count < 2 )
            {
                return false;
            }
        }

        if (accion == "Usar Item" && entrenador.GetMisItems().Count > 0)
        {
            foreach (Pokemon pokemon in entrenador.GetMiCatalogo())
            {
                if (pokemon.VidaTotal < pokemon.VidaInicial || pokemon.Paralizado || pokemon.Dormido || 
                    pokemon.Envenenado || pokemon.Quemado)
                {
                    return true;
                }
            }

            if (entrenador.GetMisMuertos().Count > 0)
            {
                return true;
            }

            return false;
        }
        return true;
    }
    /// <summary>
    /// Se encarga de validar el ataque que quiere realizar el entrenador.
    /// </summary>
    /// <param name="entrenador">El entrenador que elige acción.</param>
    /// <param name="ataque">El ataque a utilizar.</param>
    /// <param name="pokemonAtacado">El Pokémon que recibiría ese ataque.</param>
    public static bool ValidarAtaque(Entrenador entrenador, Ataque ataque, Pokemon pokemonAtacado)
    {
        if (ataque is AtaqueEspecial && (entrenador.Turnos % 2 == 1 || pokemonAtacado.Paralizado || pokemonAtacado.Dormido || pokemonAtacado.Envenenado || 
                                         pokemonAtacado.Quemado))
        {
            return false;
        }
        return true;
    }
    /// <summary>
    /// Se encarga de validar el item que quiere utilizar el entrenador.
    /// </summary>
    /// <param name="entrenador">El entrenador que elige acción.</param>
    /// <param name="item">El item a utilizar.</param>
    /// <param name="pokemon">El pokemon que se vería afectado por el item</param>
    public static bool ValidarItem(Entrenador entrenador, Item item, Pokemon pokemon)
    {
        if (item is Revivir && entrenador.GetMisMuertos().Contains(pokemon))
        {
            return true;
        }

        if (item is CuraTotal && (pokemon.Paralizado || pokemon.Dormido || pokemon.Envenenado || pokemon.Quemado))
        {
            return true;
        }

        if (item is SuperPocion && pokemon.VidaTotal < pokemon.VidaInicial)
        {
            return true;
        }
        return false; 
    }
}