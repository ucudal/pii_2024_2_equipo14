namespace Library.Otros;

public class Off: AtaqueEspecial
{
    public Off()
    {
        this.Nombre = "Off";
        this.Tipo = new Veneno();
        this.Dano = 30;
        this.Efecto = "Envenenar";
        //agregar efecto envenenar
    }
}