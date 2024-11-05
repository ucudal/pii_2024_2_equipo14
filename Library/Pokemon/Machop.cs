namespace Library;

public class Machop: Pokemon
{
    public Machop()
    {
        this.Nombre = "Machop";
        this.Tipo = new Lucha();
        this.misAtaques.Add(new Golpe());
        this.misAtaques.Add(new Zzz());
    }
}