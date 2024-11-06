using Library;

public class Program
{
    public static void Main()
    {
        Entrenador entrenador = new Entrenador("ash");
        entrenador.AgregarPokemon("Pikachu");
        entrenador.AgregarPokemon("Mew");
        Consola.ElegirPokemon(entrenador);
        Consola.ElegirAtaque(entrenador.miCatalogo[0]);
    }
}