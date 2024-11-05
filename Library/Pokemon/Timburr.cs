namespace Library;

public class Timburr: Pokemon
{
    public Timburr()
    {
        this.Nombre = "Timburr";
        this.Tipo = new Lucha();
        this.misAtaques.Add(new Golpe());
        this.misAtaques.Add(new Incendio());
    }
}