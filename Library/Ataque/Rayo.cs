namespace Library;

public class Rayo: Ataque
{
    public Rayo()
    {
        this.Nombre = "Rayo";
        this.Tipo = new Electrico();
        this.Dano = 40;
        this.Precision = 0.2;
    }
}