using Discord;
using Discord.Commands;
using Discord.WebSocket;
namespace Library;
/// <summary>
/// Esta es la clase UseItemCommand. Se encarga de gestionar el uso de item con los parámetros recibidos por el usuario.
/// </summary>
public class UseItemCommand :  ModuleBase<SocketCommandContext>
{
    [Command("useitem")]
    [Summary("Utiliza el Item elegido por el jugador en el Pokémon elegido")]
    public async Task ExecuteAsync([Remainder] string? itemypokemon = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        Batalla batalla = Facade.Instance.EncontrarBatallaPorUsuario(displayName);
        Entrenador jugador;
        Entrenador jugador2;
        string result;
        if (batalla.GetNombreJ1() == displayName)
        {
            jugador = batalla.Jugador1;
            jugador2 = batalla.Jugador2;
        }
        else
        {
            jugador = batalla.Jugador2;
            jugador2 = batalla.Jugador1;
        }
        if (itemypokemon == null)
        {
            result = Facade.Instance.MostrarItems(jugador);
        }
        else
        {
            char[] delimiters = new[] {' '};
            string[] substrings = itemypokemon.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string item = substrings[0];
            string pokemon = substrings[1];
            result = Facade.Instance.UsoDeItem(jugador, item, pokemon, jugador2);
        }
        await ReplyAsync(result);
    }
}