/*using System.Diagnostics;
using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(ListaDeEspera))]
public class ListaDeEsperaTests
{

    private Entrenador jugador1;
    private Entrenador jugador2;
    private ListaDeEspera listaDeEspera;

    [SetUp]
    public void SetUp()
    
        {
            listaDeEspera = new ListaDeEspera();
            listaDeEspera.AgregarEntrenador("jugador1");
            listaDeEspera.AgregarEntrenador("jugador2");

        }

    [Test] 
    public void TestAgregarEntrenador()
    {
        bool esperado4 = true;
        Assert.That(esperado4, Is.EqualTo(listaDeEspera.AgregarEntrenador("jugador1"))); 
        Assert.That(1, Is.EqualTo(listaDeEspera.Count));
        Assert.That(listaDeEspera.EncontrarJugadorPorUsuario("jugador1"), Is.Not.Null);
    }
        [Test]
        public void TestQuitarEntrenador()
        {
            listaDeEspera.QuitarEntrenador("jugador1");
            Entrenador esperado= listaDeEspera.EncontrarJugadorPorUsuario("jugador1");
            Assert.That(esperado,Is.Null);
        }

        [Test]
        public void TestEncontrarJugadorPorUsuario()
        {
            string esperado2 = "jugador1";
            Assert.That(esperado2, Is.EqualTo(listaDeEspera.EncontrarJugadorPorUsuario("jugador1").Nombre));
        }

        [Test]
        public void TestGetAlguienEsperando()
        {
            bool esperado3 = true;
            Assert.That(esperado3,Is.EqualTo(listaDeEspera.Count>0));
        }
}*/