namespace Library;

public class Psiquico: Tipo
{
    public Psiquico()
    {
        this.Nombre = "Psiquico";
        this.debilContra.Add(new Bicho());
        this.debilContra.Add(new Lucha());
        this.debilContra.Add(new Fantasma());
    }
}