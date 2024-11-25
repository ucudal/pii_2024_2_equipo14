using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Turno))]
public class TurnoTests
{
    private Entrenador jugador;
    private Entrenador oponente;
    private Pokemon pokemon;
    private Pokemon cambio;
    private Pokemon pokemonOp;
    private Item revivir;

    [SetUp]
    public void SetUp()
    {
        jugador = new Entrenador("Jugador");
        oponente = new Entrenador("Oponente");
        pokemon = Pokedex.BuscarPokemon("Pikachu");
        cambio = Pokedex.BuscarPokemon("Squirtle");
        pokemonOp = Pokedex.BuscarPokemon("Mew");
        revivir = new Revivir();
        jugador.AgregarPokemon(pokemon);
        jugador.AgregarPokemon(cambio);
        jugador.PokemonActual = pokemon;
    }

    [Test]
    public void TestValidarAtacar()
    {
        bool resultado = Turno.ValidarAccion(jugador, "Atacar");
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado));
    }

    [Test]
    public void TestValidarUsarItem()
    {
        pokemon.RecibirDano(10);
        bool resultado = Turno.ValidarAccion(jugador, "Usar Item");
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado));
    }

    [Test]
    public void TestValidarCambiarPokemon()
    {
        bool resultado = Turno.ValidarAccion(jugador, "Cambiar Pokémon");
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado));
    }
}