using System.Text.RegularExpressions;
namespace Application.VOs;

public class Email
{
    public Email(string value)
    {
        if (!ValidarEmail(value)) 
            throw new Exception("Email não é valido por favor revise o campo");
        
        Value = value;    
    }
    public string Value { get; private set; }

    private bool ValidarEmail(string value)
    {
        return Regex.IsMatch(value, Constantes.RegexEmail);
    }
}
