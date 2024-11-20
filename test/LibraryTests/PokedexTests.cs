using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Pokedex))]
public class PokedexTests
{
    private Pokemon pokemon;
    private Ataque ataque;
    private AtaqueEspecial ataqueEspecial;
    [SetUp]
    public void SetUp()
    {
        pokemon = new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 70, "Eléctrico"), new Maniqui());
        ataque = pokemon.Ataque;
        ataqueEspecial = pokemon.AtaqueEspecial;
    }
    
    [Test]
    public void TestBuscarPokemon()
    {
        Pokemon clon = Pokedex.BuscarPokemon("Pikachu");
        Ataque ataqueClon = clon.Ataque;
        AtaqueEspecial ataqueEClon = clon.AtaqueEspecial;
        string esperado = pokemon.Nombre;
        string esperado1 = pokemon.Tipo;
        string esperado2 = ataque.Nombre;
        int esperado3 = ataque.Dano;
        int esperado4 = ataque.Precision;
        string esperado5 = ataque.Tipo;
        string esperado6 = ataqueEspecial.Nombre;
        int esperado7 = ataqueEspecial.Dano;
        int esperado8 = ataqueEspecial.Precision;
        string esperado9 = ataqueEspecial.Tipo;
        string esperado10 = ataqueEspecial.Efecto;
        Assert.That(esperado,Is.EqualTo(clon.Nombre));
        Assert.That(esperado1,Is.EqualTo(clon.Tipo));
        Assert.That(esperado2,Is.EqualTo(ataqueClon.Nombre));
        Assert.That(esperado3,Is.EqualTo(ataqueClon.Dano));
        Assert.That(esperado4,Is.EqualTo(ataqueClon.Precision));
        Assert.That(esperado5,Is.EqualTo(ataqueClon.Tipo));
        Assert.That(esperado6,Is.EqualTo(ataqueEClon.Nombre));
        Assert.That(esperado7,Is.EqualTo(ataqueEClon.Dano));
        Assert.That(esperado8,Is.EqualTo(ataqueEClon.Precision));
        Assert.That(esperado9,Is.EqualTo(ataqueEClon.Tipo));
        Assert.That(esperado10,Is.EqualTo(ataqueEClon.Efecto));
        
    }
}