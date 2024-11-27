using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase UsarItemTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(UsarItem))]
public class UsarItemTests
{

    private Entrenador entrenador;
    private Item revivir;
    private Item superPocion;
    private Item curaTotal;
    private Pokemon pokemon;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        entrenador = new Entrenador("Jugador");
        pokemon = new Pokemon("Mew", "Psíquico", new Ataque("Hipnosis", 30, 80, "Psíquico"), new Off());
        revivir = new Revivir();
        superPocion = new SuperPocion();
        curaTotal = new CuraTotal();
        entrenador.AgregarItem(revivir);
        entrenador.AgregarItem(superPocion);
        entrenador.AgregarItem(curaTotal);
    }
    /// <summary>
    /// Este test comprueba que se reviva a un Pokémon muerto con "Revivir".
    /// </summary>
    [Test]
    public void TestUsoDeRevivir()
    {
        pokemon.RecibirDano(80);
        entrenador.AgregarMuerto(pokemon);
        UsarItem.UsoDeItem(entrenador,revivir,pokemon);
        bool esperado = false;
        bool esperado1 = true;
        int esperado2 = 40;
        Assert.That(esperado,Is.EqualTo(entrenador.GetMisMuertos().Contains(pokemon)));
        Assert.That(esperado1,Is.EqualTo(entrenador.GetMiCatalogo().Contains(pokemon)));
        Assert.That(esperado,Is.EqualTo(entrenador.GetMisItems().Contains(revivir)));
        Assert.That(esperado2,Is.EqualTo(pokemon.VidaTotal));
    }
    /// <summary>
    /// Este test comprueba que se cure a un Pokémon con 70 puntos o los que necesite para el máximo con "SúperPoción".
    /// </summary>
    [Test]
    public void TestUsoDeSuperPocion()
    {
        pokemon.RecibirDano(80);
        UsarItem.UsoDeItem(entrenador,superPocion,pokemon);
        bool esperado = false;
        int esperado1 = 70;
        Assert.That(esperado,Is.EqualTo(entrenador.GetMisItems().Contains(superPocion)));
        Assert.That(esperado1,Is.EqualTo(pokemon.VidaTotal));
    }
    /// <summary>
    /// Este test comprueba que se cure de un efecto especial a un Pokémon con "CuraTotal".
    /// </summary>
    [Test]
    public void TestUsoDeCuraTotal()
    {
        pokemon.Quemado = true;
        UsarItem.UsoDeItem(entrenador,curaTotal,pokemon);
        bool esperado = false;
        Assert.That(esperado,Is.EqualTo(entrenador.GetMisItems().Contains(curaTotal)));
        Assert.That(esperado,Is.EqualTo(pokemon.Quemado));
    }
}