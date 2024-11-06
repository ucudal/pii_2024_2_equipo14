namespace Library;

public class Maniqui: AtaqueEspecial
{
    public Maniqui()
    {
        this.Nombre = "Maniqui";
        this.Tipo = new Psiquico();
        this.Dano = 0;
        this.Precision = 80;
        this.Efecto = "Paralizar";
    }
    public static void Paralizar(Pokemon pokemon)
    {
        Random turnoParalizado = new Random();
        {
            pokemon.Paralizado = true;
        }
    }
}