using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta es la clase Facade. Se encarga de crear instancias de Facade y gestionar sus responsabilidades.
    /// </summary>
    public class FacadeJuego
    {
        /*
        User Stories:
        1. Como jugador, quiero seleccionar 6 Pokémon de un catálogo para que participen en la batalla.
        2. Como jugador, quiero que mi Pokémon ataque al Pokémon del oponente.
        3. Como jugador, quiero que mi Pokémon use un ataque especial que pueda causar efectos como dormir, paralizar, envenenar o quemar.
        4. Como jugador, quiero que los Pokémon tengan un nombre y un tipo.
        5. Como jugador, quiero que los ataques tengan un nombre, un tipo y un daño específico.
        6. Como jugador, quiero que los Pokémon puedan ser afectados por ataques especiales y que estos efectos se mantengan hasta el final de la batalla, a menos que se use un ítem de cura total.
        7. Como jugador, quiero que los Pokémon puedan perder HP debido a ataques y efectos de estado.
        8. Como jugador, quiero que los ítems puedan ser utilizados durante la batalla, pero que al usarlos, pierda mi turno.
        9. Como jugador, quiero que los ítems disponibles sean: 4 Súper pociones, 1 Revivir y 2 Cura total.
        10. Como jugador, quiero que el juego se desarrolle en turnos alternos entre los dos jugadores.
        11. Como jugador, quiero que el juego termine cuando uno de los jugadores no tenga Pokémon vivos.
        */

        /// <summary>
        /// Atributo tipo Entrenador que indica el Jugador 1.
        /// </summary>

        private Entrenador jugador1;

        /// <summary>
        /// Atributo tipo Entrenador que indica el Jugador 1.
        /// </summary>
        private Entrenador jugador2;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FacadeJuego"/>.
        /// </summary>
        /// <param name="nombreJugador1">El nombre del Jugador 1.</param>
        /// <param name="nombreJugador2">El nombre del Jugador 2.</param>
        public FacadeJuego(string nombreJugador1, string nombreJugador2)
        {
            jugador1 = new Entrenador(nombreJugador1);
            jugador2 = new Entrenador(nombreJugador2);
        }

        /// <summary>
        /// Se encarga de crear una instancia de batalla y darle comienzo.
        /// </summary>
        public void ComenzarBatalla()
        {
            InicializarPokemon(jugador1);
            InicializarPokemon(jugador2);
            Batalla batalla = new Batalla(jugador1, jugador2, this);
            batalla.Comenzar();
        }

        /// <summary>
        /// Se encarga de mostrar los Pokémons disponibles para elegir.
        /// </summary>
        /// <param name="jugador">El entrenador que elige los Pokémons.</param>
        public string InicializarPokemon(Entrenador jugador)
        {
            string mensaje = $"Selecciona 6 Pokémon para {jugador.Nombre}:";
            List<Pokemon> pokemonsDisponibles = Pokedex.listaPokemons;

            for (int i = 0; i < pokemonsDisponibles.Count; i++)
            {
                mensaje += $"{i + 1} - {pokemonsDisponibles[i].Nombre}";
            }

            HashSet<string> seleccionados = new HashSet<string>();

            for (int i = 0; i < 6; i++)
            {
                mensaje += $"Selecciona el Pokémon {i + 1} (1-{pokemonsDisponibles.Count}):";
                int seleccion = int.Parse(Console.ReadLine()) - 1; //CAMBIAR A BOT 

                if (seleccion >= 0 && seleccion < pokemonsDisponibles.Count)
                {
                    string nombrePokemon = pokemonsDisponibles[seleccion].Nombre;

                    if (!seleccionados.Contains(nombrePokemon))
                    {
                        jugador.AgregarPokemon(Pokedex.BuscarPokemon(nombrePokemon));
                        seleccionados.Add(nombrePokemon);
                    }
                    else
                    {
                        mensaje += "Ya has seleccionado este Pokémon. Intenta de nuevo.";
                        i--;
                    }
                }
                else
                {
                    mensaje += "Selección no válida. Intenta de nuevo.";
                    i--;
                }

            }

            return mensaje;
        }

        /// <summary>
        /// Se encarga de dar inicio a la acción que elige el entrenador
        /// </summary>
        /// <param name="jugador">El entrenador que realiza la acción.</param>
        /// <param name="oponente">El entrenador que no está en su turno.</param>

        public string ElegirAccion()
        {
            string mensaje = "\n==================================";
            mensaje += "LISTA DE ACCIONES (Seleccione según el número):";
            mensaje += "\t0 - Atacar";
            mensaje += "\t1 - Cambiar Pokémon";
            mensaje += "\t2 - Usar ítem";
            mensaje += "==================================";
            return mensaje;
        }

        /// <summary>
        /// Se encarga de mostrar los Pokémons disponibles para cambiar.
        /// </summary>
        /// <param name="usuario">El entrenador que debe elegir.</param>
        public static string ElegirPokemon(Entrenador usuario)
        {
            string mensaje = "\n==================================";
            mensaje += "LISTA DE POKEMONES DISPONIBLES (Seleccione según el número):";
            for (int i = 0; i < usuario.miCatalogo.Count; i++)
            {
                Pokemon pokemon = usuario.miCatalogo[i];
                mensaje += $"\t{i} - \"{pokemon.Nombre}\" de Tipo: {pokemon.Tipo}";
            }

            mensaje += "==================================";
            return mensaje;

        }

        /// <summary>
        /// Se encarga de mostrar los ataques (todos) del Pokémon.
        /// </summary>
        /// <param name="pokemon">El Pokémon cuyas acciones se muestran.</param>
        public static string ElegirAtaque(Pokemon pokemon)
        {
            string mensaje = $"\n==================================";
            mensaje += $"LISTA DE ATAQUES DISPONIBLES DE {pokemon.Nombre} (Seleccione según el número):";
            for (int i = 0; i < pokemon.GetAtaques().Count; i++)
            {
                Ataque ataque = pokemon.GetAtaques()[i];
                mensaje +=
                    $"\t{i} - \"{ataque.Nombre}\" / Tipo: {pokemon.Tipo} / Daño: {ataque.Dano} / Precisión: {ataque.Precision}";
                if (ataque is AtaqueEspecial ataqueEspecial)
                {
                    mensaje += $" / (Especial) Efecto: {ataqueEspecial.Efecto}";
                }
            }

            mensaje += "==================================";
            return mensaje;
        }

        /// <summary>
        /// Se encarga de mostrar los ataques simples del Pokémon.
        /// </summary>
        /// <param name="pokemon">El Pokémon cuyas acciones se muestran.</param>
        public static string ElegirAtaqueSimple(Pokemon pokemon)
        {
            string mensaje = $"\n==================================";
            mensaje += $"LISTA DE ATAQUES SIMPLES DISPONIBLES DE {pokemon.Nombre} (Seleccione según el número):";

            for (int i = 0; i < pokemon.GetAtaques().Count; i++)
            {
                Ataque ataque = pokemon.GetAtaques()[i];
                if (ataque is not AtaqueEspecial)
                {
                    mensaje +=
                        $"\t{i} - \"{ataque.Nombre}\" / Tipo: {pokemon.Tipo} / Daño: {ataque.Dano} / Precisión: {ataque.Precision}";
                }
            }

            mensaje += "==================================";
            return mensaje;
        }

        /// <summary>
        /// Se encarga de mostrar los items disponibles para elegir para usar.
        /// </summary>
        /// <param name="usuario">El entrenador que debe elegir.</param>
        public static string ElegirItem(Entrenador usuario)
        {
            string mensaje = $"\n==================================";
            mensaje += $"LISTA DE ÍTEMS DISPONIBLES DE {usuario.Nombre} (Seleccione según el número):";
            for (int i = 0; i < usuario.misItems.Count; i++)
            {
                Item item = usuario.misItems[i];
                mensaje += $"\t{i} - \"{item.Nombre}\" ({item.Descripcion})";
            }

            mensaje += "==================================";
            return mensaje;
        }

        /// <summary>
        /// Se encarga de mostrar los datos del jugador (estado de sus Pokémons).
        /// </summary>
        /// <param name="usuario">El entrenador cuyos datos se muestran.</param>
        public string ImprimirDatos(Entrenador usuario) //ponerle string
        {
            string mensaje = $"\n==================================";
            mensaje += $"DATOS DE POKEMONES DE JUGADOR {usuario.Nombre}:";
            foreach (Pokemon pokemon in usuario.miCatalogo)
            {
                mensaje += $"\t\"{pokemon.Nombre}\" / Vida: {pokemon.VidaTotal}";
                if (pokemon.Dormido) mensaje += " / Efecto: dormido";
                if (pokemon.Paralizado) mensaje += " / Efecto: paralizado";
                if (pokemon.Envenenado) mensaje += " / Efecto: envenenado";
                if (pokemon.Quemado) mensaje += " / Efecto: quemado";
                if (pokemon == usuario.PokemonActual) mensaje += " (Pokémon actual)";
            }

            mensaje += "==================================";
            return mensaje;
        }

        /// <summary>
        /// Se encarga de mostrar los Pokémons muertos del jugador.
        /// </summary>
        /// <param name="usuario">El entrenador cuyos Pokémons muertos se muestran.</param>
        public static string ElegirPokemonMuerto(Entrenador usuario)
        {
            string mensaje = "\n==================================";
            mensaje += "LISTA DE POKEMONES MUERTOS DISPONIBLES (Seleccione según el número):";
            for (int i = 0; i < usuario.misMuertos.Count; i++)
            {
                Pokemon pokemon = usuario.misMuertos[i];
                mensaje += $"\t{i} - \"{pokemon.Nombre}\" de Tipo: {pokemon.Tipo}";
            }

            mensaje += "==================================";
            return mensaje;
        }

        /// <summary>
        /// Se encarga de mostrar los Pokémons heridos del jugador.
        /// </summary>
        /// <param name="usuario">El entrenador cuyos Pokémons heridos se muestran.</param>
        public static string ElegirPokemonHerido(Entrenador usuario, int itemElegido)
        {
            string mensaje = "\n==================================";
            mensaje += "LISTA DE POKEMONES HERIDOS DISPONIBLES (Seleccione según el número):";
            for (int i = 0; i < usuario.miCatalogo.Count; i++)
            {
                Pokemon pokemon = usuario.miCatalogo[i];
                if (pokemon.VidaTotal < pokemon.VidaInicial)
                {
                    mensaje += $"\t{i} - \"{pokemon.Nombre}\" de Tipo: {pokemon.Tipo}";
                }
            }

            mensaje += "==================================";
            return mensaje;
        }


        public string UsarItemInvalido()
        {
            return "No puedes usar un ítem. Elige otra acción.";
        }

        public static string PokemonInvalido()
        {
            return
                "No se puede agregar el Pokémon. Verifica que no esté ya en el catálogo o que no hayas alcanzado el límite.";
        }

        public string PokemonMuerto(Pokemon pokemon)
        {
            return $"\nTu pokemon {pokemon.Nombre} ha muerto. Puede cambiarlo o usar un item";
        }

        public string AtacarInvalido()
        {
            return "Elija una opción válida";
        }

        public static string ItemInvalido()
        {
            return "\nDebes elegir otra opción.";
        }
        public string AgregarPokemon(Entrenador jugador, string nombrePokemon)
        {
            Pokemon pokemon = Pokedex.BuscarPokemon(nombrePokemon);
            if (pokemon == null)
            {
                return $"Pokémon {nombrePokemon} no encontrado.";
            }

            if (jugador.miCatalogo.Count < 6 && !jugador.miCatalogo.Contains(pokemon))
            {
                jugador.AgregarPokemon(pokemon);
                return $"{nombrePokemon} ha sido agregado a tu catálogo.";
            }
            else
            {
                return "No puedes agregar más Pokémon o ya tienes este Pokémon en tu catálogo.";
            }
        }
        public Entrenador ObtenerEntrenador(string displayName)
        {
            // Implementación para obtener el entrenador basado en el nombre de visualización
            return jugador1.Nombre == displayName ? jugador1 : jugador2;
        }

        public Entrenador ObtenerOponente(Entrenador entrenador)
        {
            return entrenador == jugador1 ? jugador2 : jugador1;
        }
        public string TerminarBatalla()
        {
            // Aquí puedes implementar la lógica para terminar la batalla
            // Por ejemplo, verificar si uno de los jugadores no tiene Pokémon vivos
            if (jugador1.miCatalogo.Count == 0 || jugador2.miCatalogo.Count == 0)
            {
                return "La batalla ha terminado. Uno de los jugadores no tiene Pokémon vivos.";
            }
            return "La batalla continúa.";
        }
}
}