using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Portifolio.Areas.NinexHype.Models;

public class Usuario : IdentityUser
{
    [Required(ErrorMessage = "Por favor, informe o nome completo")]
    [StringLength(150)]
    public string Nome { get; set; } = string.Empty;

    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 dígitos")]
    [RegularExpression("^[0-9]{11}$", ErrorMessage = "Informe apenas números no CPF")]
    public string Cpf { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento")]
    public DateTime DataNascimento { get; set; }


    [StringLength(20)]
    [Display(Name = "Gênero")]
    public string Genero { get; set; }

    [StringLength(15)]
    [Display(Name = "Telefone")]
    public string TelefoneAlternativo { get; set; }

    [StringLength(200)]
    [Display(Name = "Foto de Perfil")]
    public string Foto { get; set; }

    public Endereco Endereco { get; set; }

    public Carrinho Carrinho { get; set; }
}
