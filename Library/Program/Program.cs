using Library;

public class Program
{
    public static void Main()
    {
        Entrenador entrenador = new Entrenador("Romeo");
        entrenador.AgregarPokemon("Pikachu");
        entrenador.AgregarPokemon("Mew");
        entrenador.AgregarPokemon("Bulbasaur");
        entrenador.AgregarPokemon("Dratini");
        entrenador.AgregarPokemon("Psyduck");
        entrenador.AgregarPokemon("Goomy");

        Entrenador entrenador2 = new Entrenador("Julieta");
        entrenador2.AgregarPokemon("Skarmory");
        entrenador2.AgregarPokemon("Squirtle");
        entrenador2.AgregarPokemon("Vulpix");
        entrenador2.AgregarPokemon("Vanillite");
        entrenador2.AgregarPokemon("Ponyta");
        entrenador2.AgregarPokemon("Eevee");

        Batalla batalla = new Batalla(entrenador, entrenador2);
        batalla.Comenzar();
    }
}