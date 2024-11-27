using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase CuraTotalTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(CuraTotal))]
public class CuraTotalTests
{
    private Item curaTotal;
    private Pokemon pokemon;
    private Entrenador entrenador;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        curaTotal = new CuraTotal();
        pokemon = new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 20, "Eléctrico"), new Zzz());
        entrenador = new Entrenador("Entrenador");
        entrenador.AgregarPokemon(pokemon);
        entrenador.AgregarItem(curaTotal);
    }
    /// <summary>
    /// Este test comprueba que se instancie correctamente una CuraTotal.
    /// </summary>
    [Test]
    public void TestInstanciarCuraTotal()
    {
        string esperado = "CuraTotal";
        string esperado1 = "Cura a un Pokémon de efectos de ataques especiales";
        Assert.That(esperado,Is.EqualTo(curaTotal.Nombre));
        Assert.That(esperado1,Is.EqualTo(curaTotal.Descripcion));
    }
    /// <summary>
    /// Este test comprueba que este item cure del efecto dormido al Pokémon deseado.
    /// </summary>
    [Test]
    public void TestRealizarAccion1()
    {
        pokemon.Dormido = true;
        curaTotal.Accion(entrenador, pokemon);
        bool esperado = false;
        Assert.That(esperado,Is.EqualTo(pokemon.Dormido));
        Assert.That(esperado,Is.EqualTo(entrenador.GetMisItems().Contains(curaTotal)));
    }
    /// <summary>
    /// Este test comprueba que este item cure del efecto paralizado al Pokémon deseado.
    /// </summary>
    [Test]
    public void TestRealizarAccion2()
    {
        pokemon.Paralizado = true;
        curaTotal.Accion(entrenador, pokemon);
        bool esperado = false;
        Assert.That(esperado,Is.EqualTo(pokemon.Paralizado));
        Assert.That(esperado,Is.EqualTo(entrenador.GetMisItems().Contains(curaTotal)));
    }
    /// <summary>
    /// Este test comprueba que este item cure del efecto envenenado al Pokémon deseado.
    /// </summary>
    [Test]
    public void TestRealizarAccion3()
    {
        pokemon.Envenenado = true;
        curaTotal.Accion(entrenador, pokemon);
        bool esperado = false;
        Assert.That(esperado,Is.EqualTo(pokemon.Envenenado));
        Assert.That(esperado,Is.EqualTo(entrenador.GetMisItems().Contains(curaTotal)));
    }
    /// <summary>
    /// Este test comprueba que este item cure del efecto quemado al Pokémon deseado.
    /// </summary>
    [Test]
    public void TestRealizarAccion4()
    {
        pokemon.Quemado = true;
        curaTotal.Accion(entrenador, pokemon);
        bool esperado = false;
        Assert.That(esperado,Is.EqualTo(pokemon.Quemado));
        Assert.That(esperado,Is.EqualTo(entrenador.GetMisItems().Contains(curaTotal)));
    }
}