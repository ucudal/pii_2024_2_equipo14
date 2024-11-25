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
    /// <param name="numero">El número que indica la acción.</param>
    /// <param name="entrenadorAtacado">El entrenador que no está en su turno.</param>
    
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

    public static bool ValidarAccion(Entrenador entrenador, string accion)
    {
        Pokemon pokemonActual = entrenador.PokemonActual;
        foreach (Pokemon pokemon in entrenador.miCatalogo)
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
            if (entrenador.miCatalogo.Count < 2 )
            {
                return false;
            }
        }

        if (accion == "Usar Item" && entrenador.misItems.Count > 0)
        {
            foreach (Pokemon pokemon in entrenador.miCatalogo)
            {
                if (pokemon.VidaTotal < pokemon.VidaInicial || pokemon.Paralizado || pokemon.Dormido || 
                    pokemon.Envenenado || pokemon.Quemado)
                {
                    return true;
                }
            }

            if (entrenador.misMuertos.Count > 0)
            {
                return true;
            }

            return false;
        }
        return true;
    }

    public static bool ValidarAtaque(Entrenador entrenador, Ataque ataque, Pokemon pokemonAtacado)
    {
        if (ataque is AtaqueEspecial && (entrenador.Turnos % 2 == 1 || pokemonAtacado.Paralizado || pokemonAtacado.Dormido || pokemonAtacado.Envenenado || 
                                         pokemonAtacado.Quemado))
        {
            return false;
        }
        return true;
    }
    public static bool ValidarItem(Entrenador entrenador, Item item, Pokemon pokemon)
    {
        if (item is Revivir && entrenador.misMuertos.Contains(pokemon))
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