using System.Text;

namespace Library;
/// <summary>
/// Esta es la clase estática Mensaje. Define los mensajes a retornar según la acción que se ejecute en el código.
/// </summary>
public static class Mensaje
{
    /// <summary>
    /// Devuelve la lista de la Pokédex
    /// </summary>
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
    /// Muestra los pokemones disponibles del catalogo del entrenador a la hora de cambiar de Pokémon actual.
    /// </summary>
    /// <param name="entrenador">Nombre del entrenador.</param>
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
    /// Muestra los ataques disponibles para el turno.
    /// </summary>
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
    /// Muestra la información general de cada entrenador, todos sus Pokémones disponibles.
    /// <summary>
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
    /// Muestra los Pokémones actuales elegidos aleatoriamente para cada entrenador en una batalla.
    /// </summary>
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
    /// Muestra de quien es el turno. 
    /// </summary>
    public static string Turno(Entrenador entrenador)
    {
        return $"\n------------------TURNO DE {entrenador.Nombre}------------------";
    }

    /// <summary>
    /// Retorna que la acción elegida no es válida.
    /// </summary>
    public static string AccionInvalida()
    {
        return "No puedes realizar esa acción";
    }

    /// <summary>
    /// Retorna que el ataque elegido no es válido.
    /// </summary>
    public static string AtaqueInvalido()
    {
        return "No posees ese ataque";
    }

    /// <summary>
    /// Retorna que el pokemon elegido no es válido
    /// </summary>
    public static string PokemonInvalido()
    {
        return "No posees ese Pokémon";
    }
        
    /// <summary>
    /// Devuelve mensaje de encuentro, menciona ataque usado, a qué pokemon ha atacado y la información general de cada jugador.
    /// </summary>
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
    /// Muestra el uso de item de un entrenador.
    /// </summary>
    public static string UsoItem(Entrenador entrenador, Item item, Pokemon pokemon)
    {
        StringBuilder mensaje = new StringBuilder();
        mensaje.AppendLine("\n");
        mensaje.AppendLine($"USO DE ITEM DE {entrenador.Nombre}:");
        mensaje.AppendLine($" \t - {item.Nombre} fue usado en {pokemon.Nombre}");
        mensaje.Append(Mensaje.InformacionGeneral(entrenador));
        Batalla batalla = Facade.Instance.EncontrarBatallaPorUsuario(entrenador.Nombre);
        if (batalla.GetNombreJ1() == entrenador.Nombre)
        {
            mensaje.Append(Mensaje.Turno(batalla.Jugador2));
        }
        else
        {
            mensaje.Append(Mensaje.Turno(batalla.Jugador1));
        }
        
        return mensaje.ToString();
    }
    
    
    /// <summary>
    /// Muestra el fin de la batalla, quién fue el ganador y quién fue el perdedor.
    /// </summary>
    public static string Fin(Batalla batalla, Entrenador ganador, Entrenador perdedor)
    {
        StringBuilder mensaje = new StringBuilder();
        mensaje.AppendLine("\n");
        mensaje.AppendLine($"FIN DE LA BATALLA:");
        mensaje.AppendLine($" \t - {ganador.Nombre} le ha ganado a {perdedor.Nombre}");
        return mensaje.ToString();
    }

    /// <summary>
    /// Muestra el cambio de Pokémon actual de un entrenador..
    /// </summary>
    public static string CambioPokemon(Entrenador entrenador)
    {
        StringBuilder mensaje = new StringBuilder();
        mensaje.AppendLine($"{entrenador.Nombre} ha cambiado su Pokémon actual a {entrenador.GetPokemonActual()}");
        Batalla batalla = Facade.Instance.EncontrarBatallaPorUsuario(entrenador.Nombre);

        if (batalla.GetNombreJ1() == entrenador.Nombre)
        {
            mensaje.Append(Mensaje.Turno(batalla.Jugador2));
        }
        else
        {
            mensaje.Append(Mensaje.Turno(batalla.Jugador1));
        }

        return mensaje.ToString();
    }
}