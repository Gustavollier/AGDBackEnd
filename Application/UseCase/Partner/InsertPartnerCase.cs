using Application.Interface.Data.Repository;
using Application.Interface.UseCase.Partner;
using Application.Models;
using Application.ResultPattern;

namespace Application.UseCase.Partner;

public class InsertPartnerCase : IInsertPartnerCase
{
    private readonly IPartnerRepository _partnerRepository;
    private readonly IGetPartnerByEmailCase _getPartnerByEmailCase;
    public InsertPartnerCase(IPartnerRepository partnerRepository, IGetPartnerByEmailCase getPartnerByEmailCase)
    {
        _partnerRepository = partnerRepository;
        _getPartnerByEmailCase = getPartnerByEmailCase;
    }

    public async Task<Result> ExecuteAsync(Models.Partner body)
    {
        if (body is null)
            return new Result("body não pode ser nulo", false);

        if (await _partnerRepository.GetByEmailAsync(body.Email) is not null)
            return new Result("Já existe um parceiro com o email informado", false);

        _partnerRepository.Insert(body);

        return new Result("Perceiro inserido com sucesso",true);
    }
}
