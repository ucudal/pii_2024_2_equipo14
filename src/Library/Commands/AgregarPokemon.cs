using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    /// <summary>
    /// Esta clase implementa el comando 'acciones' del bot. Este comando permite al jugador elegir
    /// una acción durante la batalla.
    /// </summary>
    public class AccionesCommand : ModuleBase<SocketCommandContext>
    {
        private readonly FacadeJuego _facade;
        private readonly DiscordSocketClient _client; // Necesitarás tener una referencia a tu cliente de Discord

        public AccionesCommand(FacadeJuego facade, DiscordSocketClient client)
        {
            _facade = facade; // Inyectar la instancia de FacadeJuego
            _client = client; // Inyectar la instancia de DiscordSocketClient
        }

        /// <summary>
        /// Implementa el comando 'acciones'. Este comando permite al jugador elegir una acción durante la batalla.
        /// </summary>
        [Command("acciones")]
        [Summary("Permite elegir una acción durante la batalla")]
        public async Task ExecuteAsync()
        {
            string playerDisplayName = CommandHelper.GetDisplayName(Context);
            Entrenador entrenador = _facade.ObtenerEntrenador(playerDisplayName);
            Entrenador entrenadorAtacado = _facade.ObtenerOponente(entrenador);

            // Mostrar las acciones disponibles
            string acciones = _facade.ElegirAccion();
            await ReplyAsync(acciones);

            // Esperar la selección del jugador
            string seleccionAccion = await GetUserInputAsync();

            // Aquí llamamos a la lógica de Turno
            string resultadoAccion =
                Turno.HacerAccion(entrenador, seleccionAccion, entrenadorAtacado, 0, 0, 0, _facade);
            await ReplyAsync(resultadoAccion);
        }

        private async Task<string> GetUserInputAsync()
        {
            var message = await NextMessageAsync(Context.User); // Esperar la respuesta del usuario en el mismo canal

            if (message != null && message.Channel.Id == Context.Channel.Id)
            {
                return message.Content; // Devolver el contenido del mensaje
            }

            return string.Empty; // Si no hay respuesta, devolver una cadena vacía
        }

        private async Task<IUserMessage> NextMessageAsync(IUser user)
        {
            var tcs = new TaskCompletionSource<IUserMessage>();

            // Suscribirse al evento de mensaje recibido
            Func<SocketMessage, Task> handler = null;
            handler = async (message) =>
            {
                if (message is IUserMessage userMessage && message.Author.Id == user.Id &&
                    message.Channel.Id == Context.Channel.Id)
                {
                    tcs.SetResult(userMessage);
                    // Desuscribirse del evento
                    _client.MessageReceived -= handler;
                }
            };

            _client.MessageReceived += handler;

            // Esperar hasta que se complete la tarea
            return await tcs.Task;
        }
    }
}