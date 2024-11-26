
using Ucu.Poo.DiscordBot.Services;

namespace Library;

/// <summary>
/// Un programa que implementa un bot de Discord.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Punto de entrada al programa.
    /// </summary>
    private static void Main()
    {
        //DemoFacade();
         DemoBot();
    }
    private static void DemoFacade()
    {
        Console.WriteLine(Facade.Instance.AgregarJugadorListaDeEspera("player"));
        Console.WriteLine(Facade.Instance.AgregarJugadorListaDeEspera("opponent"));
        Console.WriteLine(Facade.Instance.GetJugadoresEsperando());
        Console.WriteLine(Facade.Instance.ComenzarBatalla("player", "opponent"));
        Console.WriteLine(Facade.Instance.GetJugadoresEsperando());
    }

    private static void DemoBot()
    {
        BotLoader.LoadAsync().GetAwaiter().GetResult();
    }
} 
 