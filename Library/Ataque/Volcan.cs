namespace Library.Otros;

public class Volcan: Ataque
{
    public Volcan()
    {
        this.Nombre = "Volcan";
        this.Tipo = new Dragon();
        this.Dano = 30;
    }
}