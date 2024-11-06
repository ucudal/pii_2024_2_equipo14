namespace Library;

public static class Turno
{
    private static List<string> acciones = new List<string> { "Atacar", "Cambiar Pokemon", "Usar item" };

    public static List<string> GetAcciones() {return acciones;}
    
    public static void MiTurno(Entrenador entrenador)
    {
        if (entrenador.MiTurno)
        {
            if (entrenador.PokemonActual.VidaTotal <= 0)
            {
                Consola.ElegirPokemon(entrenador);
                string pokemon = Console.ReadLine();
                int numeroPokemon = int.Parse(pokemon);
                entrenador.PokemonActual = entrenador.miCatalogo[numeroPokemon];
            }
            else
            {
                if (entrenador.PokemonActual.Quemado)
                {
                    entrenador.PokemonActual.RecibirDano(entrenador.PokemonActual.VidaTotal*10/100);
                }

                if (entrenador.PokemonActual.Envenenado)
                {
                    entrenador.PokemonActual.RecibirDano(entrenador.PokemonActual.VidaTotal*5/100);
                }
                Consola.AccionesDeTurno();
                string accion = Console.ReadLine();
            
                if (entrenador.PokemonActual.Paralizado && entrenador.PokemonActual.PuedeAtacar() == 0)
                {
                    Console.WriteLine("No se puede elegir atacar");
                }

                while (accion == "0")
                {
                    Console.WriteLine("Elegi otra opción");
                    accion = Console.ReadLine();
                } 
                if (accion == "0")
                {
                    Consola.ElegirAtaque(entrenador.PokemonActual);
                    string ataque = Console.ReadLine();
                    int nroAtaque = int.Parse(ataque);
                    if (entrenador == Batalla.Jugador1)
                    {
                        Enfrentamiento.Atacar(entrenador.PokemonActual.misAtaques[nroAtaque],Batalla.Jugador2);
                    }
                    else
                    {
                        Enfrentamiento.Atacar(entrenador.PokemonActual.misAtaques[nroAtaque], Batalla.Jugador1);
                    }
                }

                if (accion == "1")
                {
                    Consola.ElegirPokemon(entrenador);
                    string pokemon = Console.ReadLine();
                    int numeroPokemon = int.Parse(pokemon);
                    entrenador.PokemonActual = entrenador.miCatalogo[numeroPokemon];
                }

                if (accion == "2")
                {
                    Consola.ElegirItem(entrenador);
                    string item = Console.ReadLine();
                    int numeroItem = int.Parse(item);
                    if (entrenador.MisItems[numeroItem] is SuperPocion superPocion)
                    {
                       superPocion.SuperPocionar(entrenador.PokemonActual);
                       entrenador.QuitarItem(superPocion);
                    }
                    if (entrenador.MisItems[numeroItem] is Revivir revivir )
                    {
                        revivir.RevivirPokemon(entrenador.PokemonActual);
                        entrenador.QuitarItem(revivir);
                        entrenador.AgregarPokemon();
                    }
                    if (entrenador.MisItems[numeroItem] is CuraTotal curaTotal)
                    {
                        superPocion.SuperPocionar(entrenador.PokemonActual);
                        entrenador.QuitarItem(superPocion);
                    }
                }
            }
            
            
            
            
        }
       
    }

}