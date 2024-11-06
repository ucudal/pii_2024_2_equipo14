namespace Library;

public static class Consola
{
    public static void ElegirPokemon(Entrenador entrenador)
    {
        Console.WriteLine("Seleccione un pokemon por su número");
        Console.WriteLine($"LISTA POKÉMONS DE {entrenador.Nombre}:");
        for (int i = 0; i < entrenador.miCatalogo.Count; i++)
        {
            Pokemon pokemon = entrenador.miCatalogo[i];
            Console.WriteLine($"{i} - ¨{pokemon.Nombre}¨ de tipo: {pokemon.GetNombreTipo()}");
            
        }
    }

    public static void ElegirAtaque(Pokemon pokemon)
    {
        Console.WriteLine("Seleccione un ataque por su número");
        Console.WriteLine($"LISTA ATAQUES DE {pokemon.Nombre}");
        for (int i = 0; i < pokemon.misAtaques.Count; i++)
        {
            Ataque ataque = pokemon.misAtaques[i];
            string mensaje = $"{i} - ¨{ataque.Nombre}¨, tipo: {ataque.GetNombreTipo()}, daño: {ataque.Dano}, precisión: {ataque.Precision*100}%";
            if (ataque is AtaqueEspecial ataqueEspecial)
            {
                mensaje += $", efecto: {ataqueEspecial.Efecto}";
            }
            Console.WriteLine(mensaje);
        }
    }

    public static void AccionesDeTurno()
    {
        Console.WriteLine("Seleccione una acción por su número");
        Console.WriteLine("LISTA DE ACCIONES:");
        for (int i = 0; i < Turno.GetAcciones().Count; i++)
        {
            string accion = Turno.GetAcciones()[i];
            Console.WriteLine($"{i} - {accion}");
        }
    }

    public static void ElegirItem(Entrenador entrenador)
    {
        Console.WriteLine("Seleccione un item");
        Console.WriteLine($"LISTA DE ITEMS DE {entrenador.MisItems}");
        for (int i = 0; i < entrenador.MisItems.Count; i++)
        {
            Item item = entrenador.MisItems[i];
            Console.WriteLine($"{i} - {item.Nombre}");
        }
    }

    public static void ElegirRevivir(Pokemon pokemon)
    {
        Console.WriteLine($"¿Quieres revivir a {pokemon.Nombre}? Ingrese 0 para SI o 1 para NO");
    }
}