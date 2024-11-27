using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase SuperPocionTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(SuperPocion))]
public class SuperPocionTests
{

    private Item superPocion;
    private Pokemon pokemon;
    private Entrenador entrenador;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        superPocion = new SuperPocion();
        pokemon = new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 20, "Eléctrico"), new Zzz());
        entrenador = new Entrenador("Entrenador");
        entrenador.AgregarItem(superPocion);
    }
    /// <summary>
    /// Este test comprueba que se instancie correctamente una SuperPocion.
    /// </summary>
    [Test]
    public void TestInstanciarSuperPocion()
    {
        string esperado = "SúperPoción";
        string esperado1 = "Recupera 70 puntos de vida";
        Assert.That(esperado,Is.EqualTo(superPocion.Nombre));
        Assert.That(esperado1,Is.EqualTo(superPocion.Descripcion));
    }
    /// <summary>
    /// Este test comprueba que este item cure 70 puntos o los que falten para tener el máximo al Pokémon deseado.
    /// </summary>
    [Test]
    public void TestRealizarAccion()
    {
        pokemon.RecibirDano(80);
        superPocion.Accion(entrenador,pokemon);
        int esperado = 70;
        bool esperado1 = false;
        Assert.That(esperado,Is.EqualTo(pokemon.VidaTotal));
        Assert.That(esperado1,Is.EqualTo(entrenador.GetMisItems().Contains(superPocion)));
    }
}