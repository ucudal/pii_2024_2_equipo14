using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class AgregarPokemonCommand : ModuleBase<SocketCommandContext>
    {
        private readonly FacadeJuego _facade;

        public AgregarPokemonCommand(FacadeJuego facade)
        {
            _facade = facade;
        }

        [Command("agregarPokemon")]
        [Summary("Permite al jugador agregar Pokémon a su equipo.")]
        public async Task ExecuteAsync()
        {
            string playerDisplayName = CommandHelper.GetDisplayName(Context);
            Entrenador entrenador = _facade.ObtenerEntrenador(playerDisplayName);

            // Inicializar Pokémon para el entrenador
            string resultado = _facade.InicializarPokemon(entrenador);
            await ReplyAsync(resultado);
        }
    }
}