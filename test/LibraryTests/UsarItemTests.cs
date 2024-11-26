using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(UsarItem))]
public class UsarItemTests
{

    private Entrenador entrenador;
    private Item revivir;
    private Item superPocion;
    private Item curaTotal;
    private Pokemon pokemon;
    
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