using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(CambiarPokemon))]
public class CambiarPokemonTests
{
    private Pokemon pokemonActual;
    private Pokemon cambio;
    private Entrenador entrenador;
    
    [SetUp]
    public void SetUp()
    {
        pokemonActual = new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
        cambio = new Pokemon("Bulbasaur", "Planta", new Ataque("Florecer", 10, 70, "Planta"), new Incendio());
        entrenador = new Entrenador("entrenador");
        entrenador.AgregarPokemon(pokemonActual);
        entrenador.AgregarPokemon(cambio);
        entrenador.PokemonActual = pokemonActual;
    }

    [Test]
    public void TestCambioDePokemon()
    {
       CambiarPokemon.CambioDePokemon(entrenador,"Bulbasaur");
       Pokemon esperado = cambio;
       Assert.That(esperado,Is.EqualTo(entrenador.PokemonActual));
    }
}