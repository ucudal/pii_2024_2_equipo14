using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase AtaqueTests. Se encarga de comprobar que se logre instanciar correctamente un Ataque.
/// </summary>
[TestFixture]
[TestOf(typeof(Library.Ataque))]
public class AtaqueTests
{
    private Ataque ataque;
    
    [SetUp]
    public void SetUp()
    {
        ataque = new Ataque("Ataque",10,80,"Fuego");
    }

    [Test]
    public void TestCrearAtaque()
    {
        string esperado = "Ataque";
        int esperado1 = 10;
        int esperado2 = 80;
        string esperado3 = "Fuego";
        Assert.That(esperado,Is.EqualTo(ataque.Nombre));
        Assert.That(esperado1,Is.EqualTo(ataque.Dano));
        Assert.That(esperado2,Is.EqualTo(ataque.Precision));
        Assert.That(esperado3,Is.EqualTo(ataque.Tipo));
    }

    [Test]
    public void TestCalcularPrecision()
    {
        int preciso = ataque.CalcularPrecision();
        Assert.That(preciso,Is.LessThanOrEqualTo(1));
    }
    
}
    
