using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Library;

/// <summary>
/// Esta clase implementa el comando 'battle' del bot. Este comando une al
/// jugador que envía el mensaje con el oponente que se recibe como parámetro,
/// si lo hubiera, en una batalla; si no se recibe un oponente, lo une con
/// cualquiera que esté esperando para jugar.
/// </summary>
// ReSharper disable once UnusedType.Global
public class BattleCommand : ModuleBase<SocketCommandContext>
{
    [Command("battle")]
    [Summary("Une al jugador que envía el mensaje con el oponente que se recibe como parámetro, si lo hubiera.")]
    public async Task ExecuteAsync([Remainder] string? opponentDisplayName = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        SocketGuildUser ? opponentUser  = CommandHelper.GetUser (Context, opponentDisplayName);
        SocketGuildUser? user = CommandHelper.GetUser(Context, displayName);

        string result;
        if (opponentUser != null && Facade.Instance.JugadorEsperando(opponentDisplayName) != $"{opponentDisplayName} no está esperando")
        {// agregar llamada al metodo de acuerdo de restricciones de la clase Facade antes de que empiece la batalla
            // y en caso de que no se llegue a un acuerdo no haya batalla en este metodo tendria que estar para que el jugador pueda añadir las restricciones
            result = Facade.Instance.ComenzarBatalla(displayName, opponentUser.DisplayName);
            await ReplyAsync(result);
            string pokedex = Facade.Instance.MostrarPokedex(); 
            await ReplyAsync(pokedex);
            await opponentUser.SendMessageAsync(pokedex);
            await user.SendMessageAsync(pokedex);
        }
        else
        {
            result = $"No hay un usuario {opponentDisplayName}.";
            await ReplyAsync(result);
        }
       
    }
}