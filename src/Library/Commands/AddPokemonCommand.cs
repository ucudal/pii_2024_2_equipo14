using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Library;
/// <summary>
/// Esta es la clase AddPokemonCommand. Se encarga de gestionar el agrego de Pokémon con los parámetros recibidos por el usuario.
/// </summary>
public class AddPokemonCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'atacar'. Este comando permite al jugador realizar un ataque durante la batalla.
    /// </summary>
    [Command("addpokemon")]
    [Summary("Agrega el Pokémon elegido al catálogo del jugador")]
    public async Task ExecuteAsync([Remainder] string? pokemonElegido = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        Batalla batalla = Facade.Instance.EncontrarBatallaPorUsuario(displayName);
        Entrenador jugador1 = batalla.Jugador1;
        Entrenador jugador2 = batalla.Jugador2;
        SocketGuildUser? user = CommandHelper.GetUser(Context, displayName);
        string result;
        string catalogo = "";
        if (pokemonElegido != null && batalla != null && !batalla.EnBatalla)
        {
            if (batalla.GetNombreJ1() == displayName)
            {
                result = Facade.Instance.AgregarPokemon(jugador1, pokemonElegido);
            }
            else
            {
                result = Facade.Instance.AgregarPokemon(jugador2, pokemonElegido);
            }
        }
        else
        {
            result = "No fue posible agregar el Pokémon";
        }
        await ReplyAsync(result);
        if (jugador1.GetMiCatalogo().Count == 6 && jugador2.GetMiCatalogo().Count == 6)
        {
            await ReplyAsync(Facade.Instance.InicializarEncuentros(batalla));
        }
        
    }
}