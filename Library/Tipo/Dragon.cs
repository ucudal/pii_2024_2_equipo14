namespace Library;

public class Dragon: Tipo
{
    public Dragon()
    {
        this.Nombre = "Dragón";
        this.debilContra.Add("Dragón");
        this.debilContra.Add("Hielo");
        this.resistenteContra.Add("Agua");
        this.resistenteContra.Add("Eléctrico");
        this.resistenteContra.Add("Fuego");
        this.resistenteContra.Add("Planta");
    }
}