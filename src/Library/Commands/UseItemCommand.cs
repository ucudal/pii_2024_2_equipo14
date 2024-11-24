using Discord;
using Discord.Commands;
using Discord.WebSocket;
namespace Library;

public class UseItemCommand :  ModuleBase<SocketCommandContext>
{
    [Command("useitem")]
    [Summary("Utiliza el Item elegido por el jugador en el Pokémon elegido")]
    public async Task ExecuteAsync([Remainder] string? item = null, string? pokemon = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        Batalla batalla = Facade.Instance.EncontrarBatallaPorUsuario(displayName);
        Entrenador jugador;
        string result;
        if (batalla.GetNombreJ1() == displayName)
        {
            jugador = batalla.Jugador1;
        }
        else
        {
            jugador = batalla.Jugador2;
        }
        Pokemon pokemonElegido = Facade.Instance.PosesionPokemon(jugador, pokemon);
        Item itemElegido = Facade.Instance.PosesionItem(jugador, item);
        if (item == null || pokemon == null)
        {
            result = Facade.Instance.MostrarItems(jugador);
        }
        else if (pokemonElegido == null)
        {
            result = Mensaje.PokemonInvalido();
        }
        else if (Facade.Instance.RevisarAccion(jugador, "Usar Item"))
        {
            if (Facade.Instance.RevisarItem(jugador, itemElegido, pokemonElegido))
            {
                Facade.Instance.UsoDeItem(jugador, itemElegido, pokemonElegido);
            }
        }
    }
}