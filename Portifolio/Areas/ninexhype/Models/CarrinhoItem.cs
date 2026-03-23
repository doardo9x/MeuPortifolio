using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Areas.NinexHype.Models
{
    public class CarrinhoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; } = 1;

        [ForeignKey("Carrinho")]
        public int CarrinhoId { get; set; }
        public Carrinho Carrinho { get; set; }
    }
}
