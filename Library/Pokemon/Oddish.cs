namespace Library;

public class Oddish: Pokemon
{
    public Oddish()
    {
        this.Nombre = "Oddish";
        this.Tipo = new Planta();
        this.misAtaques.Add(new Florecer());
        this.misAtaques.Add(new Maniqui());
    }
}