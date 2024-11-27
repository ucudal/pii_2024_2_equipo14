using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase AtaqueTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(Ataque))]
public class AtaqueTests
{
    private Ataque ataque;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        ataque = new Ataque("Florecer", 10, 70, "Planta");
    }
    /// <summary>
    /// Este test comprueba que se cree correctamente un Ataque.
    /// </summary>
    [Test] 
    public void TestCrearAtaque() 
    {
        
        string esperado = "Florecer";
        Assert.That(esperado, Is.EqualTo(ataque.Nombre));
        int esperado2 = 10;
        Assert.That(esperado2, Is.EqualTo(ataque.Dano));
        int esperado3 = 70;
        Assert.That(esperado3, Is.EqualTo(ataque.Precision));
        string esperado4 = "Planta";
        Assert.That(esperado4, Is.EqualTo(ataque.Tipo));
    } 
    /// <summary>
    /// Este test comprueba que se calcule correctamente la precisión de manera aleatoria.
    /// </summary>
    [Test]
    public void TestCalcularPrecision()
    {
        int preciso = ataque.CalcularPrecision();
        Assert.That(preciso,Is.LessThanOrEqualTo(1));
    }
}