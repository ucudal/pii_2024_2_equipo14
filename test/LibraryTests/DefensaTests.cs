using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class DefensaTest
{
    private Entrenador entrenador;
    private Pokemon pokemon;
    private Item item;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear el método AgregarRestriccion.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        entrenador = new Entrenador("Defensa");
        pokemon = new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 20, "Eléctrico"), new Zzz());
        entrenador.AgregarItem(new Revivir());
    }

    
    /// <summary>
    /// Este test verifica que se realice la restriccion de nombre, se fija si en la lista de pokedex sigue estando
    /// así a la hora de mostrar los pokemones disponibles directamente no lo muestra, no se puede elegir.
    /// </summary>
    [Test]
    public void TestAgregarRestriccionNombre()
    {
        bool esperado = false;
        Facade.Instance.AgregarRestriccion(null,pokemon.Nombre,null,null);
        bool esperado1 = Pokedex.listaPokemons.Contains(pokemon);
        Assert.That(esperado1,Is.EqualTo(esperado));
        
    }

    
    
    /// <summary>
    /// Este test verifica que se realice la restriccion del tipo del pokemon, se fija si se retorna el mensaje de Mensaje
    /// para ver si se realizó correctamente el método
    /// </summary>
    [Test]
    public void TestAgregarRestriccionTipo()
    {
        string esperado=Mensaje.AgregarRestriccion(null, null, "Fuego", null);
        string esperado1 = $"No se puede elegir pokemones de tipo Fuego";
        Assert.That(esperado, Is.EqualTo(esperado1));
    }
    
    
    /// <summary>
    /// Este test verifica que se realice la restriccion del item, se fija si luego de hacer la restricción el item sigue disponible en el catalogo de
    /// items del entrenador, así nunca le va a salir en pantalla y de esa forma no va a poder utilizarlo.
    /// </summary>
    [Test]
    public void TestAgregarRestriccionItem()
    {
        Mensaje.AgregarRestriccion(entrenador,null,null,"Revivir");
        bool esperado1 = false;
        Assert.That(esperado1,Is.EqualTo(entrenador.misItems.Contains(item)));
    }
}