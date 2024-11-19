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
    public static string HacerAccion(Entrenador entrenador, string numero, Entrenador entrenadorAtacado, 
        int usarRevivir, int usarSuperPocion, int usarCuraTotal, FacadeJuego facadeJuego)
    {
        facadeJuego.ImprimirDatos(entrenador);
        facadeJuego.ImprimirDatos(entrenadorAtacado);
        Pokemon pokemonActual = entrenador.PokemonActual;
        Pokemon pokemonAtacado = entrenadorAtacado.PokemonActual;

        if (pokemonActual.VidaTotal == 0)
        {
            entrenador.QuitarPokemon(pokemonActual);
            entrenador.AgregarMuerto(pokemonActual);
            facadeJuego.PokemonMuerto(pokemonActual);
            return "Tu Pokémon ha sido derrotado. Elige otra acción."; // Mensaje de retorno
        }

        // Manejo de estados de Pokémon
        foreach (Pokemon pokemon in entrenador.miCatalogo)
        {
            if (pokemon.TurnosDormido == entrenador.Turnos)
                pokemon.Dormido = false;
        }

        if (pokemonActual.Dormido && numero == "0")
        {
            return "Tu Pokémon está dormido. Elige otra acción."; // Mensaje de retorno
        }

        if (pokemonActual.Paralizado && numero == "0")
        {
            Random poderAtacar = new Random();
            int randomPoderAtacar = poderAtacar.Next(0, 3);
            if (randomPoderAtacar == 0)
            {
                return "Tu Pokémon está paralizado y no puede atacar. Elige otra acción."; // Mensaje de retorno
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

        // Ejecutar la acción
        switch (numero)
        {
            case "0":
                Atacar.Encuentro(entrenador, entrenadorAtacado);
                return "Has atacado al Pokémon enemigo."; // Mensaje de retorno
            case "1":
                CambiarPokemon.CambioDePokemon(entrenador);
                return "Has cambiado tu Pokémon."; // Mensaje de retorno
            case "2":
                UsarItem.UsoDeItem(entrenador, usarRevivir, usarSuperPocion, usarCuraTotal);
                return "Has usado un ítem."; // Mensaje de retorno
            default:
                return "Acción no válida. Elige otra acción."; // Mensaje de retorno
        }
    }
}