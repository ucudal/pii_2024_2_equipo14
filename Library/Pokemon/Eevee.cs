namespace Library;

public class Eevee: Pokemon
{
    public Eevee()
    {
        this.Nombre = "Eevee";
        this.Tipo = new Normal();
        this.misAtaques.Add(new Florecer());
        this.misAtaques.Add(new Zzz());
    }
}