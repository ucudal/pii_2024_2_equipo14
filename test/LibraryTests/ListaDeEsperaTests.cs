using Library;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(ListaDeEspera))]
public class ListaDeEsperaTests
{
    private ListaDeEspera lista;
    private Entrenador jugador;
    
    [SetUp]
    public void SetUp()
    {
        lista = new ListaDeEspera();
        lista.AgregarEntrenador("Jugador");
        Entrenador jugador = lista.GetAlguienEsperando("Jugador");
    }
    
    [Test]
    public void TestAgregarEntrenador()
    {
        int esperado = 1;
        Assert.That(esperado,Is.EqualTo(lista.Count));
    }

    [Test]
    public void TestQuitarEntrenador()
    {
        lista.QuitarEntrenador("Jugador");
        int esperado = 0;
        Assert.That(esperado,Is.EqualTo(lista.Count));
    }

    [Test]
    public void TestEncontrarJugadorPorUsuario() //falta
    {
        Entrenador entrenador = lista.EncontrarJugadorPorUsuario("Jugador");
        Assert.That(entrenador,Is.Not.Null);
    }

    [Test]
    public void TestGetAlguienEspeando() //falta
    {
        Entrenador entrenador = lista.GetAlguienEsperando("Jugador");
        Assert.That(entrenador,Is.Not.Null);
    }
}