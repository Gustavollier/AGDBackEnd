using Application.Models;
using Application.ResultPattern;

namespace Application.Interface.UseCase.Partner;
public interface IInsertPartnerCase
{
    Result ExecuteAsync(Models.Partner partner);
}
