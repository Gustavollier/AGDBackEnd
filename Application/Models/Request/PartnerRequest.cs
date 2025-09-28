using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request;
public class PartnerRequest
{
    [Required(ErrorMessage = "Informe o nome")]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Informe o email")]
    [MaxLength(100)]
    public string Email { get; set; }
}
