using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class DefensaTest
{
    private Entrenador entrenador;
    private Pokemon pokemon;
    private Item item;
   

    [SetUp]
    public void SetUp()
    {
        entrenador = new Entrenador("Defensa");
        pokemon = new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 20, "Eléctrico"), new Zzz());
        item = new Revivir();
    }

    [Test]
    public void TestAgregarRestriccionNombre()
    {
        //restriccion de nombre, fijarse si en la lista de pokedex sigue estando ese pokemon
        bool esperado = false;
        Facade.Instance.AgregarRestriccion(null,pokemon.Nombre,null,null);
        bool esperado1 = Pokedex.listaPokemons.Contains(pokemon);
        Assert.That(esperado1,Is.EqualTo(esperado));
        
    }

    [Test]
    public void TestAgregarRestriccionTipo()
    {
        //restriccion de tipo, fijarse si retorna que no se pueden elegir tipo fuego
        string esperado=Mensaje.AgregarRestriccion(null, null, "Fuego", null);
        string esperado1 = $"No se puede elegir pokemones de tipo Fuego";
        Assert.That(esperado, Is.EqualTo(esperado1));
    }

    [Test]
    public void TestAgregarRestriccionItem()
    {
        Mensaje.AgregarRestriccion(entrenador,null,null,"Revivir");
        bool esperado = entrenador.misItems.Contains(item);
        bool esperado1 = false;
        Assert.That(esperado1,Is.EqualTo(esperado));
    }
}