using Application.Interface.Data.Repository;
using Application.Interface.UseCase.Complaint;
using Application.ResultPattern;

namespace Application.UseCase.Complaint;
public class InsertComplaintCase : IInsertComplaintCase
{
    private readonly IComplaintRepository _complaintRepository;
    private readonly IPartnerRepository _partnerRepository;

    public InsertComplaintCase(IComplaintRepository complaintRepository, IPartnerRepository partnerRepository)
    {
        _complaintRepository = complaintRepository;
        _partnerRepository = partnerRepository;
    }

    public async Task<Result> ExecuteAsync(Models.Complaint complaint)
    {
        if(complaint.Partner is null)
            return await InsertComplaint(complaint);
        else
            return await InsertComplaintWithPartner(complaint);
    }

    private async Task<Result> InsertComplaint(Models.Complaint complaint)
    {
        await _complaintRepository.InsertAsync(complaint);

        return new Result("Denuncia criada com sucesso", true);
    }

    private async Task<Result> InsertComplaintWithPartner(Models.Complaint complaint)
    {
        if (await _partnerRepository.GetByEmailAsync(complaint.Partner.Email) is  null)
            return new Result("Parceiro inválido para esta denúncia", false);

        await _complaintRepository.InsertWithPartnerAsync(complaint);

        return new Result("Denuncia criada com sucesso", true);
    }
}
