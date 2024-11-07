namespace Library;

public static class Turno
{
    public static void HacerAccion(Entrenador entrenador, string numero, Entrenador entrenadorAtacado)
    {
        Pokemon pokemonActual = entrenador.PokemonActual;
        Pokemon pokemonAtacado = entrenadorAtacado.PokemonActual;

if (pokemonActual.VidaTotal == 0 || pokemonActual.Dormido && numero == "0")
        {
            if (pokemonActual.TurnosDormido == entrenador.Turnos)
            {
                pokemonActual.Dormido = false;
            }
            else
            {
                while (numero == "0")
                {
                    Console.WriteLine("\nNo se puede elegir atacar, su pokemon está muerto o dormido elija otra opción");
                    Consola.ElegirAccion();
                    numero = Console.ReadLine();
                }
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
                    Console.WriteLine("\nNo se puede elegir atacar, su pokemon esta paralizado elija otra opción");
                    Consola.ElegirAccion();
                    numero = Console.ReadLine();
                }
            }
        }

        if (pokemonActual.Envenenado)
        {
            pokemonActual.RecibirDano(pokemonActual.VidaTotal*5/100);
            Consola.ImprimirDatos(entrenador); //imprimir datos
        }
        else if (pokemonActual.Quemado)
        {
            pokemonActual.RecibirDano(pokemonActual.VidaTotal*10/100);
            Consola.ImprimirDatos(entrenador); //imprimir datos
        }
        if (pokemonActual.VidaTotal == 0)
        {
            entrenador.QuitarPokemon(pokemonActual);
            entrenador.AgregarMuerto(pokemonActual);
            Console.WriteLine($"\tTu pokemon {pokemonActual.Nombre} ha muerto");
            Console.WriteLine($"Puede cambiarlo o usar un item");
            Consola.ElegirAccion();
            numero = Console.ReadLine();
            while (numero == "0")
            {
                Console.WriteLine("Elija una opción válida");
                numero = Console.ReadLine();
            }
            Consola.ImprimirDatos(entrenador); //imprimir datos

        }
        
        if (numero == "0")
        {
            int indiceAtaque;
            if (pokemonAtacado.Dormido || pokemonAtacado.Paralizado || pokemonAtacado.Envenenado ||
                pokemonAtacado.Quemado)
            {
                Consola.ElegirAtaqueSimple(pokemonActual);
                string ataque = Console.ReadLine();
                indiceAtaque = int.Parse(ataque);
            }
            else
            {
                Consola.ElegirAtaque(pokemonActual);
                string ataque = Console.ReadLine();
                indiceAtaque = int.Parse(ataque);
            }

            Random golpeCritico = new Random();
            int golpe = golpeCritico.Next(0, 10);
            int critico;
            if (golpe == 9)
            {
                critico = 0;
            }
            else
            {
                critico = 1;
            }
            
            if (pokemonActual.ataques[indiceAtaque] is AtaqueEspecial ataqueEspecial)
            {
                if (ataqueEspecial.CalcularPrecision() == 0)
                {
                    
                    if (ataqueEspecial is Maniqui maniqui)
                    {
                        maniqui.Paralizar(pokemonAtacado);
                    }

                    if (ataqueEspecial is Incendio incendio)
                    {
                        incendio.Quemar(pokemonAtacado, critico);
                    }

                    if (ataqueEspecial is Off off)
                    {
                        off.Envenenar(pokemonAtacado, critico);
                    }

                    if (ataqueEspecial is Zzz zzz)
                    {
                        zzz.Dormir(entrenadorAtacado,pokemonAtacado);
                    }
                    Consola.ImprimirDatos(entrenadorAtacado); //imprimir datos
                }
               
            }
            else
            {
                Ataque ataque = pokemonActual.ataques[indiceAtaque];
                if (ataque.CalcularPrecision() == 0);
                {
                    int dano = Efectividad.CalcularEfectividad(ataque, pokemonAtacado);
                    if (critico == 0)
                    {
                        dano *= 120 / 100;
                    }
                    pokemonAtacado.RecibirDano(dano);
                    Consola.ImprimirDatos(entrenadorAtacado); //imprimir datos
                }
            }
            if (pokemonAtacado.VidaTotal == 0)
            {
                entrenadorAtacado.QuitarPokemon(pokemonAtacado);
                entrenadorAtacado.AgregarMuerto(pokemonAtacado);
                Consola.ImprimirDatos(entrenadorAtacado); //imprimir datos
            }
        }

        if (numero == "1")
        {
            Consola.ElegirPokemon(entrenador);
            string pokemon = Console.ReadLine();
            int pokemonElegido = int.Parse(pokemon);
            entrenador.PokemonActual = entrenador.miCatalogo[pokemonElegido];
        }

        if (numero == "2")
        {
            Consola.ElegirItem(entrenador);
            string item = Console.ReadLine();
            int itemElegido = int.Parse(item);
            if (entrenador.misItems[itemElegido] is Revivir revivir)
            {
                Consola.ElegirPokemonMuerto(entrenador);
                string pokemonMuerto = Console.ReadLine();
                int pokemonElegido = int.Parse(pokemonMuerto);
                Pokemon pokemonARevivir = entrenador.misMuertos[pokemonElegido];
                revivir.RevivirPokemon(entrenador,pokemonARevivir);
                Consola.ImprimirDatos(entrenador); //imprimir datos
            }
            else
            {
                Consola.ElegirPokemonHerido(entrenador);
                string _pokemon = Console.ReadLine();
                int pokemonElegido = int.Parse(_pokemon);
                Pokemon pokemon= entrenador.miCatalogo[pokemonElegido];
                if (entrenador.misItems[itemElegido] is CuraTotal curaTotal && (pokemon.Dormido || pokemon.Paralizado
                    || pokemon.Envenenado || pokemon.Quemado))
                {
                    curaTotal.CurarTotalmente(entrenador,pokemon);
                    Consola.ImprimirDatos(entrenador); //imprimir datos
                }
                else
                {
                    Console.WriteLine("\tElige otro item. Ningun pokemon está bajo algún efecto");
                    Consola.ElegirItem(entrenador);
                    while (entrenador.misItems[itemElegido] is CuraTotal || entrenador.misItems[itemElegido] is Revivir)
                    {
                        string nuevoItem = Console.ReadLine();
                        int nuevoItemElegido = int.Parse(nuevoItem);
                    }
                    
                }
                if (entrenador.misItems[itemElegido] is SuperPocion superPocion)
                {
                    superPocion.SuperPocionar(entrenador,pokemon);
                    Consola.ImprimirDatos(entrenador); //imprimir datos
                }
            }
        }
        entrenador.MiTurno = false;

    }
}