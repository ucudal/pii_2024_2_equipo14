namespace Library;

public class Pokemon
{
    public Pokemon(string nombre, Tipo tipo, Ataque ataque, AtaqueEspecial ataqueEspecial)
    {
        Nombre = nombre;
        Tipo = tipo;
        Ataque = ataque;
        AtaqueEspecial = ataqueEspecial;
        
    }
    public string Nombre { get; protected set; }
    public Tipo Tipo { get; protected set; }
    public Ataque Ataque { get; protected set; }
    public AtaqueEspecial AtaqueEspecial { get; protected set; }
    
    public bool Dormido { get; set; }
    public bool Paralizado { get; set; }
    public bool Envenenado { get; set; }
    public bool Quemado { get; set; }
    public int TurnosDormido { get; set; }

    public string GetNombreTipo()
    {
        return this.Tipo.Nombre;
    }
    
    public int VidaInicial {get { return 80; }}
    public int VidaTotal
    {
        get { return 80;}
        protected set { this.VidaTotal = value < 0 ? 0 : value; }
    }
    public void Curar(int puntos)
    {
        this.VidaTotal += puntos;
    }
    public void RecibirDano(int dano)
    {
        this.VidaTotal -= dano;
    }
    public List<string> GetDebilContra()
    {
        return this.Tipo.debilContra;
    }
    public List<string> GetResistenteContra()
    {
        return this.Tipo.resistenteContra;
    }
    public List<string> GetInmuneContra()
    {
        return this.Tipo.inmuneContra;
    }
    public int PuedeAtacar()
    {
        Random puedeAtacar = new Random();
        int puede = puedeAtacar.Next(0, 2);
        return puede;
    }
    
}