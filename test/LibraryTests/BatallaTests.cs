using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// Esta es la clase BatallaTests. Se encarga de comprobar que se logre instanciar correctamente una Batalla.
/// </summary>
[TestFixture]
[TestOf(typeof(Batalla))]
public class BatallaTests
{
    private Entrenador jugador1;
    private Pokemon pokemon;
    private Entrenador jugador2;
    private Batalla batalla;
    
    [SetUp]
    public void SetUp()
    {
        jugador1 = new Entrenador("Jugador1");
        pokemon=new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
        jugador2 = new Entrenador("Jugador2");
        batalla = new Batalla(jugador1,jugador2);
        jugador1.PokemonActual = pokemon;
    }

    [Test]
    public void TestCrearBatalla()
    {
        Entrenador esperado1 = jugador1;
        Assert.That(esperado1,Is.EqualTo(batalla.Jugador1));
        
        Entrenador esperado2 = jugador2;
        Assert.That(esperado2,Is.EqualTo(batalla.Jugador2));
        
        int esperado3 = 7;
        Assert.That(esperado3,Is.EqualTo(jugador1.misItems.Count));
        Assert.That(esperado3,Is.EqualTo(jugador2.misItems.Count));

        string esperado4 = "Pikachu";
        Assert.That(esperado4,Is.EqualTo(jugador1.PokemonActual.Nombre));
        
        
    }
    }
