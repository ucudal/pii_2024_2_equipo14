using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(SuperPocion))]
public class SuperPocionTests
{

    private Item superPocion;
    private Pokemon pokemon;
    private Entrenador entrenador;
    
    [SetUp]
    public void SetUp()
    {
        superPocion = new SuperPocion();
        pokemon = new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 20, "Eléctrico"), new Zzz());
        entrenador = new Entrenador("Entrenador");
        entrenador.AgregarItem(superPocion);
    }
    
    [Test]
    public void TestInstanciarRevivir()
    {
        string esperado = "SúperPoción";
        string esperado1 = "Recupera 70 puntos de vida";
        Assert.That(esperado,Is.EqualTo(superPocion.Nombre));
        Assert.That(esperado1,Is.EqualTo(superPocion.Descripcion));
    }

    [Test]
    public void TestRealizarAccion()
    {
        pokemon.RecibirDano(80);
        superPocion.Accion(entrenador,pokemon);
        int esperado = 70;
        bool esperado1 = false;
        Assert.That(esperado,Is.EqualTo(pokemon.VidaTotal));
        Assert.That(esperado1,Is.EqualTo(entrenador.misItems.Contains(superPocion)));
    }
}