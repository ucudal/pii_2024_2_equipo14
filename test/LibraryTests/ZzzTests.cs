using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Zzz))]
public class ZzzTests
{

    private Zzz zzz;
    private Entrenador entrenador;
    private Pokemon pokemon;
    private Pokemon pokemonAtacante;

    [SetUp]
    public void SetUp(){
        zzz = new Zzz();
        entrenador = new Entrenador("Jugador");
        pokemonAtacante=new Pokemon("Bulbasaur", "Planta", new Ataque("Florecer", 10, 70, "Planta"), new Zzz());
        pokemon=new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
    }
    [Test] 
    public void TestManiqui() {

        string esperado = "Zzz";
        Assert.That(esperado, Is.EqualTo(zzz.Nombre));
        int esperado2 = 0;
        Assert.That(esperado2, Is.EqualTo(zzz.Dano));
        int esperado3 = 50;
        Assert.That(esperado3, Is.EqualTo(zzz.Precision));
        string esperado4 = "Normal";
        Assert.That(esperado4, Is.EqualTo(zzz.Tipo));
        string esperado5 = "Dormir";
        Assert.That(esperado5,Is.EqualTo(zzz.Efecto));
    }

    [Test]
    public void TestCausarEfecto()
    {
        pokemonAtacante.AtaqueEspecial.CausarEfecto(entrenador, pokemon);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(pokemon.Dormido));
    }
}