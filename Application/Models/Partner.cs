
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Models;
public class Partner
{
    public Partner(){}

    [Required(ErrorMessage = "Por favor informe o nome")]
    [DefaultValue("Tomaz Gouveia")]
    [MaxLength(40)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Por favor insira um email")]
    [RegularExpression(Constantes.RegexEmail, ErrorMessage = "Email invalido")]
    [MaxLength(50)]
    [DefaultValue("exemplo@gmail.com")]
    public string Email { get; set; }
}
