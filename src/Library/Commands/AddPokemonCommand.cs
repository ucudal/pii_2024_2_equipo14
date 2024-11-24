using Discord.Commands;
using Library;

namespace Library;

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
        string result;
        if (pokemonElegido != null && batalla != null && !batalla.EnBatalla)
        {
            if (batalla.GetNombreJ1() == displayName)
            {
                result = Facade.Instance.AgregarPokemon(batalla.Jugador1, pokemonElegido);
            }
            else
            {
                result = Facade.Instance.AgregarPokemon(batalla.Jugador2, pokemonElegido);
            }
        }
        else
        {
            result = "No fue posible agregar el Pokémon";
        }
        await ReplyAsync(result);
    }
}