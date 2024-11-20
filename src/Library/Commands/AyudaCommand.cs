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
            "`!acciones - Permite elegir una acción durante la batalla.\n" +
            " !agregarPokemon - Permite al jugador agregar Pokémon a su equipo.\n" +
            "`!who   - retorna información sobre el usuario que envía el mensaje o sobre otro usuario si se incluye como parámetro.\n";

        
        await ReplyAsync(ayuda);
    }
}