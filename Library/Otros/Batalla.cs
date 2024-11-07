namespace Library;

public class Batalla
{
    public static bool EnBatalla;
    public Entrenador Jugador1 { get; private set; }
    public Entrenador Jugador2 { get; private set; }

    public Batalla(Entrenador jugador1, Entrenador jugador2)
    {
        this.Jugador1 = jugador1;
        this.Jugador2 = jugador2;
        this.Jugador1.MisItems = new List<Item>
        {
            new SuperPocion(), new SuperPocion(), new SuperPocion(),
            new SuperPocion(), new Revivir(), new CuraTotal(), new CuraTotal()
        };
        this.Jugador2.MisItems = new List<Item>
        {
            new SuperPocion(), new SuperPocion(), new SuperPocion(),
            new SuperPocion(), new Revivir(), new CuraTotal(), new CuraTotal()
        };
    }

    public void Comenzar()
    {
        if (Jugador1.miCatalogo.Count == 6 && Jugador2.miCatalogo.Count == 6)
        {
            Random primerPokemonJ1 = new Random();
            int pokemonRandom1 = primerPokemonJ1.Next(0, 6);
            Jugador1.PokemonActual = Jugador1.miCatalogo[pokemonRandom1];
            Random primerPokemonJ2 = new Random();
            int pokemonRandom2 = primerPokemonJ2.Next(0, 6);
            Jugador2.PokemonActual = Jugador2.miCatalogo[pokemonRandom2];
            while (Jugador1.miCatalogo.Count > 0 && Jugador2.miCatalogo.Count > 0)
            {
                Jugador1.MiTurno = true;
                Jugador1.Turnos += 1;
                Consola.ElegirAccion();
                string accion1 = Console.ReadLine();
                Turno.HacerAccion(Jugador1,accion1,Jugador2);
                Jugador2.MiTurno = true;
                Jugador2.Turnos += 1;
                Consola.ElegirAccion();
                string accion2 = Console.ReadLine();
                Turno.HacerAccion(Jugador2,accion2,Jugador1);

            }
        }
    }
    
    
    
}