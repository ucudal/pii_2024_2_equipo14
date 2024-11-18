using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'terminar' del bot. Este comando termina la batalla
/// y muestra el resultado final.
/// </summary>
public class TerminarCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'terminar'. Este comando termina la batalla y muestra el resultado.
    /// </summary>
    [Command("Rendirse")]
    [Summary("El jugador se rinde")]
    public async Task ExecuteAsync()
    {
     //   string result = Facade.Instance.EndBattle();
     // await ReplyAsync(result);
    }
}