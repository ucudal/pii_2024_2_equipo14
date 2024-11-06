namespace Library;

public static class Enfrentamiento
{
    public static void Atacar(Ataque ataque, Entrenador entrenador)
    {
        if (ataque.Dano > 0)
        {
            Random precision = new Random();
            int preciso = precision.Next(0, ataque.Precision);
            if (preciso == 0)
            {
                int dano = Efectividad.CalcularEfectividad(ataque, entrenador.PokemonActual);
                Random golpeCritico = new Random();
                int golpe = golpeCritico.Next(0, 10);
                if (golpe == 5)
                {
                    entrenador.PokemonActual.RecibirDano(dano*120/100);
                }
                else
                {
                    entrenador.PokemonActual.RecibirDano(dano);
                }

                if (entrenador.PokemonActual.VidaTotal == 0)
                {
                    if (entrenador.MisItems.Exists(item => item.Nombre == "Revivir"))
                    {
                        Consola.ElegirRevivir(entrenador.PokemonActual);
                        string decision = Console.ReadLine();
                        if (decision == "0")
                        {
                        
                        }
                    }
                    
                    entrenador.QuitarPokemon(entrenador.PokemonActual);
                }
            }
        }
        if (ataque is AtaqueEspecial && entrenador.PokemonActual.VidaTotal > 0)
        {
            if (ataque.Nombre == "Incendio")
            {
                Incendio.Quemar(entrenador.PokemonActual);
            }
            else if (ataque.Nombre == "Maniqui")
            {
                Maniqui.Paralizar(entrenador.PokemonActual);
            }
            else if (ataque.Nombre == "Off")
            {
                Off.Envenenar(entrenador.PokemonActual);
            }
            else if (ataque.Nombre == "Zzz")
            {
                Zzz.Dormir(entrenador);
            }
            if (entrenador.PokemonActual.VidaTotal == 0)
            {
                entrenador.QuitarPokemon(entrenador.PokemonActual);
            }
        }
    }
}