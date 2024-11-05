namespace Library;

public class Florecer: Ataque
{
    public Florecer()
    {
        this.Nombre = "Florecer";
        this.Tipo = new Planta();
        this.Dano = 10;
    }
}