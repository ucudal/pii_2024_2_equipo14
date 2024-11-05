namespace Library;

public class Mew: Pokemon
{
    public Mew()
    {
        this.Nombre = "Mew";
        this.Tipo = new Psiquico();
        this.misAtaques.Add(new Rayo());
        this.misAtaques.Add(new Maniqui());
    }
}