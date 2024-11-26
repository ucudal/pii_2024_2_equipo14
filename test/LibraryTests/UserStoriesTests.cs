using System.ComponentModel.Design.Serialization;
using Library;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace LibraryTests;

[TestFixture]

public class UserStoriesTests
{
    private Facade facade;
    private Batalla batalla;
    private Entrenador jugador1;
    private Entrenador jugador2;
    
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

    [Test]
    public void TestUserStory2()
    {
        string resultado = facade.MostrarAtaques(jugador1.PokemonActual, false);
        string esperado = "\n\r\nATAQUES DISPONIBLES DE Pikachu:\r\n \t - ¨Rayo¨ | Tipo: Eléctrico " +
                          "| Daño: 40 | Precisión: 70\r\n";
        Assert.That(esperado,Is.EqualTo(resultado));
    }

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
    
    [Test]
    public void TestUserStory5()
    {
        string resultado = facade.CambiarPokemon(jugador1,"Charmander",jugador2).Substring(45,50);
        string esperado = "\r\n\n------------------TURNO DE j2------------------";
        Assert.That(esperado,Is.EqualTo(resultado));
    }

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

    [Test]
    public void TestUserStory7()
    {
        int esperado1 = jugador1.Turnos + 1;
        bool esperado2 = !jugador1.MiTurno;
        string resultado3 = facade.CambiarPokemon(jugador1, "Mew", jugador2);
        int resultado1 = jugador1.Turnos;
        bool resultado2 = jugador1.MiTurno;
        string esperado3 = "j1 ha cambiado su Pokémon actual a Mew\r\n\n";
        Assert.That(esperado1,Is.EqualTo(resultado1));
        Assert.That(esperado2,Is.EqualTo(resultado2));
        Assert.That(esperado3,Is.EqualTo(resultado3.Substring(0,41)));
    }

    [Test]
    public void TestUserStory8()
    {
        int esperado1 = jugador1.Turnos + 1;
        bool esperado2 = !jugador1.MiTurno;
        jugador1.PokemonActual.RecibirDano(70);
        string resultado3 = facade.UsoDeItem(jugador1, "SúperPoción", "Pikachu", jugador2).Substring(0,61);
        int resultado1 = jugador1.Turnos;
        bool resultado2 = jugador1.MiTurno;
        string esperado3 = "\n\r\nUSO DE ITEM DE j1:\r\n \t - SúperPoción fue usado en Pikachu\r";
        Assert.That(esperado1,Is.EqualTo(resultado1));
        Assert.That(esperado2,Is.EqualTo(resultado2));
        Assert.That(esperado3,Is.EqualTo(resultado3));
    }

    [Test]
    public void TestUserStory9()
    {
        string resultado = facade.AgregarJugadorListaDeEspera("j3");
        string esperado = "j3 agregado a la lista de espera";
        Assert.That(esperado,Is.EqualTo(resultado));
    }

    [Test]
    public void TestUserStory10()
    {
        facade.AgregarJugadorListaDeEspera("j3");
        string resultado = facade.GetJugadoresEsperando();
        string esperado = "Esperan: j3; ";
        Assert.That(esperado,Is.EqualTo(resultado));
    }

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