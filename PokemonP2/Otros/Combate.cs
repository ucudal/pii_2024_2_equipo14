using System.Net;

namespace PokemonP2;

public class Combate
{
    public static bool enCombate;
    private static List<Jugador> jugadoresActuales = new List<Jugador>();

    public static List<Jugador> GetJugadoresActuales()
    {
        return jugadoresActuales;
    }
    public static void IniciarCombate(Jugador jugador1, Jugador jugador2)
    {
        jugadoresActuales.Add(jugador1);
        jugadoresActuales.Add(jugador2);
        jugador1.Turno = true;
        enCombate = true;
        Console.WriteLine($"Ha comenzado el combate entre {jugador1.GetNombre()} y {jugador2.GetNombre()}");
    }

    public static void FinalizarCombate()
    {
        enCombate = false;
        Console.WriteLine("Ha finalizado el combate.");
        if (jugadoresActuales[0].GetMisPokemons().Count > jugadoresActuales[1].GetMisPokemons().Count)
        {
            Console.WriteLine($"Ha ganado {jugadoresActuales[0].GetNombre()}.");
        }
        else
        {
            Console.WriteLine($"Ha ganado {jugadoresActuales[1].GetNombre()}.");
        }
        jugadoresActuales[0].Turno = false;
        jugadoresActuales[1].Turno = false;
        jugadoresActuales[0].Turnos = 0;
        jugadoresActuales[1].Turnos = 0;
        jugadoresActuales.Remove(jugadoresActuales[0]);
        jugadoresActuales.Remove(jugadoresActuales[1]);

    }
}