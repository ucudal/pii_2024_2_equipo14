namespace Library;

public class Vanillite: Pokemon
{
    public Vanillite()
    {
        this.Nombre = "Vanillite";
        this.Tipo = new Hielo();
        this.misAtaques.Add(new Iceberg());
        this.misAtaques.Add(new Off());
    }
}