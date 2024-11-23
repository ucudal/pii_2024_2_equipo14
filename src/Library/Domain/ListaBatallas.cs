namespace Library;

/// <summary>
/// Esta clase representa la lista de batallas en curso.
/// </summary>
public class ListaBatallas
{
    private List<Batalla> batallas = new List<Batalla>();

    /// <summary>
    /// Crea una nueva batalla entre dos jugadores.
    /// </summary>
    /// <param name="j1">El primer jugador.</param>
    /// <param name="j2">El oponente.</param>
    /// <returns>La batalla creada.</returns>
    public Batalla AgregarBatalla(string j1, string j2)
    {
        Entrenador jugador1 = new Entrenador(j1);
        Entrenador jugador2 = new Entrenador(j2);
        var battle = new Batalla(jugador1, jugador2);
        return battle;
    }
}
