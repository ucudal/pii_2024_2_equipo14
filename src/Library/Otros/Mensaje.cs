using System.Text;

namespace Library;
/// <summary>
/// Esta es la clase estática Mensaje. Define los mensajes a retornar según la acción que se ejecute en el código.
/// </summary>
public static class Mensaje
{
    /// <summary>
    /// Determina si el pokemon ingresado está en la lista de Pokedex, muestra el nombre y el tipo de cada pokemon elegido.
    /// </summary>
    /// /// <returns>Lista de pokemones elegidos</returns>
    public static string PokedexDisponibles()
    {
        StringBuilder mensaje = new StringBuilder();
        mensaje.AppendLine("\nPOKÉDEX (Elige 6):"); 
        foreach (Pokemon pokemon in Pokedex.listaPokemons)
        {
            mensaje.AppendLine($" \t - {pokemon.Nombre} | Tipo: {pokemon.Tipo}") ;
        }
        return mensaje.ToString();
    }
    /// <summary>
    /// Muestra los pokemones disponibles del catalogo del entrenador a la hora de cambiar de pokemonActual. Si el pokemón esta bajo ataque especial, te lo indica.
    /// </summary>
    /// <param name="entrenador">Nombre del entrenador.</param>
    /// <returns>Pokemones disponibles y efectos</returns>
    public static string PokemonesDisponibles(Entrenador entrenador)
    {
        StringBuilder mensaje = new StringBuilder();
        mensaje.AppendLine("\n");
        mensaje.AppendLine($"POKÉMONES DISPONIBLES PARA CAMBIAR DE: {entrenador.Nombre}");
        foreach (Pokemon pokemon in entrenador.GetMiCatalogo())
        {
            if (pokemon != entrenador.PokemonActual)
            {
                string info = "";
                info += $" \t - ¨{pokemon.Nombre}¨ | Tipo: {pokemon.Tipo} | Vida: {pokemon.VidaTotal}/{pokemon.VidaInicial}";
                if (pokemon == entrenador.PokemonActual)
                {
                    info += $" | (Pokémon Actual)";
                }

                if (pokemon.Dormido)
                {
                    info += $" | (Dormido)";
                }

                if (pokemon.Paralizado)
                {
                    info += $" | (Paralizado)";
                }

                if (pokemon.Envenenado)
                {
                    info += $" | (Envenenado)";
                }

                if (pokemon.Quemado)
                {
                    info += $" | (Quemado)";
                }
                mensaje.AppendLine(info);
            }
        }

        return mensaje.ToString();
    }
 
    /// <summary>
    /// Muestra los ataques disponibles en cada turno dependiendo del pokemon actual. Y si es ataque especial o no.
    /// </summary>
    /// <param name="pokemon">Nombre del pokemon.</param>
    /// <param name="especial">Bool si el ataque es especial o no.</param>
    /// /// <returns>Ataques disponibles</returns>
    public static string AtaquesDisponibles(Pokemon pokemon, bool especial)
    {
        StringBuilder mensaje = new StringBuilder();
        mensaje.AppendLine("\n");
        mensaje.AppendLine($"ATAQUES DISPONIBLES DE {pokemon.Nombre}:");
        foreach (Ataque ataque in pokemon.GetAtaques())
        {
            string info = "";
            if (ataque is AtaqueEspecial ataqueEspecial && especial) 
            {
                info += $" \t - ¨{ataque.Nombre}¨ | Tipo: {ataque.Tipo} | Daño: {ataque.Dano} | Precisión: {ataque.Precision}";
                info+= $" | Efecto: {ataqueEspecial.Efecto}";
                mensaje.AppendLine(info);
            }
            else if (ataque is not AtaqueEspecial)
            {
                info += $" \t - ¨{ataque.Nombre}¨ | Tipo: {ataque.Tipo} | Daño: {ataque.Dano} | Precisión: {ataque.Precision}";
                mensaje.AppendLine(info);
            }
        }
        return mensaje.ToString();
    }

