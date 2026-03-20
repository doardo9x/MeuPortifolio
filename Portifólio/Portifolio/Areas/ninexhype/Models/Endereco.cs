using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Areas.NinexHype.Models;

public class Endereco
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(9)]
    public string Cep { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Logradouro { get; set; } = string.Empty;

    [Required, StringLength(10)]
    public string Numero { get; set; } = string.Empty;

    [StringLength(100)]
    public string Complemento { get; set; }

    [Required, StringLength(50)]
    public string Bairro { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string Cidade { get; set; } = string.Empty;

    [Required, StringLength(2)]
    public string Estado { get; set; } = string.Empty;

    // Relacionamento 1:1 com Usuario
    [Required]
    public string UsuarioId { get; set; } = string.Empty;

    [ForeignKey("UsuarioId")]
    public Usuario Usuario { get; set; } = null!;
}
