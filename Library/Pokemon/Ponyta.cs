namespace Library;

public class Ponyta: Pokemon
{
    public Ponyta()
    {
        this.Nombre = "Ponyta";
        this.Tipo = new Psiquico();
        this.misAtaques.Add(new Golpe());
        this.misAtaques.Add(new Maniqui());
    }
}