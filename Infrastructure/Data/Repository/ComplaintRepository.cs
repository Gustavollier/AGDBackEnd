using Application.Interface.Data.Repository;
using Application.Models;
using Dapper;
using Infrastructure.Data.Querys;

namespace Infrastructure.Data.Repository;

public class ComplaintRepository : IComplaintRepository
{
    private readonly DbSession _session;

    public ComplaintRepository(DbSession session)
    {
        _session = session;
    }

    public async Task InsertWithPartnerAsync(Complaint complaint)
    {
        await _session.Connection.ExecuteAsync(ComplaintQuerys.InsertComplaintWithPartner,
            new { category = complaint.Category, description = complaint.Description, emailPartner = complaint.Partner.Email });
    }
    public async Task InsertAsync(Complaint complaint)
    {
        await _session.Connection.ExecuteAsync(ComplaintQuerys.InsertComplaint,
            new { category = complaint.Category, description = complaint.Description });
    }
}
