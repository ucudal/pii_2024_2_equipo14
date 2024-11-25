using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Library.Item))]
public class ItemTests
{
    private Pokemon pokemon;
    private Entrenador entrenador;
    private Revivir revivir;
    private CuraTotal curaTotal;
    private SuperPocion superPocion;

[SetUp]
public void SetUp()
{
    pokemon = new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 20, "Eléctrico"), new Zzz());
    entrenador= new Entrenador("jugador1");
    revivir = new Revivir();
    curaTotal = new CuraTotal();
    superPocion = new SuperPocion();
    entrenador.AgregarItem(revivir);
    entrenador.AgregarItem(curaTotal);
    entrenador.AgregarItem(superPocion);
}
    [Test]
    public void TestAccion()
    {
        bool esperado = true;
        bool esperado1 = false;
        
        revivir.Accion(entrenador, pokemon);
        Assert.That(esperado,Is.EqualTo(entrenador.miCatalogo.Contains(pokemon)));
        Assert.That(esperado1,Is.EqualTo(entrenador.misItems.Contains(revivir)));
        
        curaTotal.Accion(entrenador, pokemon);
        Assert.That(esperado1,Is.EqualTo(entrenador.misItems.Contains(curaTotal)));
        
        superPocion.Accion(entrenador, pokemon);
        Assert.That(esperado1,Is.EqualTo(pokemon.Quemado));
        Assert.That(esperado1, Is.EqualTo(entrenador.misItems.Contains(superPocion)));

    }
}