    /// <summary>
    /// Muestra los items disponibles para su uso.
    /// </summary>
    /// <param name="entrenador">Nombre del entrenador.</param>
    /// <returns>Items disponibles.</returns>
    public static string ItemsDisponibles(Entrenador entrenador)
    {
        StringBuilder mensaje = new StringBuilder();
        mensaje.AppendLine("\n");
        mensaje.AppendLine($"ITEMS DISPONIBLES DE {entrenador.Nombre}:");
        int revivir = 0;
        int curaTotal = 0;
        int superPocion = 0;
        foreach (Item item in entrenador.GetMisItems())
        {
            if (item is Revivir)
            {
                revivir += 1;
            }

            if (item is CuraTotal)
            {
                curaTotal += 1;
            }

            if (item is SuperPocion)
            {
                superPocion += 1;
            }
        }

        if (revivir > 0)
        {
            Revivir r = new Revivir();
            mensaje.AppendLine($" \t - ¨Revivir¨ | Descripción: {r.Descripcion} | Disponibles: {revivir}");
        }

        if (curaTotal > 0)
        {
            CuraTotal c = new CuraTotal();
            mensaje.AppendLine($" \t - ¨Cura Total¨ | Descripción: {c.Descripcion} | Disponibles: {curaTotal}");
        }

        if (superPocion > 0)
        {
            SuperPocion s = new SuperPocion();
            mensaje.AppendLine($" \t - ¨Super Poción¨ | Descripción: {s.Descripcion} | Disponibles: {superPocion}");
        }

        return mensaje.ToString();
    }
    
    /// <summary>
    /// Muestra la información general de cada entrenador, pokemones disponibles, pokemon actual, podemones bajo efecto especial y lista de pokemones muertos.
    /// </summary>
    /// <param name="entrenador">Nombre del entrenador y sus correspondientes datos.</param>
    /// <returns>Catalogo del entrenador</returns>
    public static string InformacionGeneral(Entrenador entrenador)
    {
        StringBuilder mensaje = new StringBuilder();
        mensaje.AppendLine("\n");
        mensaje.AppendLine($"CATÁLOGO DE {entrenador.Nombre}:");
        foreach (Pokemon pokemon in entrenador.GetMiCatalogo())
        {
            string info = "";
            info += $" \t - ¨{pokemon.Nombre}¨ | Tipo: {pokemon.Tipo} | Vida: {pokemon.VidaTotal}/{pokemon.VidaInicial}";
            if (pokemon == entrenador.PokemonActual)
            {
                info += $" | (Pokémon Actual)";
            }

            if (pokemon.Dormido)
            {
                info += $" | (Dormido)";
            }

            if (pokemon.Paralizado)
            {
                info += $" | (Paralizado)";
            }

            if (pokemon.Envenenado)
            {
                info += $" | (Envenenado)";
            }

            if (pokemon.Quemado)
            {
                info += $" | (Quemado)";
            }
            mensaje.AppendLine(info);
        }
        
        if (entrenador.GetMisMuertos().Count > 0)
        {
            foreach (Pokemon muerto in entrenador.GetMisMuertos())
            { 
                mensaje.AppendLine($" \t - ¨{muerto.Nombre}¨ | Tipo: {muerto.Tipo} | Vida: {muerto.VidaTotal}/{muerto.VidaInicial}\n");
            }
        }
        return mensaje.ToString();
    }
    
    /// <summary>
    /// Muestra el pokemon actual elegido aleatoriamente del catalogo del entrenador.
    /// </summary>
    /// <param name="batalla">Nombre de los dos jugadores en batalla.</param>
    /// <returns>Pokemon aleatorio de cada entrenador.</returns>
    public static string PokemonesIniciales(Batalla batalla)
    {
        StringBuilder mensaje = new StringBuilder();
        mensaje.AppendLine("\n");
        mensaje.AppendLine("COMIENZO:");
        mensaje.AppendLine($" \t - Se ha elegido aleatoriamente a ¨{batalla.GetPokemonActualJ1()}¨ como Pokémon inicial de {batalla.GetNombreJ1()}");
        mensaje.AppendLine($" \t - Se ha elegido aleatoriamente a ¨{batalla.GetPokemonActualJ2()}¨ como Pokémon inicial de {batalla.GetNombreJ2()}");
        mensaje.AppendLine(Mensaje.Turno(batalla.Jugador1));
        return mensaje.ToString();
    }
    
