namespace Library;

public class Facade
{
    private Entrenador entrenador1;
    private Entrenador entrenador2;
    private Batalla batalla;

    public Facade(string nombrentrenador1, string nombrentrenador2)
    {
        entrenador1 = new Entrenador(nombrentrenador1);
        entrenador2 = new Entrenador(nombrentrenador2);
        
        InicializarEntrenadores();

        batalla = new Batalla(entrenador1, entrenador2);
    }

    private void InicializarEntrenadores()
    {
        entrenador1.AgregarPokemon("Pikachu");
        entrenador1.AgregarPokemon("Mew");
        entrenador1.AgregarPokemon("Bulbasaur");
        entrenador1.AgregarPokemon("Dratini");
        entrenador1.AgregarPokemon("Psyduck");
        entrenador1.AgregarPokemon("Goomy");
        
        
        entrenador2.AgregarPokemon("Skarmory");
        entrenador2.AgregarPokemon("Squirtle");
        entrenador2.AgregarPokemon("Vulpix");
        entrenador2.AgregarPokemon("Vanillite");
        entrenador2.AgregarPokemon("Ponyta");
        entrenador2.AgregarPokemon("Eevee");
    }

    public void ComenzarBatalla()
    {
        batalla.Comenzar();
    }
}
