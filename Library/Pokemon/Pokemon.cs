namespace Library;

public abstract class Pokemon
{
    public string Nombre { get; protected set; }
    public Tipo Tipo { get; protected set; }
    public int VidaInicial {get { return 80; }}
    public int VidaTotal
    {
        get { return 80;}
        protected set { this.VidaTotal = value < 0 ? 0 : value; }
    }
    public List<Ataque> misAtaques = new List<Ataque>();
    public void Curar(int puntos)
    {
        this.VidaTotal += puntos;
    }
    public void RecibirDano(int dano)
    {
        this.VidaTotal -= dano;
    }
    public List<Tipo> GetDebilContra()
    {
        return this.Tipo.debilContra;
    }
    public List<Tipo> GetResistenteContra()
    {
        return this.Tipo.resistenteContra;
    }
    public List<Tipo> GetInmuneContra()
    {
        return this.Tipo.inmuneContra;
    }
}