using Library;
using NUnit.Framework;
namespace LibraryTests;
/// <summary>
/// Esta es la clase PokemonTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(Pokemon))]
public class PokemonTests
{

    private Pokemon pokemon;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        pokemon = new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
    }
    /// <summary>
    /// Este test comprueba que se cree correctamente un Pokémon.
    /// </summary>
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
    /// <summary>
    /// Este test comprueba que se reciba daño correctamente.
    /// </summary>
    [Test]
    public void TestRecibirDano()
    {
        pokemon.RecibirDano(30);
        int esperado = 50;
        Assert.That(esperado,Is.EqualTo(pokemon.VidaTotal));
    }
    /// <summary>
    /// Este test comprueba que se cure determinados puntos de vida correctamente.
    /// </summary>
    [Test]
    public void TestCurar()
    {
        pokemon.RecibirDano(30);
        pokemon.Curar(10);
        int esperado = 60;
        Assert.That(esperado,Is.EqualTo(pokemon.VidaTotal));
    }
    /// <summary>
    /// Este test comprueba que se obtenga correctamente los ataques del Pokémon.
    /// </summary>
    [Test]
    public void TestGetAtaques()
    {
        Ataque ataque = pokemon.Ataque;
        Ataque ataqueEspecial = pokemon.AtaqueEspecial;
        List<Ataque> resultado = pokemon.GetAtaques();
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado.Contains(ataque)));
        Assert.That(esperado,Is.EqualTo(resultado.Contains(ataqueEspecial)));
    }
}