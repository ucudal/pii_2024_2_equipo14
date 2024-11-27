using System.Collections.ObjectModel;

namespace Library;

/// <summary>
/// Esta clase representa la lista de jugadores esperando para jugar.
/// </summary>
public class ListaDeEspera
{
    private readonly List<Entrenador> entrenadores = new List<Entrenador>();

    public int Count
    {
        get { return this.entrenadores.Count; }
    }

    public ReadOnlyCollection<Entrenador> GetEsperando()
    {
        return this.entrenadores.AsReadOnly();
    }
    
    /// <summary>
    /// Agrega un jugador a la lista de espera.
    /// </summary>
    /// <param name="displayName">El nombre de usuario de Discord en el servidor
    /// del bot a agregar.
    /// </param>
    /// <returns><c>true</c> si se agrega el usuario; <c>false</c> en caso
    /// contrario.</returns>
    public bool AgregarEntrenador(string displayName)
    {
        if (string.IsNullOrEmpty(displayName))
        {
            throw new ArgumentException(nameof(displayName));
        }
        
        if (this.EncontrarJugadorPorUsuario(displayName) != null) return false;
        entrenadores.Add(new Entrenador(displayName));
        return true;

    }

    /// <summary>
    /// Remueve un jugador de la lista de espera.
    /// </summary>
    /// <param name="displayName">El nombre de usuario de Discord en el servidor
    /// del bot a remover.
    /// </param>
    /// <returns><c>true</c> si se remueve el usuario; <c>false</c> en caso
    /// contrario.</returns>
    public bool QuitarEntrenador(string displayName)
    {
        Entrenador? entrenador = this.EncontrarJugadorPorUsuario(displayName);
        if (entrenador == null) return false;
        entrenadores.Remove(entrenador);
        return true;

    }

    /// <summary>
    /// Busca un jugador por el nombre de usuario de Discord en el servidor del
    /// bot.
    /// </summary>
    /// <param name="displayName">El nombre de usuario de Discord en el servidor
    /// del bot a buscar.
    /// </param>
    /// <returns>El jugador encontrado o <c>null</c> en caso contrario.
    /// </returns>
    public Entrenador? EncontrarJugadorPorUsuario(string displayName)
    {
        foreach (Entrenador entrenador in this.entrenadores)
        {
            if (entrenador.Nombre == displayName)
            {
                return entrenador;
            }
        }

        return null;
    }

    /// <summary>
    /// Retorna un jugador cualquiera esperando para jugar.
    /// </summary>
    /// <returns>Entrenador</returns>
    public Entrenador? GetAlguienEsperando(string displayName)
    {
        if (this.entrenadores.Count == 0)
        {
            return null;
        }
        foreach (Entrenador entrenador in this.entrenadores)
        {
            if (entrenador.Nombre == displayName)
                return entrenador;
        }
        return null;
    }
}
