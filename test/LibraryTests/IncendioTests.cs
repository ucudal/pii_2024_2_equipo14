using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Incendio))]
public class IncendioTests
{
    private AtaqueEspecial incendio;
    private Pokemon pokemon;

    [SetUp]
    public void SetUp()
    { 
        incendio = new Incendio();
        pokemon = new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
    }
    
    [Test]
    public void TestInstanciarIncendio()
    {

        string esperado = "Incendio";
        int esperado1 = 10;
        int esperado2 = 70;
        string esperado3 = "Fuego";
        string esperado4 = "Quemar";
        Assert.That(esperado, Is.EqualTo(incendio.Nombre));
        Assert.That(esperado1, Is.EqualTo(incendio.Dano));
        Assert.That(esperado2, Is.EqualTo(incendio.Precision));
        Assert.That(esperado3, Is.EqualTo(incendio.Tipo));
        Assert.That(esperado4, Is.EqualTo(incendio.Efecto));
    }
    [Test]
    public void TestCausarEfecto()
    {
        incendio.CausarEfecto(null,pokemon,1);
        bool esperado = true;
        int esperado1 = 62;
        Assert.That(esperado,Is.EqualTo(pokemon.Quemado));
        Assert.That(esperado1,Is.EqualTo(pokemon.VidaTotal));
    }
}
