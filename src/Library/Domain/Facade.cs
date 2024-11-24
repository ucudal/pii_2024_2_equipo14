using Library;
//Deberia imprimir en el discord en vez de en la Consola 
//Deberia implementar mas comandos para permitir que el juego funcione correctamente y poder elegir entre atacar,cambiar pokemon, 
namespace Library;

/// <summary>
/// Esta clase recibe las acciones y devuelve los resultados que permiten
/// implementar las historias de usuario. Otras clases que implementan el bot
/// usan esta <see cref="Facade"/> pero no conocen el resto de las clases del
/// dominio. Esta clase es un singleton.
/// </summary>
public class Facade
{
    private static Facade? _instance;

    // Este constructor privado impide que otras clases puedan crear instancias
    // de esta.
    private Facade()
    {
        this.ListaDeEspera = new ListaDeEspera();
        this.ListaBatallas = new ListaBatallas();
    }

    /// <summary>
    /// Obtiene la única instancia de la clase <see cref="Facade"/>.
    /// </summary>
    public static Facade Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Facade();
            }

            return _instance;
        }
    }

    /// <summary>
    /// Inicializa este singleton. Es necesario solo en los tests.
    /// </summary>
    public static void Reset()
    {
        _instance = null;
    }
    
    private ListaDeEspera ListaDeEspera { get; }
    
    private ListaBatallas ListaBatallas { get; }

    public Batalla EncontrarBatallaPorUsuario(string usuario)
    {
        foreach (Batalla batalla in this.ListaBatallas.GetBatallas())
        {
            if (batalla.GetNombreJ1() == usuario || batalla.GetNombreJ2() == usuario)
            {
                return batalla;
            }
        }
        return null;
    }
    /// <summary>
    /// Agrega un jugador a la lista de espera.
    /// </summary>
    /// <param name="displayName">El nombre del jugador.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string AgregarJugadorListaDeEspera(string displayName)
    {
        if (this.ListaDeEspera.AgregarEntrenador(displayName))
        {
            return $"{displayName} agregado a la lista de espera";
        }
        
        return $"{displayName} ya está en la lista de espera";
    }

    /// <summary>
    /// Remueve un jugador de la lista de espera.
    /// </summary>
    /// <param name="displayName">El jugador a remover.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string QuitarJugadorListaDeEspera(string displayName)
    {
        if (this.ListaDeEspera.QuitarEntrenador(displayName))
        {
            return $"{displayName} removido de la lista de espera";
        }
        else
        {
            return $"{displayName} no está en la lista de espera";
        }
    }

    /// <summary>
    /// Obtiene la lista de jugadores esperando.
    /// </summary>
    /// <returns>Un mensaje con el resultado.</returns>
    public string GetJugadoresEsperando()
    {
        if (this.ListaDeEspera.Count == 0)
        {
            return "No hay nadie esperando";
        }

        string result = "Esperan: ";
        foreach (Entrenador entrenador in this.ListaDeEspera.GetEsperando())
        {
            result += entrenador.Nombre + "; ";
        }
        
        return result;
    }

    /// <summary>
    /// Determina si un jugador está esperando para jugar.
    /// </summary>
    /// <param name="displayName">El jugador.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string JugadorEsperando(string displayName)
    {
        Entrenador? trainer = this.ListaDeEspera.EncontrarJugadorPorUsuario(displayName);
        if (trainer == null)
        {
            return $"{displayName} no está esperando";
        }
        
        return $"{displayName} está esperando";
    }

    /// <summary>
    /// Crea una batalla entre dos jugadores.
    /// </summary>
    /// <param name="playerDisplayName">El primer jugador.</param>
    /// <param name="opponentDisplayName">El oponente.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string ComenzarBatalla(string playerDisplayName, string? opponentDisplayName)
    {
        // El símbolo ? luego de Trainer indica que la variable opponent puede
        // referenciar una instancia de Trainer o ser null.
        Entrenador? opponent;
        
        if (!OpponentProvided() && !SomebodyIsWaiting())
        {
            return "No hay nadie esperando";
        }
        
        if (!OpponentProvided() && this.ListaDeEspera.Count > 0) 
        {
            opponent = this.ListaDeEspera.GetAlguienEsperando(opponentDisplayName);
            
            // El símbolo ! luego de opponent indica que sabemos que esa
            // variable no es null. Estamos seguros porque SomebodyIsWaiting
            // retorna true si y solo si hay usuarios esperando y en tal caso
            // GetAnyoneWaiting nunca retorna null.
            return this.CrearBatalla(playerDisplayName, opponent!.Nombre);
        }

        // El símbolo ! luego de opponentDisplayName indica que sabemos que esa
        // variable no es null. Estamos seguros porque OpponentProvided hubiera
        // retorna false antes y no habríamos llegado hasta aquí.
        opponent = this.ListaDeEspera.EncontrarJugadorPorUsuario(opponentDisplayName!);
        
        if (!OpponentFound())
        {
            return $"{opponentDisplayName} no está esperando";
        }
        
        return this.CrearBatalla(playerDisplayName, opponent!.Nombre);
        
        // Funciones locales a continuación para mejorar la legibilidad

        bool OpponentProvided()
        {
            return !string.IsNullOrEmpty(opponentDisplayName);
        }

        bool SomebodyIsWaiting()
        {
            return this.ListaDeEspera.Count != 0;
        }

        bool OpponentFound()
        {
            return opponent != null;
        }
    }

    private string CrearBatalla(string playerDisplayName, string opponentDisplayName)
    {
        
        this.ListaDeEspera.QuitarEntrenador(playerDisplayName);
        this.ListaDeEspera.QuitarEntrenador(opponentDisplayName);
        this.ListaBatallas.AgregarBatalla(playerDisplayName, opponentDisplayName);
        return $"Comienza la batalla entre {playerDisplayName} y {opponentDisplayName}";
    }

    public string MostrarPokedex()
    {
        return Mensaje.PokedexDisponibles();
    }
    public string AgregarPokemon(Entrenador entrenador, string nombre)
    {
        if (entrenador.miCatalogo.Count == 6)
        {
            return $"{entrenador.Nombre}, ya tienes 6 Pokémones";
        }
        Pokemon nuevo = Pokedex.BuscarPokemon(nombre);
        foreach (Pokemon pokemon in entrenador.miCatalogo)
        {
            if (pokemon.Nombre == nombre)
            {
                return $"{entrenador.Nombre}, ya tienes ese Pokemon";
            }
        }
        if (nuevo != null)
        {
            entrenador.AgregarPokemon(nuevo); 
            return $"{entrenador.Nombre} ha agregado a ¨{nuevo.Nombre}¨ de Tipo: {nuevo.Tipo}";
        }
        else
        {
            return "Pokémon inválido";
        }
    }
  
}
