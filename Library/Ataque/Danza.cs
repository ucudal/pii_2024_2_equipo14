namespace Library.Otros;

public class Danza: Ataque
{
    public Danza()
    {
        this.Nombre = "Danza";
        this.Tipo = new Fantasma();
        this.Dano = 10;
    }
}