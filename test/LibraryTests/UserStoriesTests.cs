using System.ComponentModel.Design.Serialization;
using Library;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace LibraryTests;
/// <summary>
/// Esta es la clase UserStoriesTests. Se encarga de comprobar las historias de usuario.
/// </summary>
[TestFixture]

public class UserStoriesTests
{
    private Facade facade;
    private Batalla batalla;
    private Entrenador jugador1;
    private Entrenador jugador2;
    /// <summary>
    /// En este OneTimeSetUp instanciamos objetos que necesitaremos para testear.
    /// </summary>
    [OneTimeSetUp]
    public void SetUp()
    {
        Facade.Reset();
        facade = Facade.Instance;
        facade.AgregarJugadorListaDeEspera("j1");
        facade.AgregarJugadorListaDeEspera("j2");
        facade.ComenzarBatalla("j1", "j2");
        batalla = facade.EncontrarBatallaPorUsuario("j1");
        jugador1 = batalla.Jugador1;
        jugador2 = batalla.Jugador2;
        facade.AgregarPokemon(jugador1, "Pikachu");
        facade.AgregarPokemon(jugador1, "Bulbasaur");
        facade.AgregarPokemon(jugador1, "Mew");
        facade.AgregarPokemon(jugador1, "Ponyta");
        facade.AgregarPokemon(jugador1, "Squirtle");
        facade.AgregarPokemon(jugador1, "Charmander");
        facade.AgregarPokemon(jugador2, "Dratini");
        facade.AgregarPokemon(jugador2, "Pikachu");
        facade.AgregarPokemon(jugador2, "Goomy");
        facade.AgregarPokemon(jugador2, "Cranidos");
        facade.AgregarPokemon(jugador2, "Vullaby");
        facade.AgregarPokemon(jugador2, "Vanillite");
        batalla.EnBatalla = true;
        jugador1.PokemonActual = jugador1.GetMiCatalogo().First(p => p.Nombre == "Pikachu");
        jugador2.PokemonActual = jugador2.GetMiCatalogo().First(p => p.Nombre == "Dratini");
    }

