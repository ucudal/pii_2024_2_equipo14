using Library;
//Deberia imprimir en el discord en vez de en la Consola 
//Deberia implementar mas comandos para permitir que el juego funcione correctamente y poder elegir entre atacar,cambiar pokemon, 
namespace Ucu.Poo.DiscordBot.Domain;

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
        this.WaitingList = new WaitingList();
        this.BattlesList = new BattlesList();
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
    
    private WaitingList WaitingList { get; }
    
    private BattlesList BattlesList { get; }

    /// <summary>
    /// Agrega un jugador a la lista de espera.
    /// </summary>
    /// <param name="displayName">El nombre del jugador.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string AddTrainerToWaitingList(string displayName)
    {
        if (this.WaitingList.AddTrainer(displayName))
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
    public string RemoveTrainerFromWaitingList(string displayName)
    {
        if (this.WaitingList.RemoveTrainer(displayName))
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
    public string GetAllTrainersWaiting()
    {
        if (this.WaitingList.Count == 0)
        {
            return "No hay nadie esperando";
        }

        string result = "Esperan: ";
        foreach (Trainer trainer in this.WaitingList.GetAllWaiting())
        {
            result += trainer.DisplayName + "; ";
        }
        
        return result;
    }

    /// <summary>
    /// Determina si un jugador está esperando para jugar.
    /// </summary>
    /// <param name="displayName">El jugador.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string TrainerIsWaiting(string displayName)
    {
        Trainer? trainer = this.WaitingList.FindTrainerByDisplayName(displayName);
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
    public string StartBattle(string playerDisplayName, string? opponentDisplayName)
    {
        Trainer? opponent;

        if (!OpponentProvided() && !SomebodyIsWaiting())
        {
            return "No hay nadie esperando";
        }
        
        if (!OpponentProvided())
        {
            opponent = this.WaitingList.GetAnyoneWaiting();
            return CreateBattle(playerDisplayName, opponent!.DisplayName);
        }

        opponent = this.WaitingList.FindTrainerByDisplayName(opponentDisplayName!);
        
        if (!OpponentFound())
        {
            return $"{opponentDisplayName} no está esperando";
        }
        
        return CreateBattle(playerDisplayName, opponent!.DisplayName);
        
        // Funciones locales para mejorar la legibilidad
        bool OpponentProvided() => !string.IsNullOrEmpty(opponentDisplayName);
        bool SomebodyIsWaiting() => this.WaitingList.Count != 0;
        bool OpponentFound() => opponent != null;
    }

    private string CreateBattle(string playerDisplayName, string opponentDisplayName)
    {
        // Remover jugadores de la lista de espera
        this.WaitingList.RemoveTrainer(playerDisplayName);
        this.WaitingList.RemoveTrainer(opponentDisplayName);
        
        // Iniciar la batalla usando la clase FacadeJuego
        FacadeJuego facadeJuego = new FacadeJuego(playerDisplayName, opponentDisplayName);
        facadeJuego.ComenzarBatalla();
        
        return $"Comienza la batalla entre {playerDisplayName} y {opponentDisplayName}";
    }
}
