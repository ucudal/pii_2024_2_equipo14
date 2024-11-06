namespace Library;

public class Danza: Ataque
{
    public Danza()
    {
        this.Nombre = "Danza";
        this.Tipo = new Fantasma();
        this.Dano = 10;
        this.Precision = 30;
    }
    
}