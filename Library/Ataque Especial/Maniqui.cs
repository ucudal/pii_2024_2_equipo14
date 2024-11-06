namespace Library;

public class Maniqui: AtaqueEspecial
{
    public Maniqui()
    {
        this.Nombre = "Maniqui";
        this.Tipo = new Psiquico();
        this.Dano = 0;
        this.Precision = 0.8;
        this.Efecto = "Paralizar";
        //agregar efecto paralizador
    }
}