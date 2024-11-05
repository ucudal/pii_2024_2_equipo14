namespace Library;

public class Cranidos: Pokemon
{
    public Cranidos()
    {
        this.Nombre = "Cranidos";
        this.Tipo = new Roca();
        this.misAtaques.Add(new Derrumbe());
        this.misAtaques.Add(new Maniqui());
    }
}