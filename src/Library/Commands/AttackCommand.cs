using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Library;
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
        string result;
        if (ataque == null)
        {
            result = Facade.Instance.MostrarAtaques(jugador.PokemonActual);
        }
        else
        {
            Ataque ataqueElegido = Facade.Instance.PosesionAtaque(jugador.PokemonActual, ataque);
            if (ataqueElegido == null)
            {
                result = Mensaje.AtaqueInvalido();
            }
            else
            {
                if (Facade.Instance.RevisarAccion(jugador, "Atacar") == false || jugador.MiTurno == false)
                {
                    result = Mensaje.AccionInvalida();
                }
                else
                {
                    if (Facade.Instance.RevisarAtaque(jugador,jugador.PokemonActual, ataque, oponente.PokemonActual))
                    {
                        result = Facade.Instance.Atacar(jugador, ataqueElegido, oponente);
                    }
                    else
                    {
                        result = Mensaje.AtaqueInvalido();
                    }
                }
            } 
        }
        await ReplyAsync(result);
    }
}