namespace Library;

public class Derrumbe: Ataque
{
    public Derrumbe()
    {
        this.Nombre = "Derrumbe";
        this.Tipo = new Roca();
        this.Dano = 35;
    }
}