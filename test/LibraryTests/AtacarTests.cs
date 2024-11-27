using Library;
using NUnit.Framework;

namespace LibraryTests; 
/// <summary>
/// Esta es la clase AtacarTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
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
    
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
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
    /// <summary>
    /// Este test comprueba que se efectúe correctamente un ataque.
    /// </summary>
    [Test]
    public void TestEncuentro()
    {
        Atacar.Encuentro(atacante,ataque,victima);
        int esperado = 60;
        Assert.That(pokemonAtacado.VidaTotal,Is.LessThanOrEqualTo(esperado));
    }

}