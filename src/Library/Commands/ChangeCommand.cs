using System.ComponentModel.Design;
using Discord.Commands;
namespace Library;

public class ChangeCommand : ModuleBase<SocketCommandContext>
{
    [Command("change")]
    [Summary("Cambia su Pokémon actual al Pokémon elegido")]
    public async Task ExecuteAsync([Remainder] string? pokemon = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        Batalla batalla = Facade.Instance.EncontrarBatallaPorUsuario(displayName);
        Entrenador jugador;
        if (batalla.GetNombreJ1() == displayName)
        {
            jugador = batalla.Jugador1;
        }
        else
        {
            jugador = batalla.Jugador2;
        }
        if (pokemon != null)
        {
            if (Facade.Instance.PosesionPokemonVivo(jugador, pokemon) != null)
            {
                if (Facade.Instance.RevisarAccion(jugador, "Cambiar Pokémon"))
                {
                    await ReplyAsync(Facade.Instance.CambiarPokemon(jugador, pokemon));
                }
                else
                {
                    await ReplyAsync(Mensaje.AccionInvalida());
                }
            }
            else
            {
                await ReplyAsync(Mensaje.PokemonInvalido());
            }
            
        }
        else
        {
            await ReplyAsync(Mensaje.PokemonesDisponibles(jugador));
        }
    }
}