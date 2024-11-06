namespace Library;

public class Normal: Tipo
{
    
    public Normal()
    {
        this.Nombre = "Normal";
        this.debilContra.Add("Lucha");
        this.inmuneContra.Add("Fantasma");
    }
}