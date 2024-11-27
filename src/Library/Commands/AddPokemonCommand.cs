using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Library;
/// <summary>
/// Esta es la clase AddPokemonCommand. Es el comando del bot para agregar el pokemon elegido al catalogo del entrenador.
/// </summary>
public class AddPokemonCommand : ModuleBase<SocketCommandContext>
{
   
    /// <summary>
    /// Verifica si es posible agregar al pokemon elegido para la batalla
    /// </summary>
    /// <param name="pokemonElegido">El nombre del pokemon elegido en el comando de Discord</param>
    /// <returns><c>AgregarPokemon</c> si se agrega correctamente <c>No fue posible agregar el Pokémon</c>
    /// en caso contrario.</returns>
    
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