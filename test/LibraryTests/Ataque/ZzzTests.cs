using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Zzz))]
public class ZzzTests
{
    private AtaqueEspecial ataqueEspecial;
    private Pokemon pokemon;
    private Entrenador entrenador;

    [SetUp]
    public void SetUp()
    {
        ataqueEspecial = new Zzz();
        entrenador = new Entrenador("Entrenador");
        pokemon = new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 20, "Eléctrico"), new Zzz());
    }

    [Test]
    public void TestCrearAtaqueEspecial()
    {

        string esperado = "Zzz";
        int esperado1 = 0;
        int esperado2 = 50;
        string esperado3 = "Normal";
        string esperado4 = "Dormir";

        Assert.That(esperado, Is.EqualTo(ataqueEspecial.Nombre));
        Assert.That(esperado1, Is.EqualTo(ataqueEspecial.Dano));
        Assert.That(esperado2, Is.EqualTo(ataqueEspecial.Precision));
        Assert.That(esperado3, Is.EqualTo(ataqueEspecial.Tipo));
        Assert.That(esperado4, Is.EqualTo(ataqueEspecial.Efecto));
    }

    /*[Test]
    public void TestCausarEfecto()
    {
        ataqueEspecial.CausarEfecto(null, pokemon, null);
        bool esperado = true;
        Assert.That(esperado, Is.EqualTo(pokemon.Dormido));
    }*/
}

