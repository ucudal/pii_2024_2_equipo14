namespace Library;

public static class Consola
{
  public static void ElegirAccion()
  {
    Console.WriteLine("\nLISTA DE ACCIONES (Seleccione según el número):");
    Console.WriteLine("\t0 - Atacar");
    Console.WriteLine("\t1 - Cambiar Pokemon");
    Console.WriteLine("\t2 - Usar item");
  }

  public static void ElegirPokemon(Entrenador usuario)
  {
    Console.WriteLine("\nLISTA DE POKEMONES DISPONIBLES (Seleccione según el número):");
    for (int i = 0; i < usuario.miCatalogo.Count; i++)
    {
      Pokemon pokemon = usuario.miCatalogo[i];
      Console.WriteLine($"\t{i} - ¨{pokemon.Nombre}¨ de Tipo: {pokemon.Tipo}");
    }
  }

  public static void ElegirAtaque(Pokemon pokemon)
  {
    Console.WriteLine($"\nLISTA DE ATAQUES DISPONIBLES DE {pokemon.Nombre} (Seleccione según el número:");
    for (int i = 0; i < pokemon.ataques.Count; i++)
    {
      Ataque ataque = pokemon.ataques[i];
      string mensaje = $"\t{i} - ¨{ataque.Nombre}¨/Tipo: {ataque.Tipo}/Daño: {ataque.Dano}/Precision: {ataque.Precision}";
      if (ataque is AtaqueEspecial ataqueEspecial)
      {
        mensaje += $"/(Especial)Efecto: {ataqueEspecial.Efecto}";
      }
      Console.WriteLine(mensaje);
    }
  }
  public static void ElegirAtaqueSimple(Pokemon pokemon)
  {
    Console.WriteLine($"\nEl pokemon a atacar está bajo algún efecto de ataques especiales. Solo puede atacar con ataques simples");
    Console.WriteLine($"LISTA DE ATAQUES SIMPLES DISPONIBLES DE {pokemon.Nombre} (Seleccione según el número:");
    for (int i = 0; i < pokemon.ataques.Count; i++)
    {
      Ataque ataque = pokemon.ataques[i];
      if (ataque is not AtaqueEspecial)
      {
        Console.WriteLine($"\t{i} - ¨{ataque.Nombre}¨/Tipo: {ataque.Tipo}/Daño: {ataque.Dano}/Precision: {ataque.Precision}");
      }
    }
  }

  public static void ElegirItem(Entrenador usuario)
  {
    Console.WriteLine($"\nLISTA DE ITEMS DISPONIBLES DE {usuario.Nombre} (Seleccione según el número:");
    for (int i = 0; i < usuario.MisItems.Count; i++)
    {
      Item item = usuario.MisItems[i];
      Console.WriteLine($"\t{i} - ¨{item.Nombre}¨({item.Descripcion})");
    }
  }

  public static void ElegirPokemonMuerto(Entrenador usuario)
  {
    Console.WriteLine("\nLISTA DE POKEMONES MUERTOS DISPONIBLES (Seleccione según el número):");
    for (int i = 0; i < usuario.misMuertos.Count; i++)
    {
      Pokemon pokemon = usuario.misMuertos[i];
      Console.WriteLine($"\t{i} - ¨{pokemon.Nombre}¨ de Tipo: {pokemon.Tipo}");
    }
  }
  
}