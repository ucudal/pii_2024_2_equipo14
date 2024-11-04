namespace Library.Otros;

public class Mordisco: Ataque
{
    public Mordisco()
    {
        this.Nombre = "Mordisco";
        this.Tipo = new Bicho();
        this.Dano = 15;
    }
}