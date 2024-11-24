using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Off))]
public class OffTests
{

    private Off off;
    private Entrenador entrenador;
    private Pokemon pokemon;
    private Pokemon pokemonAtacante;

    [SetUp]
    public void SetUp(){
        off = new Off();
        entrenador = new Entrenador("Jugador");
        pokemonAtacante=new Pokemon("Bulbasaur", "Planta", new Ataque("Florecer", 10, 70, "Planta"), new Off());
        pokemon=new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
    }
    [Test] 
    public void TestManiqui() {

        string esperado = "Off";
        Assert.That(esperado, Is.EqualTo(off.Nombre));
        int esperado2 = 10;
        Assert.That(esperado2, Is.EqualTo(off.Dano));
        int esperado3 = 90;
        Assert.That(esperado3, Is.EqualTo(off.Precision));
        string esperado4 = "Veneno";
        Assert.That(esperado4, Is.EqualTo(off.Tipo));
        string esperado5 = "Envenenar";
        Assert.That(esperado5,Is.EqualTo(off.Efecto));
    }

    [Test]
    public void TestCausarEfecto()
    {
        pokemonAtacante.AtaqueEspecial.CausarEfecto(entrenador, pokemon);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(pokemon.Envenenado));
    }
}