
using Application.ResultPattern;

namespace Application.Interface.UseCase.Partner;
public interface IDeletePartnerCase
{
    Result Execute(string email);
}
