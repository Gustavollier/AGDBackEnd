using Application.VOs;

namespace Application.Models;
public class Partner
{
    public Partner(string nome, Email email)
    {
        Nome = nome;
        Email = email;
    }

    public string Nome { get; set; }
    public Email Email{ get; set; }
}
