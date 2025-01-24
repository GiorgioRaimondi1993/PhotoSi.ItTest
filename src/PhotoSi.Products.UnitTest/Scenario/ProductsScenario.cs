using PhotoSi.Products.Application.Models;

namespace PhotoSi.Products.UnitTest.Scenario;
public class ProductsScenario
{
    public Dictionary<Guid, Product> Products { get; private set; } = [];

    public ProductsScenario()
    {
        Products[ScenarioIds.AlbumProduct] = new(ScenarioIds.AlbumProduct,
                                                 "Album",
                                                 "Stampe");
        Products[ScenarioIds.RaccoltaFoto] = new(ScenarioIds.RaccoltaFoto,
                                                 "Raccolta",
                                                 "Stampe");
        Products[ScenarioIds.RitoccoImmagini] = new(ScenarioIds.RitoccoImmagini,
                                                    "Ritocco Immagini",
                                                    "Edit");
    }
}

