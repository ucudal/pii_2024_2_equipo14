using System;
namespace Library;

public class Batalla
{
    public Entrenador Jugador1 { get; private set; }
    public Entrenador Jugador2 { get; private set; }
    public static bool EnBatalla { get; private set; }
    public static bool TurnoJ1 { get; private set; }
    public static bool TurnoJ2 { get; private set; }
    public Batalla(Entrenador jugador1, Entrenador jugador2)
    {
        this.Jugador1 = jugador1;
        this.Jugador2 = jugador2;
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
            TurnoJ1 = true;
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
            while (Jugador1.miCatalogo.Count > 0 && Jugador2.miCatalogo.Count > 0)
            {
                Consola.ElegirPokemon(Jugador1);
                string nPokemon = Console.ReadLine();
                int numeroPokemon = int.Parse(nPokemon);
                Consola.ElegirAtaque(Jugador1.miCatalogo[numeroPokemon]);
                string nAtaque = Console.ReadLine();
                
                
            }
        }

        
    }
}