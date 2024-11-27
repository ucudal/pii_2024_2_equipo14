using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase CambiarPokemonTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(CambiarPokemon))]
public class CambiarPokemonTests
{
    private Pokemon pokemonActual;
    private Pokemon cambio;
    private Entrenador entrenador;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
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
    /// <summary>
    /// Este test comprueba que se cambie a un nuevo Pokémon actual de los del catálogo del entrenador.
    /// </summary>
    [Test]
    public void TestCambioDePokemon()
    {
       CambiarPokemon.CambioDePokemon(entrenador,"Bulbasaur");
       Pokemon esperado = cambio;
       Assert.That(esperado,Is.EqualTo(entrenador.PokemonActual));
    }
}