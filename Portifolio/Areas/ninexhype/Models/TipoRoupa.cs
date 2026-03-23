using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Areas.NinexHype.Models;

[Table("tiporoupa")]
public class TipoRoupa
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nome { get; set; } = string.Empty;

    public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
}
