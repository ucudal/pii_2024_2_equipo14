namespace Library.Otros;

public class Maniqui: AtaqueEspecial
{
    public Maniqui()
    {
        this.Nombre = "Maniqui";
        this.Tipo = new Psiquico();
        this.Dano = 0;
        this.Efecto = "Paralizar";
        //agregar efecto paralizador
    }
}