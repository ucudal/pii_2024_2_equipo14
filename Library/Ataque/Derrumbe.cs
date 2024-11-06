namespace Library;

public class Derrumbe: Ataque
{
    public Derrumbe()
    {
        this.Nombre = "Derrumbe";
        this.Tipo = new Roca();
        this.Dano = 35;
        this.Precision = 0.5;
    }
}