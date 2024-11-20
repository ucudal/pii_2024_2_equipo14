using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase EntrenadorTests. Se encarga de comprobar que se logre instanciar correctamente un Entrenador.
/// </summary>
[TestFixture]
[TestOf(typeof(Entrenador))]
public class EntrenadorTests
{
    private Entrenador entrenador;
    private Pokemon pokemon;
    private Item item;
    
    [SetUp]
    public void SetUp()
    {
        entrenador = new Entrenador("Entrenador");
        pokemon = new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
        item = new CuraTotal();
    }

    [Test]
    public void TestCrearEntrenador()
    {
        string esperado = "Entrenador";
        Assert.That(esperado, Is.EqualTo(entrenador.Nombre));
    }

    [Test]
    public void TestAgregarPokemon()
    {
        entrenador.AgregarPokemon(pokemon);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(entrenador.miCatalogo.Contains(pokemon)));
    }

    [Test]
    public void TestQuitarPokemon()
    {
        entrenador.QuitarPokemon(pokemon);
        bool esperado = false;
        Assert.That(esperado,Is.EqualTo(entrenador.miCatalogo.Contains(pokemon)));
    }
    
    [Test]
    public void TestAgregarItem()
    {
        entrenador.AgregarItem(item);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(entrenador.misItems.Contains(item)));
    }

    [Test]
    public void TestQuitarItem()
    {
        entrenador.QuitarItem(item);
        bool esperado = false;
        Assert.That(esperado,Is.EqualTo(entrenador.misItems.Contains(item)));
    }

    [Test]
    public void TestAgregarMuerto()
    {
        entrenador.AgregarMuerto(pokemon);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(entrenador.misMuertos.Contains(pokemon)));
    }
    
    
    [Test]
    public void TestQuitarMuerto()
    {
        entrenador.QuitarMuerto(pokemon);
        bool esperado = false;
        Assert.That(esperado,Is.EqualTo(entrenador.misMuertos.Contains(pokemon)));
    }
    
    
    
    
}

    
