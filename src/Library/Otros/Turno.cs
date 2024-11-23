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
    public static void HacerAccion(Entrenador entrenador, string numero, Entrenador entrenadorAtacado, 
        int usarRevivir, int usarSuperPocion, int usarCuraTotal, FacadeJuego facade)
    {
        facade.ImprimirDatos(entrenador);
        facade.ImprimirDatos(entrenadorAtacado);
        Pokemon pokemonActual = entrenador.PokemonActual;
        Pokemon pokemonAtacado = entrenadorAtacado.PokemonActual;
        if (pokemonActual.VidaTotal == 0)
        {
            entrenador.QuitarPokemon(pokemonActual);
            entrenador.AgregarMuerto(pokemonActual);
            facade.PokemonMuerto(pokemonActual);
            facade.ElegirAccion();
            numero = Console.ReadLine();  //CAMBIAR A BOT
            while (numero == "0")
            {
                facade.AtacarInvalido();
                numero = Console.ReadLine(); //CAMBIAR  A BOT
            }
        }
        foreach (Pokemon pokemon in entrenador.miCatalogo)
        {
            if (pokemon.TurnosDormido == entrenador.Turnos)
                pokemon.Dormido = false;
        }

        if (pokemonActual.Dormido && numero == "0")
        {
            while (numero == "0")
            {
                facade.AtacarInvalido();
                facade.ElegirAccion();
                numero = Console.ReadLine(); //CAMBIAR A BOT
            }
        }

        if (pokemonActual.Paralizado && numero == "0")
        {
            Random poderAtacar = new Random();
            int randomPoderAtacar = poderAtacar.Next(0, 3);
            if (randomPoderAtacar != 0)
            {
                while (numero == "0")
                {
                    facade.AtacarInvalido(); 
                    facade.ElegirAccion();
                    numero = Console.ReadLine(); //CAMBIAR A BOT
                }
            }
        }

        foreach (Pokemon pokemon in entrenador.miCatalogo)
        {
            if (pokemon.Envenenado)
            {
                pokemon.RecibirDano(pokemon.VidaTotal * 5 / 100);

            }

            if (pokemon.Quemado)
            {
                pokemon.RecibirDano(pokemon.VidaTotal * 10 / 100);
            }
        }
        if (numero == "0")
        {
          Atacar.Encuentro(entrenador,entrenadorAtacado);
        }

        if (numero == "1")
        {
            CambiarPokemon.CambioDePokemon(entrenador);
        }

        if (numero == "2")
        {
         UsarItem.UsoDeItem(entrenador,usarRevivir,usarSuperPocion,usarCuraTotal);
        } 
        entrenador.MiTurno = false;
    }
}