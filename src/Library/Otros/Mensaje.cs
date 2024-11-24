
namespace Library;

public static class Mensaje
{
    public static string PokedexDisponibles()
    {
        string mensaje = "\nPOKÉDEX (Elige 6):\n";
        foreach (Pokemon pokemon in Pokedex.listaPokemons)
        {
            mensaje += $" \t- ¨{pokemon.Nombre}¨ | Tipo: {pokemon.Tipo}\n";
        }
        return mensaje;
    }

    public static string PokemonesDisponibles(Entrenador entrenador)
    {
        string mensaje = $"\nPOKÉMONES DISPONIBLES PARA CAMBIAR DE: {entrenador.Nombre}";
        foreach (Pokemon pokemon in entrenador.miCatalogo)
        {
            if (pokemon != entrenador.PokemonActual)
            {
                mensaje += $"\t¨{pokemon.Nombre}¨ | Tipo: {pokemon.Tipo} | Vida: {pokemon.VidaTotal}/{pokemon.VidaInicial}";
            }
        }
        return mensaje;
    }
    
    public static string AtaquesDisponibles(Pokemon pokemon)
    {
        string mensaje = $"\nATAQUES DISPONIBLES DE {pokemon.Nombre}:";
        foreach (Ataque ataque in pokemon.GetAtaques())
        {
            mensaje += $"\t¨{ataque.Nombre}¨ | Tipo: {ataque.Tipo} | Daño: {ataque.Dano}";
            if (ataque is AtaqueEspecial ataqueEspecial)
            {
                mensaje += $" | Efecto: {ataqueEspecial.Efecto}";
            }
        }
        return mensaje;
    }

    public static string ItemsDisponibles(Entrenador entrenador)
    {
        string mensaje = $"\nITEMS DE {entrenador.Nombre}:";
        int revivir = 0;
        int curaTotal = 0;
        int superPocion = 0;
        foreach (Item item in entrenador.misItems)
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
            mensaje += $"\t ¨Revivir¨ | Descripción: {r.Descripcion} | Disponibles: {revivir}";
        }
        if (curaTotal > 0)
        {
            CuraTotal c = new CuraTotal();
            mensaje += $"\t¨Cura Total¨ | Descripción: {c.Descripcion} | Disponibles: {curaTotal}";
        }
        if (superPocion > 0)
        {
            SuperPocion s = new SuperPocion();
            mensaje += $"\t¨Super Poción¨ | Descripción: {s.Descripcion} | Disponibles: {superPocion}";
        }
        return mensaje;
    }

    public static string InformacionGeneral(Entrenador entrenador)
    {
        string mensaje = $"\nCATÁLOGO DE {entrenador.Nombre}:";
        foreach (Pokemon pokemon in entrenador.miCatalogo)
        {
            mensaje += $"\t¨{pokemon.Nombre}¨ | Tipo: {pokemon.Tipo} | Vida: {pokemon.VidaTotal}/{pokemon.VidaInicial}";
            if (pokemon == entrenador.PokemonActual)
            {
                mensaje += $"| (Pokémon Actual)";
            }
            if (pokemon.Dormido)
            {
                mensaje += $" | (Dormido)";
            }
            if (pokemon.Paralizado)
            {
                mensaje += $" | (Paralizado)";
            }
            if (pokemon.Envenenado)
            {
                mensaje += $" | (Envenenado)";
            }

            if (pokemon.Quemado)
            {
                mensaje += $" | (Quemado)";
            }
        }
        if (entrenador.misMuertos.Count > 0)
        {
            foreach (Pokemon muerto in entrenador.misMuertos)
            {
                mensaje += $"\t¨{muerto.Nombre}¨ | Tipo: {muerto.Tipo} | Vida: {muerto.VidaTotal}/{muerto.VidaInicial}";
            }
        }
        return mensaje;
    }
}