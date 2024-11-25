using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(ListaBatallas))]
public class ListaBatallasTests
{
    private Batalla batalla;
    private ListaBatallas lista;
    private Entrenador jugador1;
    private Entrenador jugador2;
    
    [SetUp]
    public void SetUp()
    {
        jugador1 = new Entrenador("Jugador1");
        jugador2 = new Entrenador("Jugador2");
        lista = new ListaBatallas();
        lista.AgregarBatalla("j1", "j2");
        batalla = lista.GetBatallas()[0];
    }

    [Test]
    public void TestAgregarBatalla()
    {
        int esperado = 1;
        Assert.That(esperado,Is.EqualTo(lista.GetBatallas().Count));
    }

    [Test]
    public void TestQuitarBatalla()
    {
        int esperado = 0;
        lista.QuitarBatalla(batalla);
        Assert.That(esperado,Is.EqualTo(lista.GetBatallas().Count));
    }

}