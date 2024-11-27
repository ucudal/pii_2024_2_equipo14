using Discord.Commands;
using Discord.WebSocket;

namespace Library;
/// <summary>
/// Esta es la clase CommandHelper. Es el comando del bot que ayuda a saber cuando un  comandos es inválido.
/// </summary>
public static class CommandHelper
{
    /// <summary>
    /// Verifica si el comando es correcto o no.
    /// </summary>
    /// <returns>nombre</returns>
    public static string GetDisplayName(
        SocketCommandContext context, 
        string? name = null)
    {
        if (name == null)
        {
            name = context.Message.Author.Username;
        }
        
        foreach (SocketGuildUser user in context.Guild.Users)
        {
            if (user.Username == name
                || user.DisplayName == name
                || user.Nickname == name
                || user.GlobalName == name)
            {
                return user.DisplayName;
            }
        }

        return name;
    }

    /// <summary>
    /// Verifica si el comando es correcto o no.
    /// </summary>
    /// <returns></returns>
    public static SocketGuildUser? GetUser(
        SocketCommandContext context,
        string? name)
    {
        if (name == null)
        {
            return null;
        }
        
        foreach (SocketGuildUser user in context.Guild.Users)
        {
            if (user.Username == name
                || user.DisplayName == name
                || user.Nickname == name
                || user.GlobalName == name)
            {
                return user;
            }
        }

        return null;
    }
}
