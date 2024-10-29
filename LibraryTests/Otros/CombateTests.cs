using NUnit.Framework;
using Library;

namespace LibraryTests.Otros;

[TestFixture]
[TestOf(typeof(Combate))]
public class CombateTests
{

    [Test]
    public void METHOD()
    {
        
    }

    [Test]
    public void TestIniciarCombate()
    {
        Entrenador jugador1 = new Entrenador("Jugador1");
        Entrenador jugador2 = new Entrenador("Jugador2");
        Combate.IniciarCombate(jugador1,jugador2);
        
        bool jugador1TurnoEsperado = true;
        bool enCombateEsperado = true;
        string jugador1Esperado = "Jugador1";
        string jugador2Esperado = "Jugador2";
        
        Assert.That(jugador1TurnoEsperado.Equals(jugador1.Turno));
        Assert.That(enCombateEsperado.Equals(Combate.enCombate));
        Assert.That(jugador1Esperado.Equals(Combate.GetJugadoresActuales()[0].GetNombre()));
        Assert.That(jugador2Esperado.Equals(Combate.GetJugadoresActuales()[1].GetNombre()));
    }

}