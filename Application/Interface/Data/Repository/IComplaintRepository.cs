using Application.Models;

namespace Application.Interface.Data.Repository;

public interface IComplaintRepository
{
    Task InsertWithPartnerAsync(Complaint complaint);
    Task InsertAsync(Complaint complaint);
}
