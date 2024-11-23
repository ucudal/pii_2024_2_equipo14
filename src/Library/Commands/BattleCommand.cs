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

        string result;
        if (opponentUser  != null)
        {
            result = Facade.Instance.ComenzarBatalla(displayName, opponentUser.DisplayName);
            await Context.Message.Author.SendMessageAsync(result);
            await opponentUser .SendMessageAsync(result);
            
        }
        else
        {
            result = $"No hay un usuario {opponentDisplayName}.";
        }

        await ReplyAsync(result);
    }
}