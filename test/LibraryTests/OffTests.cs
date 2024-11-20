using Library;
using NUnit.Framework;

namespace LibraryTests;
[TestFixture]
[TestOf(typeof(Off))]
public class OffTests
{
    private AtaqueEspecial off;
    private Pokemon pokemon;

    [SetUp]
    public void SetUp()
    {
        off = new Off();
        pokemon = new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 20, "Eléctrico"), new Zzz());
    }
    
    [Test]
    public void TestInstanciarOff()
    {

        string esperado = "Off";
        int esperado1 = 10;
        int esperado2 = 90;
        string esperado3 = "Veneno";
        string esperado4 = "Envenenar";
        
        Assert.That(esperado, Is.EqualTo(off.Nombre));
        Assert.That(esperado1, Is.EqualTo(off.Dano));
        Assert.That(esperado2, Is.EqualTo(off.Precision));
        Assert.That(esperado3, Is.EqualTo(off.Tipo));
        Assert.That(esperado4, Is.EqualTo(off.Efecto));
    } 
    [Test]
    public void TestCausarEfecto()
    {
        off.CausarEfecto(null,pokemon,1);
        bool esperado = true;
        int esperado1 = 66;
        Assert.That(esperado,Is.EqualTo(pokemon.Envenenado));
        Assert.That(esperado1,Is.EqualTo(pokemon.VidaTotal));
    }
}

