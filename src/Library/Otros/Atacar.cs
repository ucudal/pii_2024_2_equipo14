namespace Library;
/// <summary>
/// Esta es la clase estática Atacar. Define las acciones a seguir cuando el usuario elige atacar durante la batalla.
/// </summary>
public static class Atacar
{
    /// <summary>
    /// Determina si un Pokémon ataca a otro y con que ataque de acuerdo a la precisión, efectividad, golpe crítico y efectos.
    /// </summary>
    /// <param name="atacante">El entrenador que posee al Pokémon que ataca.</param>
    /// <param name="ataque">El ataque que afecta al Pokémon ingresado.</param>
    /// <param name="victima">El entrenador que posee al Pokémon que es atacado.</param>
    public static void Encuentro(Entrenador atacante, Ataque ataque, Entrenador victima)
    {
        Pokemon pokemonActual = atacante.PokemonActual;
        Pokemon pokemonAtacado = victima.PokemonActual;
        if (ataque is AtaqueEspecial ataqueEspecial)
        {
            if (ataqueEspecial.CalcularPrecision() == 0)
            {
                ataqueEspecial.CausarEfecto(atacante, pokemonAtacado);
            }
        }
        else 
        { 
            Random golpeCritico = new Random();
            int critico = golpeCritico.Next(0, 10);
            if (ataque.CalcularPrecision() == 0) ;
            {
                int dano = Efectividad.CalcularEfectividad(ataque, pokemonAtacado);
                if (critico == 0)
                {
                    dano *= 120 / 100;
                } 
                pokemonAtacado.RecibirDano(dano);
            }
        }
        if (pokemonAtacado.VidaTotal == 0)
        { 
            victima.QuitarPokemon(pokemonAtacado);
            victima.AgregarMuerto(pokemonAtacado);
        }
    }
}