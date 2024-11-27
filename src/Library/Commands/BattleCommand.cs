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
    /// <summary>
    /// Verifica si es posible crear la batalla y une al jugador con el oponente para crear esta misma.
    /// </summary>
    /// <param name="opponentDisplayName">El nombre del jugador oponente</param>
    /// <returns>batalla creada.</returns>
    [Command("battle")]
    [Summary("Une al jugador que envía el mensaje con el oponente que se recibe como parámetro, si lo hubiera.")]
    public async Task ExecuteAsync([Remainder] string? opponentDisplayName = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        SocketGuildUser ? opponentUser  = CommandHelper.GetUser (Context, opponentDisplayName);
        SocketGuildUser? user = CommandHelper.GetUser(Context, displayName);

        string result;
        if (opponentUser != null && Facade.Instance.JugadorEsperando(opponentDisplayName) != $"{opponentDisplayName} no está esperando")
        {
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