namespace Library;

public class Tsunami: Ataque
{
    public Tsunami()
    {
        this.Nombre = "Tsunami";
        this.Tipo = new Agua();
        this.Dano = 30;
    }
}