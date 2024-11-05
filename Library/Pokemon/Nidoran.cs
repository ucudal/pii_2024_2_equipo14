namespace Library;

public class Nidoran: Pokemon
{
    public Nidoran()
    {
        this.Nombre = "Nidoran";
        this.Tipo = new Veneno();
        this.misAtaques.Add(new Tsunami());
        this.misAtaques.Add(new Off());
    }
}