using Discord.Commands;


namespace Library;

/// <summary>
/// Esta clase implementa el comando 'estado' del bot. Este comando muestra el estado
/// del Pokémon durante la batalla.
/// </summary>
public class EstadoCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'estado'. Este comando muestra el estado del Pokémon durante la batalla.
    /// </summary>
    [Command("estado")]
    [Summary("Muestra el estado de tu Pokémon en la batalla")]
    public async Task ExecuteAsync()
    {
        string playerDisplayName = CommandHelper.GetDisplayName(Context);
      await ReplyAsync($"{playerDisplayName}, aquí está el estado de tu Pokémon.");

    }
}