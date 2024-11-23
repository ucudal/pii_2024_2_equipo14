using Discord.Commands;
using Library;

namespace Library;

public class AddPokemon : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'atacar'. Este comando permite al jugador realizar un ataque durante la batalla.
    /// </summary>
    [Command("addPokemon")]
    [Summary("Permite agregar Pokemon")]
    public async Task ExecuteAsync(string movimiento)
    {
        string playerDisplayName = CommandHelper.GetDisplayName(Context);
        Entrenador j = new Entrenador(playerDisplayName); // borrar
        await ReplyAsync($"El {playerDisplayName} cambia de pokemon a {j.PokemonActual}!");
    }
}