namespace Library.Otros;

public class Derrumbe: Ataque
{
    public Derrumbe()
    {
        this.Nombre = "Derrumbe";
        this.Tipo = new Roca();
        this.Dano = 35;
    }
}