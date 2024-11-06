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
}