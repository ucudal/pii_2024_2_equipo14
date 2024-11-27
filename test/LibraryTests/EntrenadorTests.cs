using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase EntrenadorTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(Entrenador))]
public class EntrenadorTests
{
    private Entrenador entrenador;
    private Pokemon pokemon;
    private Item item;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        entrenador = new Entrenador("Entrenador");
        pokemon = new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
        item = new CuraTotal();
    }
    /// <summary>
    /// Este test comprueba que se cree correctamente un Entrenador.
    /// </summary>
    [Test]
    public void TestCrearEntrenador()
    {
        string esperado = "Entrenador";
        Assert.That(esperado, Is.EqualTo(entrenador.Nombre));
    }
    /// <summary>
    /// Este test comprueba que se agregue correctamente un Pokémon al catálogo.
    /// </summary>
    [Test]
    public void TestAgregarPokemon()
    {
        entrenador.AgregarPokemon(pokemon);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(entrenador.GetMiCatalogo().Contains(pokemon)));
    }
    /// <summary>
    /// Este test comprueba que se quite correctamente un Pokémon del catálogo.
    /// </summary>
    [Test]
    public void TestQuitarPokemon()
    {
        entrenador.QuitarPokemon(pokemon);
        bool esperado = false;
        Assert.That(esperado,Is.EqualTo(entrenador.GetMiCatalogo().Contains(pokemon)));
    }
    /// <summary>
    /// Este test comprueba que se agregue correctamente un item al catálogo.
    /// </summary>
    [Test]
    public void TestAgregarItem()
    {
        entrenador.AgregarItem(item);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(entrenador.GetMisItems().Contains(item)));
    }
    /// <summary>
    /// Este test comprueba que se quite correctamente un item del catálogo.
    /// </summary>
    [Test]
    public void TestQuitarItem()
    {
        entrenador.QuitarItem(item);
        bool esperado = false;
        Assert.That(esperado,Is.EqualTo(entrenador.GetMisItems().Contains(item)));
    }
    /// <summary>
    /// Este test comprueba que se agregue correctamente un muerto al catálogo.
    /// </summary>
    [Test]
    public void TestAgregarMuerto()
    {
        entrenador.AgregarMuerto(pokemon);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(entrenador.GetMisMuertos().Contains(pokemon)));
    }
    /// <summary>
    /// Este test comprueba que se quite correctamente un muerto del catálogo.
    /// </summary>
    [Test]
    public void TestQuitarMuerto()
    {
        entrenador.QuitarMuerto(pokemon);
        bool esperado = false;
        Assert.That(esperado,Is.EqualTo(entrenador.GetMisMuertos().Contains(pokemon)));
    }
}

    