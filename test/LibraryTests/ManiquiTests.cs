using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Maniqui))]
public class ManiquiTests
{
    private Entrenador entrenador;
    private Pokemon pokemon;
    private AtaqueEspecial maniqui;
    
    [SetUp]
    public void SetUp()
    {
        entrenador = new Entrenador("Entrenador");
        pokemon = new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
        maniqui = new Maniqui();
    }

    [Test]
    public void TestInstanciarManiqui()
    {
        string esperado = "Maniquí";
        int esperado1 = 0;
        int esperado2 = 80;
        string esperado3 = "Psíquico";
        string esperado4 = "Paralizar";
        Assert.That(esperado,Is.EqualTo(maniqui.Nombre));
        Assert.That(esperado1,Is.EqualTo(maniqui.Dano));
        Assert.That(esperado2,Is.EqualTo(maniqui.Precision));
        Assert.That(esperado3,Is.EqualTo(maniqui.Tipo));
        Assert.That(esperado4,Is.EqualTo(maniqui.Efecto));
    }

    [Test]
    public void TestCausarEfecto()
    {
        maniqui.CausarEfecto(null,pokemon,null);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(pokemon.Paralizado));
    }
}