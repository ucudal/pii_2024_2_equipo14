using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(AtaqueEspecial))]
public class AtaqueEspecialTests
{
    private AtaqueEspecial ataqueEspecial;
    private Pokemon pokemon;
    private Entrenador entrenador;

    [SetUp]
    public void SetUp()
    {
        ataqueEspecial = new Incendio();
        entrenador = new Entrenador("Jugador");
        pokemon=new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
    }
    [Test] 
    public void TestAtaqueEspecial() {

        string esperado = "Incendio";
        Assert.That(esperado, Is.EqualTo(ataqueEspecial.Nombre));
        int esperado2 = 10;
        Assert.That(esperado2, Is.EqualTo(ataqueEspecial.Dano));
        int esperado3 = 70;
        Assert.That(esperado3, Is.EqualTo(ataqueEspecial.Precision));
        string esperado4 = "Fuego";
        Assert.That(esperado4, Is.EqualTo(ataqueEspecial.Tipo));
        string esperado5 = "Quemar";
        Assert.That(esperado5,Is.EqualTo(ataqueEspecial.Efecto));
    } 
    
    [Test]
    public void CausarEfecto()
    {
        string esperado ="Dormir";
        Assert.That(esperado,Is.EqualTo(pokemon.AtaqueEspecial.Efecto));

    }
}