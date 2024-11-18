using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands;

public class AgregarPokemon : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'atacar'. Este comando permite al jugador realizar un ataque durante la batalla.
    /// </summary>
    [Command("AgregarPokemon")]
    [Summary("Permite agregar Pokemon")]
    public async Task ExecuteAsync(string movimiento)
    {
        string playerDisplayName = CommandHelper.GetDisplayName(Context);
        //  string result = Facade.Instance.PokemonChange(playerDisplayName, movimiento);
        // await ReplyAsync(result);
        await ReplyAsync($"El {playerDisplayName} cambia de pokemon a {Entrenador.PokemonActual}!");
    }
}