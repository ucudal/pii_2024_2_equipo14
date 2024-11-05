namespace Library;

public class Pikachu: Pokemon
{
    public Pikachu()
    {
        this.Nombre = "Pikachu";
        this.Tipo = new Electrico();
        this.misAtaques.Add(new Rayo());
        this.misAtaques.Add(new Incendio());
    }
}