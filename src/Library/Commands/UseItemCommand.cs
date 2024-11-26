using Discord;
using Discord.Commands;
using Discord.WebSocket;
namespace Library;

public class UseItemCommand :  ModuleBase<SocketCommandContext>
{
    [Command("useitem")]
    [Summary("Utiliza el Item elegido por el jugador en el Pokémon elegido")]
    public async Task ExecuteAsync([Remainder] string? itemypokemon = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        Batalla batalla = Facade.Instance.EncontrarBatallaPorUsuario(displayName);
        Entrenador jugador;
        Entrenador jugador2;
        string result;
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
        if (itemypokemon == null)
        {
            result = Facade.Instance.MostrarItems(jugador);
        }
        else if (jugador.MiTurno == false)
        {
            result = Mensaje.AccionInvalida();
        }
        else
        {
            char[] delimiters = new[] {' '};
            string[] substrings = itemypokemon.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string item = substrings[0];
            string pokemon = substrings[1];
            Pokemon pokemonElegido = Facade.Instance.PosesionPokemon(jugador, pokemon);
            Item itemElegido = Facade.Instance.PosesionItem(jugador, item);
            if (pokemonElegido == null)
            {
                result = Mensaje.PokemonInvalido();
            }
            else if (Facade.Instance.RevisarAccion(jugador, "Usar Item"))
            {
                if (Facade.Instance.RevisarItem(jugador, itemElegido, pokemonElegido))
                {
                    result = Facade.Instance.UsoDeItem(jugador, itemElegido, pokemonElegido,jugador2);
                }
                else
                {
                    result = "No se pudo usar ese item con ese Pokémon";
                }
            }
            else
            {
                result = Mensaje.AccionInvalida();
            
            }
        }
        await ReplyAsync(result);
    }
}