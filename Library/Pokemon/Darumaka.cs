namespace Library;

public class Darumaka: Pokemon
{
    public Darumaka()
    {
        this.Nombre = "Darumaka";
        this.Tipo = new Hielo();
        this.misAtaques.Add(new Iceberg());
        this.misAtaques.Add(new Maniqui());
    }
}