namespace Library.Otros;

public class Viento: Ataque
{
    public Viento()
    {
        this.Nombre = "Viento";
        this.Tipo = new Volador();
        this.Dano = 25;
    }
}