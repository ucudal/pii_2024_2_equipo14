using System.ComponentModel.Design;
using Discord.Commands;
namespace Library;
/// <summary>
/// Esta es la clase ChangeCommand. Se encarga de gestionar el cambio de Pokémon actual con los parámetros recibidos por el usuario.
/// </summary>
public class ChangeCommand : ModuleBase<SocketCommandContext>
{
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