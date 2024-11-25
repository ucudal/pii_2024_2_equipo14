using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(CambiarPokemon))]
public class CambiarPokemonTests
{
    private Pokemon pokemonActual;
    private Pokemon pokemonCambiado;
    private Entrenador entrenador;
    
    [SetUp]
    public void SetUp()
    {
        pokemonActual = new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
       
        pokemonCambiado=new Pokemon("Bulbasaur", "Planta", new Ataque("Florecer", 10, 70, "Planta"), new Incendio());
        entrenador = new Entrenador("entrenador");
    }

    [Test]
    public void TestCambioDePokemon()
    {
        entrenador.PokemonActual = pokemonCambiado;
        string esperado="Bulbasaur";
        Assert.That(esperado,Is.EqualTo(entrenador.PokemonActual.Nombre));
       
    }
}