namespace Library;

public class Bulbasaur: Pokemon
{
    public Bulbasaur()
    {
        this.Nombre = "Bulbasaur";
        this.Tipo = new Planta();
        this.misAtaques.Add(new Florecer());
        this.misAtaques.Add(new Zzz());
    }
}