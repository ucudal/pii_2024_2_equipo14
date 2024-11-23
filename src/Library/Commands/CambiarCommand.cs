using Discord.Commands;

namespace Library;

/// <summary>
/// Esta clase implementa el comando 'cambiar' del bot. Este comando permite cambiar el Pokémon
/// durante la batalla.
/// </summary>
public class CambiarCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'cambiar'. Este comando permite cambiar el Pokémon durante la batalla.
    /// </summary>
    [Command("cambiar")]
    [Summary("Permite cambiar el Pokémon durante la batalla")]
    public async Task ExecuteAsync(string nuevoPokemon)
    {
        string playerDisplayName = CommandHelper.GetDisplayName(Context);
       // string result = Facade.Instance.ChangePokemon(playerDisplayName, nuevoPokemon);
     //   await ReplyAsync(result);
     await ReplyAsync($"{playerDisplayName} ha cambiado su Pokémon.");
    }
}