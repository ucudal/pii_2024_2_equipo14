using Library;
using NUnit.Framework;

namespace LibraryTests; //Este test está mal

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
    }

    [Test]
    public void TestEncuentro()
    {
        int dano = Efectividad.CalcularEfectividad(ataque, pokemonAtacado);
        pokemonAtacado.RecibirDano(dano);
        int esperado = pokemonAtacado.VidaTotal;
        Assert.That(pokemonAtacado.VidaInicial, Is.GreaterThan(esperado)); //recibir daño

        int esperado2 = ataqueEspecial.CalcularPrecision();
        if (esperado2 == 0)
        {
            int esperado3 = 0;
            Assert.That(esperado3, Is.LessThan(pokemonAtacado.TurnosDormido)); //si esta dormido
        }

        if (pokemonAtacado.VidaTotal == 0)
        {
            bool esperado4 = false;
            Assert.That(esperado4,Is.EqualTo(victima.misMuertos.Contains(pokemonAtacado))); //si se va a los muertos
            Assert.That(esperado4,Is.EqualTo(victima.miCatalogo.Contains(pokemonActual))); //si esta en el catalogo
        }

    }

}