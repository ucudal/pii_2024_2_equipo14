using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase ZzzTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(Zzz))]
public class ZzzTests
{

    private Zzz zzz;
    private Entrenador entrenador;
    private Pokemon pokemon;
    private Pokemon pokemonAtacante;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        zzz = new Zzz();
        entrenador = new Entrenador("Jugador");
        pokemonAtacante=new Pokemon("Bulbasaur", "Planta", new Ataque("Florecer", 10, 70, "Planta"), new Zzz());
        pokemon=new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
    }
    /// <summary>
    /// Este test comprueba que se instancie correctamente un Zzz.
    /// </summary>
    [Test] 
    public void TestInstanciarZzz() 
    {

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
    /// <summary>
    /// Este test comprueba que este ataque ocasione el efecto "Dormir" correctamente.
    /// </summary>
    [Test]
    public void TestCausarEfecto()
    {
        zzz.CausarEfecto(entrenador, pokemon);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(pokemon.Dormido));
    }
}