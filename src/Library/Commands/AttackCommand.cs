using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Library;
/// <summary>
/// Esta es la clase AttackCommand. Es el comando del bot para atacar al pokemon del oponente.
/// </summary>
public class AttackCommand :  ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Verifica si es posible atacar al pokemon, muestra los ataques disponibles y valida si está la batalla activa.
    /// </summary>
    /// <param name="ataque">El ataque elegido</param>
    /// <returns> Ataque</returns>
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
            if (Facade.Instance.RevisarAtaque(jugador, pokemon, pokemon.AtaqueEspecial.Nombre, pokemon2))
            {
                result = Facade.Instance.MostrarAtaques(jugador.PokemonActual,true);
            }
            else
            {
                result = Facade.Instance.MostrarAtaques(jugador.PokemonActual, false);
            }
        }
        else
        {
            result = Facade.Instance.Atacar(jugador, ataque, oponente);
        }
        
        await ReplyAsync(result);
    }
}