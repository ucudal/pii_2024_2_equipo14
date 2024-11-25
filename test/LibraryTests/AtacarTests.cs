using Library;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace LibraryTests; 

[TestFixture]
[TestOf(typeof(Atacar))]
public class AtacarTests
{
    private Entrenador atacante;
    private Entrenador victima;
    private Ataque ataque;
    private AtaqueEspecial ataqueEspecial;
    private  Pokemon pokemonActual; 
    private Pokemon pokemonAtacado; 
    
    [SetUp]
    public void SetUp()
    { 
        pokemonActual= new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
        pokemonAtacado=new Pokemon("Bulbasaur", "Planta", new Ataque("Florecer", 10, 70, "Planta"), new Incendio());
        ataque = pokemonActual.Ataque;
        ataqueEspecial = pokemonActual.AtaqueEspecial;
        atacante = new Entrenador("Atacante");
        victima = new Entrenador("Victima");
        atacante.PokemonActual = pokemonActual;
        victima.PokemonActual = pokemonAtacado;
    }

    [Test]
    public void TestEncuentro()
    {
        Atacar.Encuentro(atacante,ataque,victima);
        int esperado = 60;
        Assert.That(pokemonAtacado.VidaTotal,Is.LessThanOrEqualTo(esperado));
    }

}