    /// <summary>
    /// Muestra de quien es el turno en pantalla. 
    /// </summary>
    /// <param name="entrenador">Nombre del entrenador.</param>
    /// /// <returns>Turno.</returns>
    public static string Turno(Entrenador entrenador)
    {
        return $"\n------------------TURNO DE {entrenador.Nombre}------------------";
    }

    /// <summary>
    /// Retorna que la acción elegida no es válida.
    /// </summary>
    /// <returns>No puedes realizar esa acción.</returns>
    public static string AccionInvalida()
    {
        return "No puedes realizar esa acción";
    }

    /// <summary>
    /// Retorna que el ataque elegido no es válido.
    /// </summary>
    /// /// <returns>No posees ese ataque.</returns>
    public static string AtaqueInvalido()
    {
        return "No posees ese ataque";
    }

    /// <summary>
    /// Retorna que el pokemon elegido no es válido
    /// </summary>
    /// /// <returns>No posees ese Pokémon.</returns>
    public static string PokemonInvalido()
    {
        return "No posees ese Pokémon";
    }
        
    /// <summary>
    /// Devuelve mensaje de encuentro, menciona ataque usado, a qué pokemon ha atacado y la información general de cada jugador.
    /// </summary>
    /// <param name="entrenador">Nombre del atacante.</param>
    /// <param name="ataque">Nombre del ataque usado.</param>
    /// <param name="oponente">Nombre del oponente.</param>
    /// /// <returns>Ataque.</returns>
    public static string Encuentro(Entrenador entrenador, Ataque ataque, Entrenador oponente)
    {
        StringBuilder mensaje = new StringBuilder();
        mensaje.AppendLine("\n");
        mensaje.AppendLine($"ATAQUE DE {entrenador.Nombre}:");
        mensaje.AppendLine($" \t - {entrenador.GetPokemonActual()} ha atacado a {oponente.GetPokemonActual()} de {oponente.Nombre}");
        mensaje.AppendLine($" \t - Ha utilizado el ataque {ataque.Nombre}");
        mensaje.Append(Mensaje.InformacionGeneral(entrenador));
        mensaje.Append(Mensaje.InformacionGeneral(oponente));
        mensaje.Append(Mensaje.Turno(oponente));
        return mensaje.ToString();
    }

    /// <summary>
    /// Muestra que entrenador usó el item y en qué pokemon se usó
    /// </summary>
    /// <param name="entrenador">Nombre del atacante.</param>
    /// <param name="item">Item a usar</param>
    /// <param name="pokemon">Pokemon al que se le añade el item.</param>
    /// /// <returns>Item usado.</returns>
    public static string UsoItem(Entrenador entrenador, Item item, Pokemon pokemon)
    {
        StringBuilder mensaje = new StringBuilder();
        mensaje.AppendLine("\n");
        mensaje.AppendLine($"USO DE ITEM DE {entrenador.Nombre}:");
        mensaje.AppendLine($" \t - {item.Nombre} fue usado en {pokemon.Nombre}");
        mensaje.Append(Mensaje.InformacionGeneral(entrenador));
        return mensaje.ToString();
    }
    
    
    /// <summary>
    /// Muestra el fin de la batalla, quién fue el ganador y quién fue el perdedor.
    /// </summary>
    /// <param name="batalla">Batalla, jugadores involucrados.</param>
    /// <param name="ganador">Entrenador ganador.</param>
    /// <param name="perdedor">Entrenador perdedor.</param>
    /// /// <returns>Ganador y perdedor.</returns>
    public static string Fin(Batalla batalla, Entrenador ganador, Entrenador perdedor)
    {
        StringBuilder mensaje = new StringBuilder();
        mensaje.AppendLine("\n");
        mensaje.AppendLine($"FIN DE LA BATALLA:");
        mensaje.AppendLine($" \t - {ganador.Nombre} le ha ganado a {perdedor.Nombre}");
        return mensaje.ToString();
    }

    /// <summary>
    /// Muestra el entrenador y el cambio de su pokemon actual.
    /// </summary>
    /// <param name="entrenador">Nombre del entrenador.</param>
    /// /// <returns>Cambio de pokemon actual.</returns>
    public static string CambioPokemon(Entrenador entrenador)
    {
        return $"{entrenador.Nombre} ha cambiado su Pokémon actual a {entrenador.GetPokemonActual()}";
    }
}
