using PokemonP2;

public class Program
{
    public static void Main()
    {
        Jugador isabela = new Jugador("Isabela");
        isabela.AgregarPokemon(new Bulbasaur());
        isabela.AgregarPokemon(new Squirtle());
        isabela.AgregarPokemon(new Oddish());
        isabela.AgregarPokemon(new Charmander());
        isabela.AgregarPokemon(new Vulpix());
        isabela.AgregarPokemon(new Psyduck());
        
        Jugador vanesa = new Jugador("Vanesa");
        vanesa.AgregarPokemon(new Charmander());
        vanesa.AgregarPokemon(new Psyduck());
        vanesa.AgregarPokemon(new Oddish());
        vanesa.AgregarPokemon(new Bulbasaur());
        vanesa.AgregarPokemon(new Vulpix());
        vanesa.AgregarPokemon(new Squirtle());

        isabela.PokemonActual = isabela.GetMisPokemons()[0];
        vanesa.PokemonActual = vanesa.GetMisPokemons()[1];
        
        Combate.IniciarCombate(isabela,vanesa);
        isabela.Atacar(vanesa);
        vanesa.Atacar(isabela);
        isabela.AtacarEspecial(vanesa);
        vanesa.Atacar(isabela);
        isabela.Atacar(vanesa);
        
    }
}