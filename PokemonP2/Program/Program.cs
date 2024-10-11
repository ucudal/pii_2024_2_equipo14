using PokemonP2;

public class Program
{
    public static void Main()
    {
        Jugador isabela = new Jugador("Isabela");
        Jugador vanesa = new Jugador("Vanesa");
        isabela.AgregarPokemon(new Bulbasaur());
        vanesa.AgregarPokemon(new Charmander());
        Console.Write(isabela.GetMisPokemons()[0]);
    }
}