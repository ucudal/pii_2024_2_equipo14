using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using Library;
using Library.Otros;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class AgregarPokemonCommand : ModuleBase<SocketCommandContext>
    {
        private readonly FacadeJuego _facadeJuego;

        public AgregarPokemonCommand(FacadeJuego facade)
        {
            _facadeJuego = facade;
        }

        [Command("AgregarPokemon")]
        [Summary("Permite al jugador agregar Pokémon a su equipo.")]
        public async Task ExecuteAsync()
        {
            string playerDisplayName = CommandHelper.GetDisplayName(Context);
            Entrenador entrenador = _facadeJuego.ObtenerEntrenador(playerDisplayName);

            // Inicializar Pokémon para el entrenador
            string resultado = _facadeJuego.InicializarPokemon(entrenador);
            await ReplyAsync(resultado);
        }
    }
}