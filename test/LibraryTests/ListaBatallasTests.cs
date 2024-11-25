/*using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(ListaBatallas))]
public class ListaBatallasTests
{
    private Entrenador jugador1;
    private Entrenador jugador2;
    private List<Batalla> batallaLista;
    private Batalla batalla;

    [SetUp]
    public void SetUp()
    {
        jugador1 = new Entrenador("jugador1");
        jugador2 = new Entrenador("jugador2");
        batallaLista = new List<Batalla>();
        batalla = new Batalla(jugador1, jugador2);
    }

    [Test]
    public void TestAgregarBatalla()
    {
        batallaLista.Add(batalla);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(batallaLista.Contains(batalla)));

    }
}*/