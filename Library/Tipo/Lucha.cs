namespace Library;

public class Lucha: Tipo
{
    public Lucha()
    {
        this.Nombre = "Lucha";
        this.debilContra.Add(new Psiquico());
        this.debilContra.Add(new Volador());
        this.debilContra.Add(new Bicho());
        this.debilContra.Add(new Roca());
    }
}