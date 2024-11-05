namespace Library;

public class Normal: Tipo
{
    
    public Normal()
    {
        this.Nombre = "Normal";
        this.debilContra.Add(new Lucha());
        this.inmuneContra.Add(new Fantasma());
    }
}