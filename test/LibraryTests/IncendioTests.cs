using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase IncendioTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(Incendio))]
public class IncendioTests
{
    private Incendio incendio;
    private Entrenador entrenador;
    private Pokemon pokemon;
    private Pokemon pokemonAtacante;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp(){
        incendio = new Incendio();
        entrenador = new Entrenador("Jugador");
        pokemonAtacante=new Pokemon("Bulbasaur", "Planta", new Ataque("Florecer", 10, 70, "Planta"), new Incendio());
        pokemon=new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
    }
    /// <summary>
    /// Este test comprueba que se instancie correctamente un Incendio.
    /// </summary>
    [Test] 
    public void TestInstanciarIncendio() 
    {

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
    /// <summary>
    /// Este test comprueba que este ataque ocasione el efecto "Quemar" correctamente.
    /// </summary>
    [Test]
    public void TestCausarEfecto()
    {
        incendio.CausarEfecto(entrenador, pokemon);
        bool esperado = true;
        int esperado1 = 62;
        Assert.That(esperado,Is.EqualTo(pokemon.Quemado));
        Assert.That(pokemon.VidaTotal,Is.LessThanOrEqualTo(esperado1));
    }
}