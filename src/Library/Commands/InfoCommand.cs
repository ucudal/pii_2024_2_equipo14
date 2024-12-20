using System.Text;
using Discord.Commands;
namespace Library;
/// <summary>
/// Esta es la clase InfoCommand. Devuelve al usuario los comandos disponibles.
/// </summary>
public class InfoCommand: ModuleBase<SocketCommandContext>
{
    [Command("info")]
    [Summary("Muestra todos los comandos disponibles")]
    public async Task ExecuteAsync()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine("\n");
        result.AppendLine("COMANDOS DISPONIBLES:");
        result.AppendLine(" \t - !join : Une el usuario a la lista de espera");
        result.AppendLine(" \t - !leave : Quita al usuario de la lista de espera");
        result.AppendLine(" \t - !waiting : Muestra los usuarios en la lista de espera");
        result.AppendLine(" \t - !userinfo : Muestra la información del usuario");
        result.AppendLine(" \t - !userinfo + usuario : Muestra la información del usuario ingresado");
        result.AppendLine(" \t - !battle + usuario : Comienza una batalla con el usuario ingresado");
        result.AppendLine(" \t - !addpokemon + pokémon : Agrega el Pokémon ingresado al catálogo del usuario");
        result.AppendLine(" \t - !attack : Muestra los ataques disponibles del usuario");
        result.AppendLine(" \t - !attack + ataque : Realiza el ataque ingresado al Pokémon actual del enemigo");
        result.AppendLine(" \t - !change : Muestra los Pokémones disponibles para cambiar");
        result.AppendLine(" \t - !change + pokémon : Cambia el Pokémon actual al pokémon ingresado");
        result.AppendLine(" \t - !useitem : Muestra los items disponibles para usar");
        result.AppendLine(" \t - !useitem + item + pokémon : Usa el item ingresado en el Pokémon ingresado");
        await ReplyAsync(result.ToString());
    }
}