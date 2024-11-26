using System.Collections.ObjectModel;
using Library;
using NUnit.Framework;
using NUnit.Framework.Internal;
namespace LibraryTests;
[TestFixture]
[TestOf(typeof(ListaDeEspera))]
public class ListaDeEsperaTests
{
    private ListaDeEspera lista;
    
    [SetUp]
    public void SetUp()
    {
        lista = new ListaDeEspera();
        lista.AgregarEntrenador("Jugador");
    }

    [Test]
    public void TestGetEsperando()
    {
        ReadOnlyCollection<Entrenador> resultado = lista.GetEsperando();
        int esperado = 1;
        Assert.That(esperado,Is.EqualTo(resultado.Count));
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
    public void TestEncontrarJugadorPorUsuario()
    {
        Entrenador entrenador = lista.EncontrarJugadorPorUsuario("Jugador");
        string esperado = "Jugador";
        Assert.That(esperado,Is.EqualTo(entrenador.Nombre));
    }

    [Test]
    public void TestGetAlguienEspeando()
    {
        Entrenador entrenador = lista.GetAlguienEsperando("Jugador");
        string esperado = "Jugador";
        Assert.That(esperado,Is.EqualTo(entrenador.Nombre));
    }
}