using Library;
using NUnit.Framework;

namespace LibraryTests;

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
   
    [Test]
    public void TestMostrarInformacion()
    {
        Facade instance = Facade.Instance;
        string resultado = instance.MostrarInformacion(j1);
        string esperado = "\n\r\nCATÁLOGO DE j1:\r\n";
        Assert.That(esperado, Is.EqualTo(resultado));
    }
   
    [Test]
    public void TestMostrarPokedex()
    {
        Facade instance = Facade.Instance;
        string resultado = instance.MostrarPokedex().Substring(0,52);
        string esperado = "\nPOKÉDEX (Elige 6):\r\n \t - Bulbasaur | Tipo: Planta\r\n";
        Assert.That(esperado,Is.EqualTo(resultado));
    }

    [Test]
    public void TestAgregarPokemon()
    {
        Facade instance = Facade.Instance;
        string resultado1 = instance.AgregarPokemon(j1, "Pikachu");
        string esperado1 = "j1 ha agregado a ¨Pikachu¨ de tipo Eléctrico a su catálogo";
        Assert.That(esperado1,Is.EqualTo(resultado1));

        string resultado2 = instance.AgregarPokemon(j1, "Pikachu");
        string esperado2 = "j1, ya tienes ese Pokemon";
        Assert.That(esperado2,Is.EqualTo(resultado2));

        string resultado3 = instance.AgregarPokemon(j1, "Shrek");
        string esperado3 = "Pokémon inválido"; 
        Assert.That(esperado3,Is.EqualTo(resultado3));

        instance.AgregarPokemon(j1, "Bulbasaur");
        instance.AgregarPokemon(j1, "Squirtle");
        instance.AgregarPokemon(j1, "Charmander");
        instance.AgregarPokemon(j1, "Eevee");
        instance.AgregarPokemon(j1, "Ponyta");
        string resultado4 = instance.AgregarPokemon(j1,"Mew");
        string esperado4 = "j1, ya tienes 6 Pokémones";
        Assert.That(esperado4,Is.EqualTo(resultado4));
    }
    [Test]
    public void TestInicializarEncuentros()
    {
        Facade instance = Facade.Instance;
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
     
    [Test]
    public void TestRevisarAccion()
    {
        Facade instance = Facade.Instance;
        instance.AgregarPokemon(j1, "Bulbasaur");
        j1.PokemonActual = pokemon;
        bool resultado = instance.RevisarAccion(j1, "Atacar");
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado));
    }
      
    [Test]
    public void TestRevisarAtaque()
    {
        Facade instance = Facade.Instance;
        bool resultado = instance.RevisarAtaque(j1, pokemon, "Rayo", pokemon2);
        bool esperado = true;
        Assert.That(esperado,Is.EqualTo(resultado));
    }
      
    [Test]
    public void TestPosesionAtaque()
    {
        Facade instance = Facade.Instance;
        Ataque resultado = instance.PosesionAtaque(pokemon, "Rayo");
        Ataque esperado = pokemon.Ataque;
        Assert.That(esperado,Is.EqualTo(resultado));
    }

    [Test]
    public void TestPosesionPokemonVivo()
    {
        Facade instance = Facade.Instance;
        instance.AgregarPokemon(j1, "Mew");
        Pokemon resultado = instance.PosesionPokemonVivo(j1, "Mew");
        Pokemon esperado = j1.GetMiCatalogo()[0];
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    
    [Test]
    public void TestPosesionPokemon()
    {
        Facade instance = Facade.Instance;
        instance.AgregarPokemon(j1, "Mew");
        Pokemon resultado = instance.PosesionPokemon(j1, "Mew");
        Pokemon esperado = j1.GetMiCatalogo()[0];
        Assert.That(esperado,Is.EqualTo(resultado));
    }

    [Test]
    public void TestAtacar()
    {
        Facade instance = Facade.Instance;
        j1.PokemonActual = pokemon;
        j2.PokemonActual = pokemon2;
        string resultado = instance.Atacar(j1, pokemon.Ataque, j2).Substring(0,53);
        string esperado = "\n\r\nATAQUE DE j1:\r\n \t - Pikachu ha atacado a Mew de j2";
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    
    [Test]
    public void TestUsoDeItem()
    {
        Facade instance = Facade.Instance;
        pokemon.RecibirDano(70);
        j1.AgregarPokemon(pokemon);
        j1.AgregarItem(new SuperPocion());
        string resultado = instance.UsoDeItem(j1, j1.GetMisItems()[0], pokemon,j2).Substring(0,60);
        string esperado = "\n\r\nUSO DE ITEM DE j1:\r\n \t - SúperPoción fue usado en Pikachu";
        Assert.That(esperado,Is.EqualTo(resultado));
    }
   
    [Test]
    public void TestMostrarAtaques()
    {
        Facade instance = Facade.Instance;
        string resultado = instance.MostrarAtaques(pokemon,true).Substring(0,38);
        string esperado = "\n\r\nATAQUES DISPONIBLES DE Pikachu:\r\n \t";
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    
    [Test]
    public void TestMostrarItems()
    {
        Facade instance = Facade.Instance;
        j1.AgregarItem(new Revivir());
        string resultado = instance.MostrarItems(j1).Substring(0,43);
        string esperado = "\n\r\nITEMS DISPONIBLES DE j1:\r\n \t - ¨Revivir¨";
        Assert.That(esperado,Is.EqualTo(resultado));
    }

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

    [Test]
    public void TestPosesionItem()
    {
        Facade instance = Facade.Instance;
        j1.AgregarItem(new SuperPocion());
        Item resultado = instance.PosesionItem(j1,"SúperPoción");
        Item esperado = j1.GetMisItems()[0];
        Assert.That(esperado,Is.EqualTo(resultado));
    }
   
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
   
    [Test]
    public void TestCambiarPokemon()
    {
        Facade instance = Facade.Instance;
        j1.AgregarPokemon(pokemon);
        j1.AgregarPokemon(pokemon2);
        j1.PokemonActual = pokemon;
        string resultado = instance.CambiarPokemon(j1, "Mew", j2);
        string esperado = "j1 ha cambiado su Pokémon actual a Mew";
        Assert.That(esperado,Is.EqualTo(resultado));
    }

    [Test]
    public void TestChequeoEstado()
    {
        Facade instance = Facade.Instance;
        bool resultado = instance.ChequeoEstado(batalla);
        bool esperado = false;
        Assert.That(esperado,Is.EqualTo(resultado));
    }
    
}