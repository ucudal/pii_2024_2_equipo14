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
    public Combate(Jugador jugador1, Jugador jugador2)
    {
        jugadoresActuales.Add(jugador1);
        jugadoresActuales.Add(jugador2);
        jugador1.Turno = true;
        enCombate = true;
    }

    public static void Finalizar()
    {
        enCombate = false;
        jugadoresActuales[0].Turno = false;
        jugadoresActuales[1].Turno = false;
        jugadoresActuales[0].Turnos = 0;
        jugadoresActuales[1].Turnos = 0;
        jugadoresActuales.Remove(jugadoresActuales[0]);
        jugadoresActuales.Remove(jugadoresActuales[1]);

    }
}