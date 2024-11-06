namespace Library;

public class Mordisco: Ataque
{
    public Mordisco()
    {
        this.Nombre = "Mordisco";
        this.Tipo = new Bicho();
        this.Dano = 15;
        this.Precision = 0.7;
    }
}