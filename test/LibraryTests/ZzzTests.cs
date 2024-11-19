using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Zzz))]
public class ZzzTests
{
    private AtaqueEspecial zzz;
    private Pokemon pokemon;
    private Entrenador entrenador;

    [SetUp]
    public void SetUp()
    {
        zzz = new Zzz();
        entrenador = new Entrenador("Entrenador");
        pokemon = new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 20, "Eléctrico"), new Zzz());
        entrenador.AgregarPokemon(pokemon);
    }

    [Test]
    public void TestInstanciarZzz()
    {

        string esperado = "Zzz";
        int esperado1 = 0;
        int esperado2 = 50;
        string esperado3 = "Normal";
        string esperado4 = "Dormir";
        Assert.That(esperado, Is.EqualTo(zzz.Nombre));
        Assert.That(esperado1, Is.EqualTo(zzz.Dano));
        Assert.That(esperado2, Is.EqualTo(zzz.Precision));
        Assert.That(esperado3, Is.EqualTo(zzz.Tipo));
        Assert.That(esperado4, Is.EqualTo(zzz.Efecto));
    }

    [Test]
    public void TestCausarEfecto()
    {
        zzz.CausarEfecto(entrenador, pokemon, null);
        bool esperado = true;
        Assert.That(esperado, Is.EqualTo(pokemon.Dormido));
        Assert.That(pokemon.TurnosDormido,Is.LessThanOrEqualTo(4));
    }
}

