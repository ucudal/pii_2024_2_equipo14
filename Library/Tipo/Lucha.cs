namespace Library;

public class Lucha: Tipo
{
    public Lucha()
    {
        this.Nombre = "Lucha";
        this.debilContra.Add("Psíquico");
        this.debilContra.Add("Volador");
        this.debilContra.Add("Bicho");
        this.debilContra.Add("Roca");
    }
}