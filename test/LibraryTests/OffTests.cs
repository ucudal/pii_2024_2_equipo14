using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase OffTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(Off))]
public class OffTests
{
    private Off off;
    private Entrenador entrenador;
    private Pokemon pokemon;
    private Pokemon pokemonAtacante;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp(){
        off = new Off();
        entrenador = new Entrenador("Jugador");
        pokemonAtacante=new Pokemon("Bulbasaur", "Planta", new Ataque("Florecer", 10, 70, "Planta"), new Off());
        pokemon=new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
    }
    /// <summary>
    /// Este test comprueba que se instancie correctamente un Off.
    /// </summary>
    [Test] 
    public void TestInstanciarOff() 
    {
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
    /// <summary>
    /// Este test comprueba que este ataque ocasione el efecto "Envenenar" correctamente.
    /// </summary>
    [Test]
    public void TestCausarEfecto()
    {
        off.CausarEfecto(entrenador, pokemon);
        bool esperado = true;
        int esperado1 = 66;
        Assert.That(esperado,Is.EqualTo(pokemon.Envenenado));
        Assert.That(pokemon.VidaTotal,Is.LessThanOrEqualTo(esperado1));
    }
}