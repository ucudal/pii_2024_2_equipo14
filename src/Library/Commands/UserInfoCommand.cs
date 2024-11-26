using Discord.Commands;
using Discord.WebSocket;

namespace Library;

/// <summary>
/// Esta clase implementa el comando 'userinfo', alias 'who' o 'whois' del bot.
/// Este comando retorna información sobre el usuario que envía el mensaje o sobre
/// otro usuario si se incluye como parámetro..
/// </summary>
// ReSharper disable once UnusedType.Global
public class UserInfoCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'userinfo', alias 'who' o 'whois' del bot.
    /// </summary>
    /// <param name="displayName">El nombre de usuario de Discord a buscar.</param>
    [Command("who")]
    [Summary(
        """
        Devuelve información sobre el usuario que se indica como parámetro o
        sobre el usuario que envía el mensaje si no se indica otro usuario.
        """)]
    public async Task ExecuteAsync(
        [Remainder][Summary("El usuario del que tener información, opcional")]
        string? displayName = null)
    {
        string userName = CommandHelper.GetDisplayName(Context);
        if (displayName != null)
        {
            SocketGuildUser? user = CommandHelper.GetUser(Context, displayName);

            if (user == null)
            {
                await ReplyAsync($"No puedo encontrar {displayName} en este servidor");
            }

            Batalla batalla = Facade.Instance.EncontrarBatallaPorUsuario(displayName);
            if (batalla != null)
            {
                Entrenador j1 = batalla.Jugador1;
                Entrenador j2 = batalla.Jugador2;
                if (j1.Nombre == displayName)
                {
                    await ReplyAsync(Mensaje.InformacionGeneral(j1));
                }
                else
                {
                    await ReplyAsync(Mensaje.InformacionGeneral(j2));
                }
            }
            else 
            {
                await ReplyAsync(Facade.Instance.JugadorEsperando(displayName));
            }
        }
        else
        {
            Batalla batalla = Facade.Instance.EncontrarBatallaPorUsuario(userName);
            if (batalla != null)
            {
                Entrenador j1 = batalla.Jugador1;
                Entrenador j2 = batalla.Jugador2;
                if (j1.Nombre == userName)
                {
                    await ReplyAsync(Mensaje.InformacionGeneral(j1));
                }
                else
                {
                    await ReplyAsync(Mensaje.InformacionGeneral(j2));
                }
            }
            else
            {
                await ReplyAsync(Facade.Instance.JugadorEsperando(userName));
            }
        }
    }
}
