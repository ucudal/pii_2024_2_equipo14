namespace Library;

public class Zzz: AtaqueEspecial
{
    public Zzz()
    {
        this.Nombre = "Zzz";
        this.Tipo = new Normal();
        this.Dano = 0;
        this.Precision = 1;
        this.Efecto = "Dormir";
        //agregar efecto dormir
    }
}