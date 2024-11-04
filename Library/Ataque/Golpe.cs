namespace Library.Otros;

public class Golpe: Ataque
{
    public Golpe()
    {
        this.Nombre = "Golpe";
        this.Tipo = new Lucha();
        this.Dano = 40;
    }
}