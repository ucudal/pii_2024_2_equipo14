namespace Library;

public class Iceberg: Ataque
{
    public Iceberg()
    {
        this.Nombre = "Iceberg";
        this.Tipo = new Hielo();
        this.Dano = 20;
        this.Precision = 60;
    }
}