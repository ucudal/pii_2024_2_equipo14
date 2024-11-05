namespace Library;

public class Skarmory: Pokemon
{
    public Skarmory()
    {
        this.Nombre = "Skarmory";
        this.Tipo = new Volador();
        this.misAtaques.Add(new Viento());
        this.misAtaques.Add(new Off());
    }
}