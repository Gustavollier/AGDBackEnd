using Application.Interface.Data.Repository;
using Application.Interface.UseCase.Partner;
using Application.ResultPattern;

namespace Application.UseCase.Partner;

public class InsertPartnerCase : IInsertPartnerCase
{
    private readonly IPartnerRepository _partnerRepository;

    public InsertPartnerCase(IPartnerRepository partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }

    public Result ExecuteAsync(Models.Partner body)
    {
        if (body is null)
            return new Result("body não pode ser nulo", false);

        Result result =  _partnerRepository.InsertAsync(body);

        return result;
    }
}
