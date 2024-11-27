using System.Collections.ObjectModel;
using Library;
using NUnit.Framework;
using NUnit.Framework.Internal;
namespace LibraryTests;
/// <summary>
/// Esta es la clase ListaDeEsperaTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(ListaDeEspera))]
public class ListaDeEsperaTests
{
    private ListaDeEspera lista;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        lista = new ListaDeEspera();
        lista.AgregarEntrenador("Jugador");
    }
    /// <summary>
    /// Este test comprueba que se obtenga correctamente los jugadores en la lista de espera.
    /// </summary>
    [Test]
    public void TestGetEsperando()
    {
        ReadOnlyCollection<Entrenador> resultado = lista.GetEsperando();
        int esperado = 1;
        Assert.That(esperado,Is.EqualTo(resultado.Count));
    }
    /// <summary>
    /// Este test comprueba que se agregue correctamente un entrenador a la lista de espera.
    /// </summary>
    [Test]
    public void TestAgregarEntrenador()
    {
        int esperado = 1;
        Assert.That(esperado,Is.EqualTo(lista.Count));
    }
    /// <summary>
    /// Este test comprueba que se quite correctamente un entrenador de la lista de espera.
    /// </summary>
    [Test]
    public void TestQuitarEntrenador()
    {
        lista.QuitarEntrenador("Jugador");
        int esperado = 0;
        Assert.That(esperado,Is.EqualTo(lista.Count));
    }
    /// <summary>
    /// Este test comprueba que se pueda encontrar a un jugador en la lista de espera por su nombre.
    /// </summary>
    [Test]
    public void TestEncontrarJugadorPorUsuario()
    {
        Entrenador entrenador = lista.EncontrarJugadorPorUsuario("Jugador");
        string esperado = "Jugador";
        Assert.That(esperado,Is.EqualTo(entrenador.Nombre));
    }
    /// <summary>
    /// Este test comprueba que se pueda obtener a un jugador en la lista de espera por su nombre.
    /// </summary>
    [Test]
    public void TestGetAlguienEspeando()
    {
        Entrenador entrenador = lista.GetAlguienEsperando("Jugador");
        string esperado = "Jugador";
        Assert.That(esperado,Is.EqualTo(entrenador.Nombre));
    }
}