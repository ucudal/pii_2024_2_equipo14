using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'atacar' del bot. Este comando permite al jugador realizar
/// un ataque durante la batalla.
/// </summary>
public class AtacarCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'atacar'. Este comando permite al jugador realizar un ataque durante la batalla.
    /// </summary>
    [Command("atacar")]
    [Summary("Permite realizar un ataque durante la batalla")]
    public async Task ExecuteAsync(string movimiento)
    {
        string playerDisplayName = CommandHelper.GetDisplayName(Context);
      //  string result = Facade.Instance.PerformAttack(playerDisplayName, movimiento);
       // await ReplyAsync(result);
    }
}