using Application.Interface.Data.Repository;
using Application.Interface.UseCase.Partner;
using Application.ResultPattern;

namespace Application.UseCase.Partner;
public class DeletePartnerCase : IDeletePartnerCase
{
    private readonly IPartnerRepository _partnerRepository;

    public DeletePartnerCase(IPartnerRepository partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }

    public async Task<Result> ExecuteAsync(string email)
    {
        await _partnerRepository.DeleteAsync(email);

        return new Result("Parceiro deletado com sucesso", true);
    }
}
