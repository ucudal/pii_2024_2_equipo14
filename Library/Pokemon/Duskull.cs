namespace Library;

public class Duskull: Pokemon
{
    public Duskull()
    {
        this.Nombre = "Duskull";
        this.Tipo = new Fantasma();
        this.misAtaques.Add(new Danza());
        this.misAtaques.Add(new Off());
    }
}