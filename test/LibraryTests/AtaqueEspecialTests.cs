using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase AtaqueEspecialTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(AtaqueEspecial))]
public class AtaqueEspecialTests
{
    private AtaqueEspecial ataqueEspecial;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        ataqueEspecial = new Incendio();
    }
    /// <summary>
    /// Este test comprueba que se cree correctamente un Ataque Especial.
    /// </summary>
    [Test] 
    public void TestCrearAtaqueEspecial() 
    {
        string esperado = "Incendio";
        Assert.That(esperado, Is.EqualTo(ataqueEspecial.Nombre));
        int esperado2 = 10;
        Assert.That(esperado2, Is.EqualTo(ataqueEspecial.Dano));
        int esperado3 = 70;
        Assert.That(esperado3, Is.EqualTo(ataqueEspecial.Precision));
        string esperado4 = "Fuego";
        Assert.That(esperado4, Is.EqualTo(ataqueEspecial.Tipo));
        string esperado5 = "Quemar";
        Assert.That(esperado5,Is.EqualTo(ataqueEspecial.Efecto));
    } 
}