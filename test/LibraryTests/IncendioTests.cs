using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Incendio))]
public class IncendioTests
{
    private Incendio incendio;
    private Entrenador entrenador;
    private Pokemon pokemon;
    private Pokemon pokemonAtacante;

    [SetUp]
    public void SetUp(){
    incendio = new Incendio();
    entrenador = new Entrenador("Jugador");
    pokemonAtacante=new Pokemon("Bulbasaur", "Planta", new Ataque("Florecer", 10, 70, "Planta"), new Incendio());
    pokemon=new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
}
[Test] 
public void TestManiqui() {

    string esperado = "Incendio";
    Assert.That(esperado, Is.EqualTo(incendio.Nombre));
    int esperado2 = 10;
    Assert.That(esperado2, Is.EqualTo(incendio.Dano));
    int esperado3 = 70;
    Assert.That(esperado3, Is.EqualTo(incendio.Precision));
    string esperado4 = "Fuego";
    Assert.That(esperado4, Is.EqualTo(incendio.Tipo));
    string esperado5 = "Quemar";
    Assert.That(esperado5,Is.EqualTo(incendio.Efecto));
}

[Test]
public void TestCausarEfecto()
{
    pokemonAtacante.AtaqueEspecial.CausarEfecto(entrenador, pokemon);
    bool esperado = true;
    Assert.That(esperado,Is.EqualTo(pokemon.Quemado));
}
}

