using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Efectividad))]
public class EfectividadTests
{

    private Ataque ataque;
    private Pokemon pokemon;

    [SetUp]
    public void SetUp()
    {
        ataque = new Ataque("Ataque", 10, 80, "Tierra");
        pokemon = new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 20, "Eléctrico"), new Zzz());
    }

    [Test]
    public void TestCalcularEfectividad()
    {
        int esperado = 20;
        Assert.That(esperado, Is.EqualTo(Efectividad.CalcularEfectividad(ataque, pokemon)));
    }
}