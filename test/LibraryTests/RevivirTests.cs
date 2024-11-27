using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase RevivirTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(Revivir))]
public class RevivirTests
{
    private Item revivir;
    private Pokemon pokemon;
    private Entrenador entrenador;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        revivir = new Revivir();
        pokemon = new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 20, "Eléctrico"), new Zzz());
        entrenador = new Entrenador("Entrenador");
        entrenador.AgregarItem(revivir);
    }
    /// <summary>
    /// Este test comprueba que se instancie correctamente un Revivir.
    /// </summary>
    [Test]
    public void TestInstanciarRevivir()
    {
        string esperado = "Revivir";
        string esperado1 = "Revive a un Pokémon con el 50% de su vida total";
        Assert.That(esperado,Is.EqualTo(revivir.Nombre));
        Assert.That(esperado1,Is.EqualTo(revivir.Descripcion));
    }
    /// <summary>
    /// Este test comprueba que este item reviva al Pokémon deseado.
    /// </summary>
    [Test]
    public void TestRealizarAccion()
    {
        pokemon.RecibirDano(80);
        entrenador.AgregarMuerto(pokemon);
        revivir.Accion(entrenador,pokemon);
        int esperado = 40;
        bool esperado1 = false;
        bool esperado2 = true;
        Assert.That(esperado,Is.EqualTo(pokemon.VidaTotal));
        Assert.That(esperado1,Is.EqualTo(entrenador.GetMisMuertos().Contains(pokemon)));
        Assert.That(esperado2,Is.EqualTo(entrenador.GetMiCatalogo().Contains(pokemon)));
        Assert.That(esperado1,Is.EqualTo(entrenador.GetMisItems().Contains(revivir)));
    }
}