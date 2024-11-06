namespace Library;

public class Psiquico: Tipo
{
    public Psiquico()
    {
        this.Nombre = "Psiquico";
        this.debilContra.Add("Bicho");
        this.debilContra.Add("Lucha");
        this.debilContra.Add("Fantasma");
    }
}