using Portifolio.Areas.NinexHype.Models;

namespace Portifolio.Areas.NinexHype.ViewModels;

public class ProdutoVM
{
    public List<Produto> Produtos { get; set; } = new();
    public Produto Produto { get; set; }
    public List<Produto> Semelhantes { get; set; }
    public Produto Destaque { get; set; }
}
