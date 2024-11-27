using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase BatallaTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(Batalla))]
public class BatallaTests
{
    private Batalla batalla;
    private Entrenador jugador1;
    private Entrenador jugador2;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        jugador1 = new Entrenador("Jugador1");
        jugador2 = new Entrenador("Jugador2");
        batalla = new Batalla(jugador1,jugador2);
    }
    /// <summary>
    /// Este test comprueba que se cree correctamente una Batalla.
    /// </summary>
    [Test]
    public void TestCrearBatalla()
    {
        Entrenador esperado1 = jugador1;
        Entrenador esperado2 = jugador2;
        int esperado3 = 7;
        Assert.That(esperado1,Is.EqualTo(batalla.Jugador1));
        Assert.That(esperado2,Is.EqualTo(batalla.Jugador2));
        Assert.That(esperado3,Is.EqualTo(jugador1.GetMisItems().Count));
        Assert.That(esperado3,Is.EqualTo(jugador2.GetMisItems().Count));
    }
    /// <summary>
    /// Este test comprueba que se asigne correctamente un Pokémon actual a cada jugador.
    /// </summary>
    [Test]
    public void TestAsignarInicial()
    {
        jugador1.AgregarPokemon(Pokedex.BuscarPokemon("Pikachu"));
        jugador1.AgregarPokemon(Pokedex.BuscarPokemon("Mew"));
        jugador1.AgregarPokemon(Pokedex.BuscarPokemon("Bulbasaur"));
        jugador1.AgregarPokemon(Pokedex.BuscarPokemon("Caterpie"));
        jugador1.AgregarPokemon(Pokedex.BuscarPokemon("Charmander"));
        jugador1.AgregarPokemon(Pokedex.BuscarPokemon("Vullaby"));
        jugador2.AgregarPokemon(Pokedex.BuscarPokemon("Vulpix"));
        jugador2.AgregarPokemon(Pokedex.BuscarPokemon("Cubone"));
        jugador2.AgregarPokemon(Pokedex.BuscarPokemon("Cranidos"));
        jugador2.AgregarPokemon(Pokedex.BuscarPokemon("Diglett"));
        jugador2.AgregarPokemon(Pokedex.BuscarPokemon("Snorlax"));
        jugador2.AgregarPokemon(Pokedex.BuscarPokemon("Ponyta"));
        batalla.AsignarPokemonInicial(jugador1);
        batalla.AsignarPokemonInicial(jugador2);
        Assert.That(jugador1.PokemonActual,Is.Not.Null);
        Assert.That(jugador2.PokemonActual,Is.Not.Null);
    }
}