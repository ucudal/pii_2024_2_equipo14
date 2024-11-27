using Library;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace LibraryTests;
/// <summary>
/// Esta es la clase FacadeTests. Se encarga de comprobar sus funcionalidades.
/// </summary>
[TestFixture]
[TestOf(typeof(Facade))]
public class FacadeTests
{
    private ListaDeEspera listaDeEspera;
    private ListaBatallas listaBatallas;
    private Entrenador j1;
    private Entrenador j2;
    private Pokemon pokemon;
    private Pokemon pokemon2;
    private Batalla batalla;
    /// <summary>
    /// En este SetUp instanciamos objetos que necesitaremos para testear esta clase.
    /// </summary>
    [SetUp]
    public void SetUp()
    { 
        Facade.Reset();
        j1 = new Entrenador("j1");
        j2 = new Entrenador("j2");
        pokemon = new Pokemon("Pikachu", "Eléctrico",new Ataque("Rayo",40,20, "Eléctrico"),new Zzz());
        pokemon2 = new Pokemon("Mew", "Psíquico", new Ataque("Hipnosis", 30, 80, "Psíquico"), new Off());
        batalla = new Batalla(j1, j2);
    }
    /// <summary>
    /// Este test comprueba que se pueda encontrar una batalla de la lista de batallas por el nombre de un jugador.
    /// </summary>
    [Test]
    public void TestEncontrarBatallaPorUsuario()
    {
        Facade instance = Facade.Instance;
        instance.AgregarJugadorListaDeEspera("j1");
        instance.AgregarJugadorListaDeEspera("j2");
        instance.ComenzarBatalla("j1", "j2");
        Batalla resultado = instance.EncontrarBatallaPorUsuario("j1");
        Assert.That(resultado,Is.Not.Null);
    }
    /// <summary>
    /// Este test comprueba que se pueda agregar correctamente un jugador a la lista de espera.
    /// </summary>
    [Test]
    public void TestAgregarJugadorListaDeEspera()
    {
        Facade instance = Facade.Instance;
        string resultado1 = instance.AgregarJugadorListaDeEspera("j1");
        string esperado1 = "j1 agregado a la lista de espera";
        Assert.That(esperado1,Is.EqualTo(resultado1));
        
        string resultado2 = instance.AgregarJugadorListaDeEspera("j1");
        string esperado2 = "j1 ya está en la lista de espera";
        Assert.That(esperado2,Is.EqualTo(resultado2));
    }
    /// <summary>
    /// Este test comprueba que se pueda quitar correctamente un jugador de la lista de espera.
    /// </summary>
    [Test]
    public void TestQuitarJugadorListaDeEspera()
    {
        Facade instance = Facade.Instance;
        instance.AgregarJugadorListaDeEspera("j1");
        string resultado1 = instance.QuitarJugadorListaDeEspera("j1");
        string esperado1 = "j1 removido de la lista de espera";
        Assert.That(esperado1,Is.EqualTo(resultado1));
        
        string resultado2 = instance.QuitarJugadorListaDeEspera("j1");
        string esperado2 = "j1 no está en la lista de espera";
        Assert.That(esperado2, Is.EqualTo(resultado2));
    }
    /// <summary>
    /// Este test comprueba que se pueda obtener los nombres de los jugadores en la lista de espera.
    /// </summary>
    [Test]
    public void TestGetJugadoresEsperando()
    {
        Facade instance = Facade.Instance;
        string resultado1 = instance.GetJugadoresEsperando();
        string esperado1 = "No hay nadie esperando";
        Assert.That(esperado1,Is.EqualTo(resultado1));

        instance.AgregarJugadorListaDeEspera("j1");
        string resultado2 = instance.GetJugadoresEsperando();
        string esperado2 = "Esperan: j1; ";
        Assert.That(esperado2,Is.EqualTo(resultado2));
    }
    /// <summary>
    /// Este test comprueba que se pueda obtener si un jugador está en la lista de espera.
    /// </summary>
    [Test]
    public void TestJugadorEsperando()
    {
        Facade instance = Facade.Instance;
        string resultado1 = instance.JugadorEsperando("j1");
        string esperado1 = "j1 no está esperando";
        Assert.That(esperado1,Is.EqualTo(resultado1));

        instance.AgregarJugadorListaDeEspera("j1");
        string resultado2 = instance.JugadorEsperando("j1");
        string esperado2 = "j1 está esperando";
        Assert.That(esperado2,Is.EqualTo(resultado2));
    }
    /// <summary>
    /// Este test comprueba que se pueda comenzar una batalla.
    /// </summary>
    [Test]
    public void TestComenzarBatalla()
    {
        Facade instance = Facade.Instance;
        instance.AgregarJugadorListaDeEspera("j1");
        instance.AgregarJugadorListaDeEspera("j2");
        string resultado1 = instance.ComenzarBatalla("j1", "j2");
        string esperado1 = "Comienza la batalla entre j1 y j2";
        Assert.That(esperado1,Is.EqualTo(resultado1));

        instance.QuitarJugadorListaDeEspera("j2");
        string resultado2 = instance.ComenzarBatalla("j1", "j2");
        string esperado2 = "j2 no está esperando";
        Assert.That(resultado2,Is.EqualTo(esperado2));

        string resultado3 = instance.ComenzarBatalla("j1", null);
        string esperado3 = "No hay nadie esperando";
        Assert.That(esperado3,Is.EqualTo(resultado3));
    }
    /// <summary>
    /// Este test comprueba que se pueda obtener la información de un jugador.
    /// </summary>
    [Test]
    public void TestMostrarInformacion()
    {
        Facade instance = Facade.Instance;
        string resultado = instance.MostrarInformacion(j1);
        string esperado = "\n\r\nCATÁLOGO DE j1:\r\n";
        Assert.That(esperado, Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se pueda obtener la lista de la Pokédex.
    /// </summary>
    [Test]
    public void TestMostrarPokedex()
    {
        Facade instance = Facade.Instance;
        string resultado = instance.MostrarPokedex().Substring(0,52);
        string esperado = "\nPOKÉDEX (Elige 6):\r\n \t - Bulbasaur | Tipo: Planta\r\n";
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se pueda agregar un Pokémon durante la batalla.
    /// </summary>
    [Test]
    public void TestAgregarPokemon()
    {
        Facade instance = Facade.Instance;
        instance.AgregarJugadorListaDeEspera("j1");
        instance.AgregarJugadorListaDeEspera("j2");
        instance.ComenzarBatalla("j1", "j2");
        Batalla battle = instance.EncontrarBatallaPorUsuario("j1");
        Entrenador jugador1 = battle.Jugador1;
        string resultado1 = instance.AgregarPokemon(jugador1, "Pikachu");
        string esperado1 = "j1 ha agregado a ¨Pikachu¨ de tipo Eléctrico a su catálogo";
        Assert.That(esperado1,Is.EqualTo(resultado1));

        string resultado2 = instance.AgregarPokemon(jugador1, "Pikachu");
        string esperado2 = "j1, ya tienes ese Pokemon";
        Assert.That(esperado2,Is.EqualTo(resultado2));

        string resultado3 = instance.AgregarPokemon(jugador1, "Shrek");
        string esperado3 = "Pokémon inválido"; 
        Assert.That(esperado3,Is.EqualTo(resultado3));

        instance.AgregarPokemon(jugador1, "Bulbasaur");
        instance.AgregarPokemon(jugador1, "Squirtle");
        instance.AgregarPokemon(jugador1, "Charmander");
        instance.AgregarPokemon(jugador1, "Eevee");
        instance.AgregarPokemon(jugador1, "Ponyta");
        string resultado4 = instance.AgregarPokemon(jugador1,"Mew").Substring(0,25);
        string esperado4 = "j1, ya tienes 6 Pokémones";
        Assert.That(esperado4,Is.EqualTo(resultado4));
    }
    /// <summary>
    /// Este test comprueba que se pueda inicializar la batalla y asignar Pokémones actuales a los jugadores.
    /// </summary>
    [Test]
    public void TestInicializarEncuentros()
    {
        Facade instance = Facade.Instance;
        instance.AgregarJugadorListaDeEspera("j1");
        instance.AgregarJugadorListaDeEspera("j2");
        instance.ComenzarBatalla("j1", "j2");
        instance.AgregarPokemon(j1, "Bulbasaur");
        instance.AgregarPokemon(j1, "Squirtle");
        instance.AgregarPokemon(j1, "Charmander");
        instance.AgregarPokemon(j1, "Eevee");
        instance.AgregarPokemon(j1, "Ponyta");
        instance.AgregarPokemon(j1, "Pikachu");
        instance.AgregarPokemon(j2, "Rockruff");
        instance.AgregarPokemon(j2, "Dratini");
        instance.AgregarPokemon(j2, "Cranidos");
        instance.AgregarPokemon(j2, "Skarmory");
        instance.AgregarPokemon(j2, "Mew");
        instance.AgregarPokemon(j2, "Goomy");
        string resultado1 = instance.InicializarEncuentros(batalla).Substring(0,16);
        string esperado1 = "\n\r\nCOMIENZO:\r\n \t";
        bool esperado2 = true;
        Assert.That(esperado1,Is.EqualTo(resultado1));
        Assert.That(esperado2,Is.EqualTo(batalla.EnBatalla));
    }
    /// <summary>
    /// Este test comprueba que se pueda revisar correctamente si un jugador tiene permitido realizar una acción.
    /// </summary>
    [Test]
    public void TestRevisarAccion()
    {
        Facade instance = Facade.Instance;
        instance.AgregarJugadorListaDeEspera("jugador1");
        instance.AgregarJugadorListaDeEspera("jugador2");
        instance.ComenzarBatalla("jugador1", "jugador2");
        Batalla batalla = instance.EncontrarBatallaPorUsuario("jugador1");
        Entrenador jugador1 = batalla.Jugador1;
        Entrenador jugador2 = batalla.Jugador2;
        instance.AgregarPokemon(jugador1, "Pikachu");
        instance.AgregarPokemon(jugador1, "Mew");
        instance.AgregarPokemon(jugador1, "Bulbasaur");
        instance.AgregarPokemon(jugador1, "Ponyta");
        instance.AgregarPokemon(jugador1, "Skarmory");
        instance.AgregarPokemon(jugador1, "Goomy");
        instance.AgregarPokemon(jugador2, "Pikachu");
        instance.AgregarPokemon(jugador2, "Mew");
        instance.AgregarPokemon(jugador2, "Bulbasaur");
        instance.AgregarPokemon(jugador2, "Ponyta");
        instance.AgregarPokemon(jugador2, "Skarmory");
        instance.AgregarPokemon(jugador2, "Goomy");
        instance.InicializarEncuentros(batalla);
        bool resultado = instance.RevisarAccion(jugador1, "Atacar");
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se pueda revisar correctamente si un jugador tiene permitido usar un ataque.
    /// </summary>
    [Test]
    public void TestRevisarAtaque()
    {
        Facade instance = Facade.Instance;
        bool resultado = instance.RevisarAtaque(j1, pokemon, "Rayo", pokemon2);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se pueda revisar correctamente si un jugador posee un ataque.
    /// </summary>
    [Test]
    public void TestPosesionAtaque()
    {
        Facade instance = Facade.Instance;
        Ataque resultado = instance.PosesionAtaque(pokemon, "Rayo");
        Ataque esperado = pokemon.Ataque;
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se pueda revisar correctamente si un jugador posee a un Pokémon de su catálogo.
    /// </summary>
    [Test]
    public void TestPosesionPokemonVivo()
    {
        Facade instance = Facade.Instance;
        instance.AgregarPokemon(j1, "Mew");
        Pokemon resultado = instance.PosesionPokemonVivo(j1, "Mew");
        Pokemon esperado = j1.GetMiCatalogo()[0];
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se pueda revisar correctamente si un jugador posee un Pokémon vivo o muerto.
    /// </summary>
    [Test]
    public void TestPosesionPokemon()
    {
        Facade instance = Facade.Instance;
        instance.AgregarPokemon(j1, "Mew");
        Pokemon resultado = instance.PosesionPokemon(j1, "Mew");
        Pokemon esperado = j1.GetMiCatalogo()[0];
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se pueda atacar correctamente durante la batalla.
    /// </summary>
    [Test]
    public void TestAtacar()
    {
        Facade instance = Facade.Instance;
        instance.AgregarJugadorListaDeEspera("j1");
        instance.AgregarJugadorListaDeEspera("j2");
        instance.ComenzarBatalla("j1", "j2");
        instance.AgregarPokemon(j1, "Bulbasaur");
        instance.AgregarPokemon(j1, "Squirtle");
        instance.AgregarPokemon(j1, "Charmander");
        instance.AgregarPokemon(j1, "Eevee");
        instance.AgregarPokemon(j1, "Ponyta");
        instance.AgregarPokemon(j1, "Pikachu");
        instance.AgregarPokemon(j2, "Rockruff");
        instance.AgregarPokemon(j2, "Dratini");
        instance.AgregarPokemon(j2, "Cranidos");
        instance.AgregarPokemon(j2, "Skarmory");
        instance.AgregarPokemon(j2, "Mew");
        instance.AgregarPokemon(j2, "Goomy");
        instance.InicializarEncuentros(batalla);
        j1.PokemonActual = pokemon;
        j2.PokemonActual = pokemon2;
        string resultado = instance.Atacar(j1, pokemon.GetAtaque(), j2).Substring(0,53);
        string esperado = "\n\r\nATAQUE DE j1:\r\n \t - Pikachu ha atacado a Mew de j2";
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se pueda usar un item correctamente durante la batalla.
    /// </summary>
    [Test]
    public void TestUsoDeItem()
    {
        Facade instance = Facade.Instance;
        instance.AgregarJugadorListaDeEspera("e1");
        instance.AgregarJugadorListaDeEspera("e2");
        instance.ComenzarBatalla("e1", "e2");
        Batalla batalla1 = instance.EncontrarBatallaPorUsuario("e1");
        Entrenador e1 = batalla1.Jugador1;
        Entrenador e2 = batalla1.Jugador2;
        instance.AgregarPokemon(e1, "Bulbasaur");
        instance.AgregarPokemon(e1, "Squirtle");
        instance.AgregarPokemon(e1, "Charmander");
        instance.AgregarPokemon(e1, "Eevee");
        instance.AgregarPokemon(e1, "Ponyta");
        instance.AgregarPokemon(e1, "Pikachu");
        instance.AgregarPokemon(e2, "Rockruff");
        instance.AgregarPokemon(e2, "Dratini");
        instance.AgregarPokemon(e2, "Cranidos");
        instance.AgregarPokemon(e2, "Skarmory");
        instance.AgregarPokemon(e2, "Mew");
        instance.AgregarPokemon(e2, "Goomy");
        instance.InicializarEncuentros(batalla1);
        e1.PokemonActual = e1.GetMiCatalogo()[0];
        Pokemon pokemonafectado = e1.PokemonActual;
        pokemonafectado.RecibirDano(70);
        e1.AgregarItem(new SuperPocion());
        string resultado = instance.UsoDeItem(e1, "SúperPoción", pokemonafectado.Nombre, e2).Substring(0,65);
        string esperado = $"\n\r\nUSO DE ITEM DE e1:\r\n \t - SúperPoción fue usado en {pokemonafectado.Nombre}\r\n\n";
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se pueda obtener los ataques disponibles para el turno.
    /// </summary>
    [Test]
    public void TestMostrarAtaques()
    {
        Facade instance = Facade.Instance;
        string resultado = instance.MostrarAtaques(pokemon,true).Substring(0,38);
        string esperado = "\n\r\nATAQUES DISPONIBLES DE Pikachu:\r\n \t";
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    
    /// <summary>
    /// Este test comprueba que se pueda obtener los items disponibles para usar.
    /// </summary>
    [Test]
    public void TestMostrarItems()
    {
        Facade instance = Facade.Instance;
        j1.AgregarItem(new Revivir());
        string resultado = instance.MostrarItems(j1).Substring(0,43);
        string esperado = "\n\r\nITEMS DISPONIBLES DE j1:\r\n \t - ¨Revivir¨";
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se pueda revisar correctamente si un jugador tiene permitido usar un item.
    /// </summary>
    [Test]
    public void TestRevisarItem()
    {
        Facade instance = Facade.Instance;
        pokemon.Envenenado = true;
        j1.AgregarPokemon(pokemon);
        j1.AgregarItem(new CuraTotal());
        bool resultado = instance.RevisarItem(j1, j1.GetMisItems()[5], pokemon);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se pueda revisar correctamente si un jugador posee a un item en su catálogo.
    /// </summary>
    [Test]
    public void TestPosesionItem()
    {
        Facade instance = Facade.Instance;
        j1.AgregarItem(new SuperPocion());
        Item resultado = instance.PosesionItem(j1,"SúperPoción");
        Item esperado = j1.GetMisItems()[0];
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test permite comprobar que se finaliza efectivamente la batalla con este método.
    /// </summary>
    [Test]
    public void TestFinalizar()
    {
        Facade instance = Facade.Instance;
        instance.AgregarJugadorListaDeEspera("j1");
        instance.AgregarJugadorListaDeEspera("j2");
        instance.ComenzarBatalla("j1", "j2");
        Batalla batalla2 = instance.EncontrarBatallaPorUsuario("j1");
        Entrenador jugador1 = batalla2.Jugador1;
        jugador1.AgregarPokemon(pokemon);
        string resultado = instance.Finalizar(batalla2);
        string esperado = $"\n\r\nFIN DE LA BATALLA:\r\n \t - j1 le ha ganado a j2\r\n";
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    /// <summary>
    /// Este test comprueba que se pueda cambiar un Pokémon correctamente durante la batalla.
    /// </summary>
    [Test]
    public void TestCambiarPokemon()
    {
        Facade instance = Facade.Instance;
        instance.AgregarJugadorListaDeEspera("j1");
        instance.AgregarJugadorListaDeEspera("j2");
        instance.ComenzarBatalla("j1", "j2");
        instance.AgregarPokemon(j1, "Bulbasaur");
        instance.AgregarPokemon(j1, "Squirtle");
        instance.AgregarPokemon(j1, "Charmander");
        instance.AgregarPokemon(j1, "Eevee");
        instance.AgregarPokemon(j1, "Ponyta");
        instance.AgregarPokemon(j1, "Pikachu");
        instance.AgregarPokemon(j2, "Rockruff");
        instance.AgregarPokemon(j2, "Dratini");
        instance.AgregarPokemon(j2, "Cranidos");
        instance.AgregarPokemon(j2, "Skarmory");
        instance.AgregarPokemon(j2, "Mew");
        instance.AgregarPokemon(j2, "Goomy");
        string resultado1 = instance.InicializarEncuentros(batalla).Substring(0,16);
        j1.AgregarPokemon(pokemon);
        j1.AgregarPokemon(pokemon2);
        j1.PokemonActual = pokemon;
        string resultado = instance.CambiarPokemon(j1, "Mew", j2);
        string esperado = "j1 ha cambiado su Pokémon actual a Mew";
        Assert.That(esperado,Is.EqualTo(resultado.Substring(0,38)));
    }
    /// <summary>
    /// Este test comprueba que se pueda obtener el estado de una batalla (si hay alguno con Pokémons vivos).
    /// </summary>
    [Test]
    public void TestChequeoEstado()
    {
        Facade instance = Facade.Instance;
        bool resultado = instance.ChequeoEstado(batalla);
        bool esperado = false;
        Assert.That(esperado,Is.EqualTo(resultado));
    }

    /// <summary>
    /// TEST DE DEFENSA (PUSE QUE SEA EL JUGADOR1 PORQUE ES EL QUE COMIENZA LA BATALLA, POR LO TANTO PUEDE ESTABLECER REGLAS)
    /// </summary>
    [Test]
    public void TestComenzarBatallaConReglas()
    {
        Facade instance = Facade.Instance;
        instance.AgregarJugadorListaDeEspera("j1");
        instance.AgregarJugadorListaDeEspera("j2");
        Entrenador jugador1 = instance.GetJugadorListaDeEspera("j1"); //nuevo método
        Entrenador jugador2 = instance.GetJugadorListaDeEspera("j2"); //nuevo método
        jugador1.ProponerReglas(new List<string> { "Agua" },new List<string>(),new List<string>(), new List<string>(),new List<string>(),new List<string>{"SuperPoción"});
        instance.AceptarReglas(jugador2);
        string resultado = instance.ComenzarBatalla("j1", "j2");
        Assert.That(resultado.Contains("TIPOS PERMITIDOS: Agua"));
        Assert.That(resultado.Contains("ITEMS PROHIBIDOS: SuperPoción"));
    }

    [Test]
    public void TestComenzarBatallaConReglasDenegadas()
    {
        Facade instance = Facade.Instance;
        instance.AgregarJugadorListaDeEspera("j1");
        instance.AgregarJugadorListaDeEspera("j2");
        Entrenador jugador1 = instance.GetJugadorListaDeEspera("j1"); //nuevo método
        Entrenador jugador2 = instance.GetJugadorListaDeEspera("j2"); //nuevo método
        jugador1.ProponerReglas(new List<string> { "Agua" },new List<string>(),new List<string>(), new List<string>(),new List<string>(),new List<string>{"SuperPoción"});
        string resultado = instance.ComenzarBatalla("j1", "j2");
        Assert.That(resultado, Is.EqualTo("No se ha podido crear la batalla"));
    }
}