using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Areas.NinexHype.Models;

[Table("categoria")]
public class Categoria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    // FK explícita
    [Required]
    [ForeignKey("TipoRoupa")]
    public int TipoRoupaId { get; set; }

    // Propriedade de navegação
    public TipoRoupa TipoRoupa { get; set; }

    [Required(ErrorMessage = "Por favor, informe o Nome")]
    [StringLength(30, ErrorMessage = "O Nome deve possuir no máximo 30 caracteres")]
    public string Nome { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }
    
    public List<Produto> Produtos { get; set; } = new();
}
