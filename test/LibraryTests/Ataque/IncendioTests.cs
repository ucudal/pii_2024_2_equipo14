using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Incendio))]
public class IncendioTests
{
    private AtaqueEspecial ataqueEspecial;
    private Pokemon pokemon;

    [SetUp]
    public void SetUp()
    {
        ataqueEspecial = new Incendio();
    }
    
    [Test]
    public void TestCrearAtaqueEspecial()
    {

        string esperado = "Incendio";
        int esperado1 = 10;
        int esperado2 = 70;
        string esperado3 = "Fuego";
        string esperado4 = "Quemar";
        
        Assert.That(esperado, Is.EqualTo(ataqueEspecial.Nombre));
        Assert.That(esperado1, Is.EqualTo(ataqueEspecial.Dano));
        Assert.That(esperado2, Is.EqualTo(ataqueEspecial.Precision));
        Assert.That(esperado3, Is.EqualTo(ataqueEspecial.Tipo));
        Assert.That(esperado4, Is.EqualTo(ataqueEspecial.Efecto));
    }
   /* [Test]
    public void TestCausarEfecto()
    {
        ataqueEspecial.CausarEfecto(null,pokemon,null);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(pokemon.Quemado));
    }*/
}
