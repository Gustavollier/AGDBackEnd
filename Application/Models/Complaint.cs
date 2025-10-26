using Application.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models;
public class Complaint
{
    [DefaultValue(EESGCategory.Environment)]
    [Required(ErrorMessage = "informe a categoria da denuncia")]
    public EESGCategory category { get; set; }

    [Required(ErrorMessage = "informe uma breve descricao da denuncia")]
    [MaxLength(200, ErrorMessage = "A descrição pode conter apenas 200 caracrteres")]
    [DefaultValue("Exemplo: foi identificado um desmatamento na avenida João de BARROS")]
    public string Description { get; set; }

    public Partner? Partner { get; set; }
}
