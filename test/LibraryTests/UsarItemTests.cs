using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(UsarItem))]
public class UsarItemTests
{

    private Entrenador entrenador;
    private Revivir usarRevivir;
    private SuperPocion usarSuperPocion;
    private CuraTotal usarCuraTotal;
    
    [SetUp]
    public void SetUp()
    {
        entrenador = new Entrenador("Jugador");
        entrenador.misItems.Add(usarRevivir);
        entrenador.misItems.Add(usarSuperPocion);
        entrenador.misItems.Add(usarCuraTotal);
    }
    
    [Test]
    public void TestUsoDeItem()
    {
        bool esperadoRevivir = true;
        bool esperadoSuperPocion = true;
        bool esperadoCuraTotal = true;
        Assert.That(esperadoRevivir,Is.EqualTo(entrenador.misItems.Contains(usarRevivir)));
        Assert.That(esperadoSuperPocion,Is.EqualTo(entrenador.misItems.Contains(usarSuperPocion)));
        Assert.That(esperadoCuraTotal,Is.EqualTo(entrenador.misItems.Contains(usarCuraTotal)));
    }
}