
using Application.ResultPattern;

namespace Application.Interface.UseCase.Partner;
public interface IDeletePartnerCase
{
    Task<Result> ExecuteAsync(string email);
}
