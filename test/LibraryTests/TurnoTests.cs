using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase TurnoTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(Turno))]
public class TurnoTests
{
    private Entrenador jugador;
    private Entrenador oponente;
    private Pokemon pokemon;
    private Pokemon cambio;
    private Pokemon pokemonOp;
    private Item curaTotal;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        jugador = new Entrenador("Jugador");
        oponente = new Entrenador("Oponente");
        pokemon = Pokedex.BuscarPokemon("Pikachu");
        cambio = Pokedex.BuscarPokemon("Squirtle");
        pokemonOp = Pokedex.BuscarPokemon("Mew");   
        curaTotal = new CuraTotal();
        jugador.AgregarPokemon(pokemon);
        jugador.AgregarPokemon(cambio);
        jugador.AgregarItem(curaTotal);
        jugador.PokemonActual = pokemon;
        oponente.PokemonActual = pokemonOp;
        jugador.MiTurno = true;
    }
    /// <summary>
    /// Este test comprueba que se valide correctamente la acción "Atacar".
    /// </summary>
    [Test]
    public void TestValidarAtacar()
    {
        bool resultado = Turno.ValidarAccion(jugador, "Atacar");
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se valide correctamente una ataque.
    /// </summary>
    [Test]
    public void TestValidarAtaque()
    {
        bool resultado = Turno.ValidarAtaque(jugador, pokemon.Ataque, pokemonOp);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se realice correctamente la acción "Atacar".
    /// </summary>
    [Test]
    public void TestHacerAtacar()
    {
        Turno.HacerAccion(jugador,"Atacar",oponente,pokemon.Ataque,null,null,null);
        int esperado = 40;
        bool esperado1 = false;
        bool esperado2 = true;
        Assert.That(esperado,Is.EqualTo(pokemonOp.VidaTotal));
        Assert.That(esperado1,Is.EqualTo(jugador.MiTurno));
        Assert.That(esperado2,Is.EqualTo(oponente.MiTurno));
    }
    /// <summary>
    /// Este test comprueba que se valide correctamente la acción "Usar Item".
    /// </summary>
    [Test]
    public void TestValidarUsarItem()
    {
        pokemon.RecibirDano(10);
        bool resultado = Turno.ValidarAccion(jugador, "Usar Item");
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se valide correctamente un item.
    /// </summary>
    [Test]
    public void TestValidarItem()
    {
        pokemon.Paralizado = true;
        bool resultado = Turno.ValidarItem(jugador, curaTotal, pokemon);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se realice correctamente la acción "Usar Item".
    /// </summary>
    [Test]
    public void TestHacerUsoItem()
    {
        pokemon.Paralizado = true;
        Turno.HacerAccion(jugador, "Usar Item", oponente, null, null, curaTotal, pokemon);
        bool esperado = false;
        bool esperado1 = true;
        Assert.That(esperado,Is.EqualTo(pokemon.Paralizado));
        Assert.That(esperado, Is.EqualTo(jugador.MiTurno));
        Assert.That(esperado1, Is.EqualTo(oponente.MiTurno));
    }
    /// <summary>
    /// Este test comprueba que se valide correctamente la acción "Cambiar Pokémon".
    /// </summary>
    [Test]
    public void TestValidarCambiarPokemon()
    {
        bool resultado = Turno.ValidarAccion(jugador, "Cambiar Pokémon");
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se realice correctamente la acción "Cambiar Pokémon".
    /// </summary>
    [Test]
    public void TestHacerCambioPokemon()
    {
        Turno.HacerAccion(jugador,"Cambiar Pokémon",oponente,null,cambio.Nombre,null,null);
        Pokemon esperado = cambio;
        Assert.That(esperado,Is.EqualTo(jugador.PokemonActual));
    }
}