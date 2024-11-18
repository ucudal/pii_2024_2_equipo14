using Discord.Commands;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'ayuda' del bot. Este comando muestra todos los
/// comandos disponibles.
/// </summary>
public class AyudaCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'ayuda'. Este comando muestra todos los comandos disponibles.
    /// </summary>
    [Command("ayuda")]
    [Summary("Muestra todos los comandos disponibles")]
    public async Task ExecuteAsync()
    {
        string ayuda = 
            "**Comandos disponibles:**\n" +
            "`!Join` - Agrega al usuario a la lista de espera.\n" +
            "`!Leave` - Remueve al usuario de la lista de espera.\n" +
            "`!Waiting` - Muestra la lista de jugadores esperando.\n" +
            "`!battle` - Inicia una batalla entre jugadores.\n" +
            "`!pokemon` - Busca un Pokémon por nombre.\n" +
            "`!name` - Busca el nombre de un Pokémon por identificador.\n" +
            "`!who   - retorna información sobre el usuario que envía el mensaje o sobre otro usuario si se incluye como parámetro.\n" +
            "`!atacar` - Realiza un ataque durante la batalla.\n" +
            "`!cambiar` - Cambia el Pokémon durante la batalla.\n" +
            "`!estado` - Muestra el estado de tu Pokémon.\n" +
            "`!terminar` - Termina la batalla.\n";
        
        await ReplyAsync(ayuda);
    }
}