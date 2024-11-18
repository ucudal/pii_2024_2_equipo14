using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(CuraTotal))]
public class CuraTotalTests
{
    private CuraTotal curaTotal;
    private Pokemon pokemon;
    
    public void SetUp()
    {
        curaTotal = new CuraTotal();
        pokemon=new Pokemon("Pikachu", "Eléctrico", new Ataque("Rayo", 40, 20, "Eléctrico"), new Zzz());
    }

    [Test]
    public void TestCuraTotal()
    {
        string esperado = "Cura Total";
        string esperado1="Cura a un Pokémon de efectos de ataques especiales";
        
        Assert.That(esperado,Is.EqualTo(curaTotal.Nombre));
        Assert.That(esperado1,Is.EqualTo(curaTotal.Descripcion));
    }
}