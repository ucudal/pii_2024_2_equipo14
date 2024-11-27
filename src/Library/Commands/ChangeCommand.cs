using System.ComponentModel.Design;
using Discord.Commands;
namespace Library;
/// <summary>
/// Esta es la clase ChangeCommand. Es el comando del bot para cambiar el pokemon actual por otro pokemon elegido de su catálogo.
/// </summary>
public class ChangeCommand : ModuleBase<SocketCommandContext>
{
    
    /// <summary>
    /// Verifica si se puede realizar el cambio de pokemon corectamente.
    /// </summary>
    /// <param name="opponentDisplayName">El nombre del jugador oponente</param>
    /// <returns>nuevo pokemon actual.</returns>
    [Command("change")]
    [Summary("Cambia su Pokémon actual al Pokémon elegido")]
    public async Task ExecuteAsync([Remainder] string? pokemon = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        Batalla batalla = Facade.Instance.EncontrarBatallaPorUsuario(displayName);
        Entrenador jugador;
        Entrenador jugador2;
        if (batalla.GetNombreJ1() == displayName)
        {
            jugador = batalla.Jugador1;
            jugador2 = batalla.Jugador2;
        }
        else
        {
            jugador = batalla.Jugador2;
            jugador2 = batalla.Jugador1;
        }
        if (pokemon != null)
        {
            Facade.Instance.CambiarPokemon(jugador, pokemon, jugador2);
        }
        else
        {
            await ReplyAsync(Mensaje.PokemonesDisponibles(jugador));
        }
    }
}