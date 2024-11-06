namespace Library;

public class Zzz: AtaqueEspecial
{
    public Zzz()
    {
        this.Nombre = "Zzz";
        this.Tipo = new Normal();
        this.Dano = 0;
        this.Efecto = "Dormir";
    }

    public static void Dormir(Entrenador entrenador)
    {
        Random turnosDormido = new Random();
        int turnos = turnosDormido.Next(1, 5);
        if (entrenador.PokemonActual.Dormido == false)
        {
            entrenador.PokemonActual.Dormido = true;
            entrenador.PokemonActual.TurnosDormido = entrenador.Turnos + turnos;
        }
        
    }
}