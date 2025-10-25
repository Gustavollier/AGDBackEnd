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

    public Result Execute(string email)
    {
        _partnerRepository.Delete(email);

        return new Result("Parceiro deletado com sucesso", true);
    }
}
