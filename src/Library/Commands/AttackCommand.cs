using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Library;
/// <summary>
/// Esta es la clase AttackCommand. Se encarga de gestionar un ataque con los parámetros recibidos por el usuario.
/// </summary>
public class AttackCommand :  ModuleBase<SocketCommandContext>
{
    [Command("attack")]
    [Summary("Realiza el ataque que el jugador indique al Pokémon actual del oponente")]
    public async Task ExecuteAsync([Remainder] string? ataque = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        Batalla batalla = Facade.Instance.EncontrarBatallaPorUsuario(displayName);
        Entrenador jugador;
        Entrenador oponente;
        if (batalla.GetNombreJ1() == displayName)
        {
            jugador = batalla.Jugador1;
            oponente = batalla.Jugador2;
        }
        else
        {
            jugador = batalla.Jugador2;
            oponente = batalla.Jugador1;
        }
        string result = "";
        Pokemon pokemon = jugador.PokemonActual;
        Pokemon pokemon2 = oponente.PokemonActual;
        if (ataque == null)
        {
            if (jugador.Turnos % 2 == 0 || pokemon2.Envenenado || pokemon2.Dormido || pokemon2.Paralizado || pokemon2.Quemado)
            {
                    result = Facade.Instance.MostrarAtaques(jugador.PokemonActual,false);
            }
            else
            {
                result = Facade.Instance.MostrarAtaques(jugador.PokemonActual, true);   
            }
        }
        else
        {
            result = Facade.Instance.Atacar(jugador, ataque, oponente);
        }
        
        await ReplyAsync(result);
    }
}