    /// <summary>
    /// Este test comprueba la historia de usuario 1.
    /// </summary>
    [Test]
    public void TestUserStory1()
    {

        int esperado = 6;
        string resultado1 = facade.AgregarPokemon(jugador1,"Pikachu").Substring(25,34);
        string resultado2 = facade.AgregarPokemon(jugador2,"Pikachu").Substring(25,34);
        string esperado1 = "\n\r\nCATÁLOGO DE j1:\r\n \t - ¨Pikachu¨";
        string esperado2 = "\n\r\nCATÁLOGO DE j2:\r\n \t - ¨Dratini¨";
        Assert.That(esperado,Is.EqualTo(jugador1.GetMiCatalogo().Count));
        Assert.That(esperado,Is.EqualTo(jugador2.GetMiCatalogo().Count));
        Assert.That(esperado1,Is.EqualTo(resultado1));
        Assert.That(esperado2,Is.EqualTo(resultado2));
    }
    /// <summary>
    /// Este test comprueba la historia de usuario 2.
    /// </summary>
    [Test]
    public void TestUserStory2()
    {
        string resultado = facade.MostrarAtaques(jugador1.PokemonActual, false);
        string esperado = "\n\r\nATAQUES DISPONIBLES DE Pikachu:\r\n \t - ¨Rayo¨ | Tipo: Eléctrico " +
                          "| Daño: 40 | Precisión: 70\r\n";
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba la historia de usuario 3.
    /// </summary>
    [Test]
    public void TestUserStory3()
    {
        Pokemon actual = jugador1.PokemonActual;
        string resultado = facade.Atacar(jugador1, actual.GetAtaque(), jugador2);
        string esperado1 = "\n\r\nATAQUE DE j1:\r\n \t - Pikachu ha atacado a Dratini de j2";
        string esperado2 = "\n\r\nCATÁLOGO DE j1:\r\n \t - ¨Pikachu¨ | Tipo: Eléctrico | Vida: 80/80";
        string esperado3 = "\n\r\nCATÁLOGO DE j2:\r\n \t - ¨Dratini¨ | Tipo: Dragón | Vida: 60/80";
        Assert.That(esperado1,Is.EqualTo(resultado.Substring(0,57)));
        Assert.That(esperado2,Is.EqualTo(resultado.Substring(93,66)));
        Assert.That(esperado3,Is.EqualTo(resultado.Substring(407,63)));
    }
    /// <summary>
    /// Este test comprueba la historia de usuario 4.
    /// </summary>
    [Test]
    public void TestUserStory4()
    {
        Pokemon actual = jugador1.PokemonActual;
        Pokemon atacado = jugador2.PokemonActual;
        int esperado = atacado.VidaTotal - Efectividad.CalcularEfectividad(actual.Ataque, atacado);
        facade.Atacar(jugador1, actual.GetAtaque(), jugador2);
        int resultado = atacado.VidaTotal;
        Assert.That(esperado,Is.LessThanOrEqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba la historia de usuario 5.
    /// </summary>
    [Test]
    public void TestUserStory5()
    {
        Facade facade2 = Facade.Instance;
        facade2.AgregarJugadorListaDeEspera("e1");
        facade2.AgregarJugadorListaDeEspera("e2");
        facade2.ComenzarBatalla("e1", "e2");
        Batalla battle2 = facade.EncontrarBatallaPorUsuario("e1");
        Entrenador e1 = battle2.Jugador1;
        Entrenador e2 = battle2.Jugador2;
        facade.AgregarPokemon(e1, "Pikachu");
        facade.AgregarPokemon(e1, "Bulbasaur");
        facade.AgregarPokemon(e1, "Mew");
        facade.AgregarPokemon(e1, "Ponyta");
        facade.AgregarPokemon(e1, "Squirtle");
        facade.AgregarPokemon(e1, "Charmander");
        facade.AgregarPokemon(e2, "Dratini");
        facade.AgregarPokemon(e2, "Pikachu");
        facade.AgregarPokemon(e2, "Goomy");
        facade.AgregarPokemon(e2, "Cranidos");
        facade.AgregarPokemon(e2, "Vullaby");
        facade.AgregarPokemon(e2, "Vanillite");
        battle2.EnBatalla = true;
        e1.PokemonActual = e1.GetMiCatalogo().First(p => p.Nombre == "Pikachu");
        e2.PokemonActual = e2.GetMiCatalogo().First(p => p.Nombre == "Dratini");
        string resultado = facade2.CambiarPokemon(e1,"Charmander",jugador2);
        string esperado = "TURNO DE e2";
        Console.WriteLine(resultado);
        Assert.That(true,Is.EqualTo(resultado.Contains(esperado)));
        
    }
    /// <summary>
    /// Este test comprueba la historia de usuario 6.
    /// </summary>
    [Test]
    public void TestUserStory6()
    {
        Pokemon j1 = jugador1.PokemonActual;
        Pokemon j2 = jugador2.PokemonActual;
        jugador1.GetMiCatalogo()[1].RecibirDano(80);
        jugador1.AgregarMuerto(jugador1.GetMiCatalogo()[1]);
        jugador1.QuitarPokemon(jugador1.GetMiCatalogo()[1]);
        jugador1.GetMiCatalogo()[1].RecibirDano(80);
        jugador1.AgregarMuerto(jugador1.GetMiCatalogo()[1]);
        jugador1.QuitarPokemon(jugador1.GetMiCatalogo()[1]);
        jugador1.GetMiCatalogo()[1].RecibirDano(80);
        jugador1.AgregarMuerto(jugador1.GetMiCatalogo()[1]);
        jugador1.QuitarPokemon(jugador1.GetMiCatalogo()[1]);
        jugador1.GetMiCatalogo()[1].RecibirDano(80);
        jugador1.AgregarMuerto(jugador1.GetMiCatalogo()[1]);
        jugador1.QuitarPokemon(jugador1.GetMiCatalogo()[1]);
        jugador1.GetMiCatalogo()[1].RecibirDano(80);
        jugador1.AgregarMuerto(jugador1.GetMiCatalogo()[1]);
        jugador1.QuitarPokemon(jugador1.GetMiCatalogo()[1]);
        jugador2.GetMiCatalogo()[1].RecibirDano(80);
        jugador2.AgregarMuerto(jugador2.GetMiCatalogo()[1]);
        jugador2.QuitarPokemon(jugador2.GetMiCatalogo()[1]);
        jugador2.GetMiCatalogo()[1].RecibirDano(80);
        jugador2.AgregarMuerto(jugador2.GetMiCatalogo()[1]);
        jugador2.QuitarPokemon(jugador2.GetMiCatalogo()[1]);
        jugador2.GetMiCatalogo()[1].RecibirDano(80); 
        jugador2.AgregarMuerto(jugador2.GetMiCatalogo()[1]);
        jugador2.QuitarPokemon(jugador2.GetMiCatalogo()[1]);
        jugador2.GetMiCatalogo()[1].RecibirDano(80);
        jugador2.AgregarMuerto(jugador2.GetMiCatalogo()[1]);
        jugador2.QuitarPokemon(jugador2.GetMiCatalogo()[1]);
        jugador2.GetMiCatalogo()[1].RecibirDano(80);
        jugador2.AgregarMuerto(jugador2.GetMiCatalogo()[1]);
        jugador2.QuitarPokemon(jugador2.GetMiCatalogo()[1]);
        

        facade.Atacar(jugador1, j1.GetAtaque(), jugador2);
        facade.Atacar(jugador2, j2.GetAtaque(), jugador1);
        facade.Atacar(jugador1, j1.GetAtaque(), jugador2);
        facade.Atacar(jugador2, j2.GetAtaque(), jugador1);
        facade.Atacar(jugador1, j1.GetAtaque(), jugador2);
        string resultado = facade.Atacar(jugador2, j2.GetAtaque(), jugador1).Substring(749,50);
        string esperado = "\n\r\nFIN DE LA BATALLA:\r\n \t - j2 le ha ganado a j1\r\n";
        Assert.That(resultado, Is.EqualTo(esperado));
    }
    /// <summary>
    /// Este test comprueba la historia de usuario 7.
    /// </summary>
    [Test]
    public void TestUserStory7()
    {
        Facade facade2 = Facade.Instance;
        facade2.AgregarJugadorListaDeEspera("e1");
        facade2.AgregarJugadorListaDeEspera("e2");
        facade2.ComenzarBatalla("e1", "e2");
        Batalla battle2 = facade.EncontrarBatallaPorUsuario("e1");
        Entrenador e1 = battle2.Jugador1;
        Entrenador e2 = battle2.Jugador2;
        facade.AgregarPokemon(e1, "Pikachu");
        facade.AgregarPokemon(e1, "Bulbasaur");
        facade.AgregarPokemon(e1, "Mew");
        facade.AgregarPokemon(e1, "Ponyta");
        facade.AgregarPokemon(e1, "Squirtle");
        facade.AgregarPokemon(e1, "Charmander");
        facade.AgregarPokemon(e2, "Dratini");
        facade.AgregarPokemon(e2, "Pikachu");
        facade.AgregarPokemon(e2, "Goomy");
        facade.AgregarPokemon(e2, "Cranidos");
        facade.AgregarPokemon(e2, "Vullaby");
        facade.AgregarPokemon(e2, "Vanillite");
        battle2.EnBatalla = true;
        e1.PokemonActual = e1.GetMiCatalogo().First(p => p.Nombre == "Pikachu");
        e2.PokemonActual = e2.GetMiCatalogo().First(p => p.Nombre == "Dratini");
        int esperado1 = e1.Turnos + 1;
        bool esperado2 = !e1.MiTurno;
        string resultado3 = facade.CambiarPokemon(e1, "Mew", e2);
        int resultado1 = e1.Turnos;
        bool resultado2 = e1.MiTurno;
        string esperado3 = "e1 ha cambiado su Pokémon actual a Mew";
        Assert.That(esperado1,Is.EqualTo(resultado1));
        Assert.That(esperado2,Is.EqualTo(resultado2));
        Assert.That(true,Is.EqualTo(resultado3.Contains(esperado3)));
    }
    /// <summary>
    /// Este test comprueba la historia de usuario 8.
    /// </summary>
    [Test]
    public void TestUserStory8()
    {
        Facade facade3 = Facade.Instance;
        facade3.AgregarJugadorListaDeEspera("u1");
        facade233.AgregarJugadorListaDeEspera("e2");
        facade2.ComenzarBatalla("e1", "e2");
        Batalla battle2 = facade.EncontrarBatallaPorUsuario("e1");
        Entrenador e1 = battle2.Jugador1;
        Entrenador e2 = battle2.Jugador2;m 
        facade.AgregarPokemon(e1, "Pikachu");
        facade.AgregarPokemon(e1, "Bulbasaur");
        facade.AgregarPokemon(e1, "Mew");
        facade.AgregarPokemon(e1, "Ponyta");
        facade.AgregarPokemon(e1, "Squirtle");
        facade.AgregarPokemon(e1, "Charmander");
        facade.AgregarPokemon(e2, "Dratini");
        facade.AgregarPokemon(e2, "Pikachu");
        facade.AgregarPokemon(e2, "Goomy");
        facade.AgregarPokemon(e2, "Cranidos");
        facade.AgregarPokemon(e2, "Vullaby");
        facade.AgregarPokemon(e2, "Vanillite");
        battle2.EnBatalla = true;
        e1.PokemonActual = e1.GetMiCatalogo().First(p => p.Nombre == "Pikachu");
        e2.PokemonActual = e2.GetMiCatalogo().First(p => p.Nombre == "Dratini");
        int esperado1 = e1.Turnos + 1;
        bool esperado2 = !e1.MiTurno;
        jugador1.PokemonActual.RecibirDano(70);
        string resultado3 = facade.UsoDeItem(e1, "SúperPoción", "Pikachu", e2);
        int resultado1 = e1.Turnos;
        bool resultado2 = e1.MiTurno;
        string esperado3 = "SúperPoción fue usado en Pikachu";
        Assert.That(esperado1,Is.EqualTo(resultado1));
        Assert.That(esperado2,Is.EqualTo(resultado2));
        Assert.That(true,Is.EqualTo(resultado3.Contains(esperado3)));
    }
    /// <summary>
    /// Este test comprueba la historia de usuario 9.
    /// </summary>
    [Test]
    public void TestUserStory9()
    {
        string resultado = facade.AgregarJugadorListaDeEspera("j3");
        string esperado = "j3 agregado a la lista de espera";
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba la historia de usuario 10.
    /// </summary>
    [Test]
    public void TestUserStory10()
    {
        facade.AgregarJugadorListaDeEspera("j3");
        string resultado = facade.GetJugadoresEsperando();
        string esperado = "Esperan: j3; ";
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba la historia de usuario 11.
    /// </summary>
    [Test]
    public void TestUserStory11()
    {
        facade.AgregarJugadorListaDeEspera("j3");
        facade.AgregarJugadorListaDeEspera("j4");
        string resultado = facade.ComenzarBatalla("j3", "j4");
        string esperado = "Comienza la batalla entre j3 y j4";
        Assert.That(esperado,Is.EqualTo(resultado));
    }
}