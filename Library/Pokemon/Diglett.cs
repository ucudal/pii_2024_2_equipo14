namespace Library;

public class Diglett: Pokemon
{
    public Diglett()
    {
        this.Nombre = "Diglett";
        this.Tipo = new Tierra();
        this.misAtaques.Add(new Terremoto());
        this.misAtaques.Add(new Maniqui());
    }
}