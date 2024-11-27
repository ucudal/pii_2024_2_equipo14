using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase ListaBatallasTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(ListaBatallas))]
public class ListaBatallasTests
{
    private Batalla batalla;
    private ListaBatallas lista;
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
        lista = new ListaBatallas();
        lista.AgregarBatalla("j1", "j2");
        batalla = lista.GetBatallas()[0];
    }
    /// <summary>
    /// Este test comprueba que se agregue correctamente una batalla a la lista.
    /// </summary>
    [Test]
    public void TestAgregarBatalla()
    {
        int esperado = 1;
        Assert.That(esperado,Is.EqualTo(lista.GetBatallas().Count));
    }
    /// <summary>
    /// Este test comprueba que se quita correctamente una batalla de la lista.
    /// </summary>
    [Test]
    public void TestQuitarBatalla()
    {
        int esperado = 0;
        lista.QuitarBatalla(batalla);
        Assert.That(esperado,Is.EqualTo(lista.GetBatallas().Count));
    }

}