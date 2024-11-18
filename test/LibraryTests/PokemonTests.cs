using Library;
using NUnit.Framework;

namespace LibraryTests.Otros;

[TestFixture]
[TestOf(typeof(Pokemon))]
public class PokemonTests
{
    
    private Pokemon pokemon;
    
    [SetUp]
    public void SetUp()
    {
        pokemon = new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
    }

    [Test]
    public void TestCrearPokemon()
    {
        string esperado = "Pikachu";
        string esperado1 = "Eléctrico";
        string esperado2 = "Rayo";
        string esperado3 = "Zzz";
        Assert.That(esperado, Is.EqualTo(pokemon.Nombre));
        Assert.That(esperado1, Is.EqualTo(pokemon.Tipo));
        Assert.That(esperado2, Is.EqualTo(pokemon.Ataque.Nombre));
        Assert.That(esperado3, Is.EqualTo(pokemon.AtaqueEspecial.Nombre));
    }

    [Test]
    public void TestRecibirDano()
    {
        pokemon.RecibirDano(30);
        int esperado = 50;
        Assert.That(esperado,Is.EqualTo(pokemon.VidaTotal));
    }
    
    [Test]
    public void TestCurar()
    {
        pokemon.RecibirDano(30);
        pokemon.Curar(10);
        int esperado = 60;
        Assert.That(esperado,Is.EqualTo(pokemon.VidaTotal));
    }
}