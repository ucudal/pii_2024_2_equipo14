using System;
namespace Library;

public class Batalla
{
    public static Entrenador Jugador1 { get; private set; }
    public static Entrenador Jugador2 { get; private set; }
    public static bool EnBatalla { get; private set; }
   
    public Batalla(Entrenador jugador1, Entrenador jugador2)
    {
        Jugador1 = jugador1;
        Jugador2 = jugador2;
    }
    public void ComenzarBatalla()
    {
        if (Jugador1.miCatalogo.Count < 6 || Jugador2.miCatalogo.Count < 6)
        {
            Console.WriteLine("No se puede dar comienzo a la batalla. Deben tener 6 pokemons cada uno.");
        }
        else
        {
            EnBatalla = true;
            Jugador1.MiTurno = true;
            Jugador1.Turnos += 1;
            Jugador1.MisItems = new List<Item>
            {
                new SuperPocion(), new SuperPocion(), new SuperPocion(), new SuperPocion(),
                new Revivir(), new CuraTotal(), new CuraTotal()
            };
            Jugador2.MisItems = new List<Item>
            {
                new SuperPocion(), new SuperPocion(), new SuperPocion(), new SuperPocion(),
                new Revivir(), new CuraTotal(), new CuraTotal()
            };
            
            Random pokemonAleatorio = new Random();
            int random1 = pokemonAleatorio.Next(0,6);
            int random2 = pokemonAleatorio.Next(0,6);
            Jugador1.PokemonActual = Jugador1.miCatalogo[random1];
            Jugador2.PokemonActual = Jugador2.miCatalogo[random2];
            
            while (Jugador1.miCatalogo.Count > 0 && Jugador2.miCatalogo.Count > 0)
            {
                Turno.MiTurno(Jugador1);
                
                



            }
        }

        
    }
}