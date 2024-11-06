namespace Library;

public class Terremoto: Ataque
{
    public Terremoto()
    {
        this.Nombre = "Terremoto";
        this.Tipo = new Tierra();
        this.Dano = 40;
        this.Precision = 30;
    }
}