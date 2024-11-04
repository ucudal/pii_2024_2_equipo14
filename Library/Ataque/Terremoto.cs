namespace Library.Otros;

public class Terremoto: Ataque
{
    public Terremoto()
    {
        this.Nombre = "Terremoto";
        this.Tipo = new Tierra();
        this.Dano = 40;
    }
}