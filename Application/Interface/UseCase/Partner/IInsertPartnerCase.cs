using Application.Models;
using Application.ResultPattern;

namespace Application.Interface.UseCase.Partner;
public interface IInsertPartnerCase
{
    Task<Result> ExecuteAsync(Models.Partner partner);
}
