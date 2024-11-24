using Discord;
using Discord.Commands;
using Discord.WebSocket;

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
                if (jugador1.miCatalogo.Count == 6)
                {
                    catalogo = Facade.Instance.MostrarInformacion(jugador1);
                }
            }
            else
            {
                result = Facade.Instance.AgregarPokemon(jugador2, pokemonElegido);
                if (jugador2.miCatalogo.Count == 6)
                {
                    catalogo = Facade.Instance.MostrarInformacion(jugador2);
                }
            }
        }
        else
        {
            result = "No fue posible agregar el Pokémon";
        }
        await ReplyAsync(result);
        await user.SendMessageAsync(catalogo);
        if (jugador1.miCatalogo.Count == 6 && jugador2.miCatalogo.Count == 6)
        {
            await ReplyAsync(Facade.Instance.InicializarEncuentros(batalla));
        }
        
    }
}