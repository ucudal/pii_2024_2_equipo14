using NUnit.Framework;
using PokemonP2;

namespace PokemonP2Tests.Otros;

[TestFixture]
[TestOf(typeof(Jugador))]
public class JugadorTests
{
    [Test]
    public void METHOD()
    {
        
    }
    [Test]
    public void TestCrearJugador()
    {
        Jugador jugador1 = new Jugador("Jugador1");

        string nombreEsperado = "Jugador1";
        int elementosListaPokemonEsperados = 0;
        int turnosEsperados = 0;
        
        Assert.That(nombreEsperado.Equals(jugador1.GetNombre()));
        Assert.That(elementosListaPokemonEsperados.Equals(jugador1.GetMisPokemons().Count));
        Assert.That(turnosEsperados.Equals(jugador1.Turnos));

    }

    [Test]
    public void TestAtacar()
    {
        Jugador jugador1 = new Jugador("Jugador1");
        Jugador jugador2 = new Jugador("Jugador2");
        jugador1.AgregarPokemon(new Bulbasaur());
        jugador2.AgregarPokemon(new Oddish());
        jugador1.PokemonActual = jugador1.GetMisPokemons()[0];
        jugador2.PokemonActual = jugador2.GetMisPokemons()[0];
        Combate.IniciarCombate(jugador1,jugador2);
        jugador1.Atacar(jugador2);
        
        int turnosJugador1Esperados = 1;
        bool turnoJugador1Esperado = false;
        bool turnoJugador2Esperado = true;
        int vidaOddishEsperada = 50;
        
        Assert.That(turnosJugador1Esperados.Equals(jugador1.Turnos));
        Assert.That(turnoJugador1Esperado.Equals(jugador1.Turno));
        Assert.That(turnoJugador2Esperado.Equals(jugador2.Turno));
        Assert.That(vidaOddishEsperada.Equals(jugador2.PokemonActual.VidaTotal));
    }

    [Test]
    public void TestAtacarEspecial()
    {
        Jugador jugador1 = new Jugador("Jugador1");
        Jugador jugador2 = new Jugador("Jugador2");
        jugador1.AgregarPokemon(new Bulbasaur());
        jugador2.AgregarPokemon(new Oddish());
        jugador1.PokemonActual = jugador1.GetMisPokemons()[0];
        jugador2.PokemonActual = jugador2.GetMisPokemons()[0];
        Combate.IniciarCombate(jugador1,jugador2);
        jugador1.Atacar(jugador2);
        jugador2.Atacar(jugador1);
        jugador1.AtacarEspecial(jugador2);
        
        int turnosJugador1Esperados = 2;
        bool turnoJugador1Esperado = false;
        bool turnoJugador2Esperado = true;
        int vidaOddishEsperada = -10;
        
        Assert.That(turnosJugador1Esperados.Equals(jugador1.Turnos));
        Assert.That(turnoJugador1Esperado.Equals(jugador1.Turno));
        Assert.That(turnoJugador2Esperado.Equals(jugador2.Turno));
        Assert.That(vidaOddishEsperada.Equals(jugador2.PokemonActual.VidaTotal));
        
    }
}