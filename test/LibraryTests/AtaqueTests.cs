using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Library.Ataque))]
public class AtaqueTests
{
    private Ataque ataque;

    [SetUp]
    public void SetUp()
    {
        ataque = new Ataque("Florecer", 10, 70, "Planta");
    }

    [Test] 
    public void TestAtaque() {


        string esperado = "Florecer";
        Assert.That(esperado, Is.EqualTo(ataque.Nombre));
        int esperado2 = 10;
        Assert.That(esperado2, Is.EqualTo(ataque.Dano));
        int esperado3 = 70;
        Assert.That(esperado3, Is.EqualTo(ataque.Precision));
        string esperado4 = "Planta";
        Assert.That(esperado4, Is.EqualTo(ataque.Tipo));
    } 

    [Test]
    public void TestCalcularPrecision()
    {
        int preciso = ataque.CalcularPrecision();
        Assert.That(preciso,Is.LessThanOrEqualTo(1));
    }
}