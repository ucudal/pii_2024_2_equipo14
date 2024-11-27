using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase ManiquiTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(Maniqui))]
public class ManiquiTests
{
    private Maniqui maniqui;
    private Entrenador entrenador;
    private Pokemon pokemon;
    private Pokemon pokemonAtacante;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        maniqui = new Maniqui();
        entrenador = new Entrenador("Jugador");
        pokemonAtacante=new Pokemon("Bulbasaur", "Planta", new Ataque("Florecer", 10, 70, "Planta"), new Maniqui());
        pokemon=new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
    }
    /// <summary>
    /// Este test comprueba que se instancie correctamente un Maniqui.
    /// </summary>
    [Test] 
    public void TestInstanciarManiqui() 
    {

        string esperado = "Maniquí";
        Assert.That(esperado, Is.EqualTo(maniqui.Nombre));
        int esperado2 = 0;
        Assert.That(esperado2, Is.EqualTo(maniqui.Dano));
        int esperado3 = 80;
        Assert.That(esperado3, Is.EqualTo(maniqui.Precision));
        string esperado4 = "Psíquico";
        Assert.That(esperado4, Is.EqualTo(maniqui.Tipo));
        string esperado5 = "Paralizar";
        Assert.That(esperado5,Is.EqualTo(maniqui.Efecto));
    }
    /// <summary>
    /// Este test comprueba que este ataque ocasione el efecto "Paralizar" correctamente.
    /// </summary>
    [Test]
    public void TestCausarEfecto()
    {
        maniqui.CausarEfecto(entrenador, pokemon);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(pokemon.Paralizado));
    }
}