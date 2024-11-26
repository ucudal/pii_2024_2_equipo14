using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Efectividad))]
public class EfectividadTests
{
    private Ataque ataque1;
    private Ataque ataque2;
    private Ataque ataque3;
    private Ataque ataque4;
    private Pokemon pokemon;

    [SetUp]
    public void SetUp()
    {
        ataque1 = new Ataque("Ataque", 10, 80, "Tierra");
        ataque2 = new Ataque("Ataque", 10, 80, "Volador");
        ataque3 = new Ataque("Ataque", 10, 80, "Eléctrico");
        ataque4 = new Ataque("Ataque", 10, 80, "Planta");
        pokemon = new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 20, "Eléctrico"), new Zzz());
    }

    [Test]
    public void TestCalcularDebilidad()
    {
        int esperado = 20;
        int resultado = Efectividad.CalcularEfectividad(ataque1, pokemon);
        Assert.That(esperado, Is.EqualTo(resultado));
    }

    [Test]
    public void TestCalcularResistencia()
    {
        int esperado = 5;
        int resultado = Efectividad.CalcularEfectividad(ataque2, pokemon);
        Assert.That(esperado, Is.EqualTo(resultado));
    }

    [Test]
    public void TestCalcularInmunidad()
    {
        int esperado = 0;
        int resultado = Efectividad.CalcularEfectividad(ataque3, pokemon);
        Assert.That(esperado,Is.EqualTo(resultado));
    }

    [Test]
    public void TestCalcularNormal()
    {
        int esperado = 10;
        int resultado = Efectividad.CalcularEfectividad(ataque4, pokemon);
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    
}