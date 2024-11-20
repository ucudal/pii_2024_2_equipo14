using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Atacar))]
public class AtacarTests
{
    private Entrenador atacante;
    private Entrenador victima;
    private  Pokemon pokemonActual; 
    private Pokemon pokemonAtacado; 
    
    [SetUp]
    public void SetUp()
    { 
        pokemonActual= new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
        pokemonAtacado=new Pokemon("Bulbasaur", "Planta", new Ataque("Florecer", 10, 70, "Planta"), new Incendio());
        atacante = new Entrenador("Atacante");
        victima = new Entrenador("Victima");
    }
    
    [Test]
    public void TestEncuentro()
    { 
        Atacar.Encuentro(atacante,victima);
        int esperado = pokemonAtacado.VidaTotal;
        Assert.That(esperado, Is.LessThan(pokemonAtacado.VidaInicial));

        bool esperado1 = true;
        Assert.That(esperado1, Is.EqualTo(pokemonActual.Dormido));
        Assert.That(pokemonAtacado.VidaTotal, Is.LessThan(pokemonAtacado.VidaInicial));

        bool esperado2 = false;
        Assert.That(esperado2,Is.EqualTo(victima.miCatalogo.Contains(pokemonAtacado)));

    }
}