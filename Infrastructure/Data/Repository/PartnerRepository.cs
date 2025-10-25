using Application.Interface.Data.Repository;
using Application.Models;
using Application.ResultPattern;
using Dapper;
using Infrastructure.Data.Querys;
using System.Data;
using System.Text.Json;

namespace Infrastructure.Data.Repository;
public class PartnerRepository : IPartnerRepository
{
    private readonly DbSession _dbSession;

    public PartnerRepository(DbSession dbSession)
    {
        _dbSession = dbSession;
    }

    public async Task<Partner> GetByEmailAsync(string email)
    {
       return await _dbSession.Connection.QueryFirstOrDefaultAsync<Partner>(PartnerQuerys.GetPartnerByEmail, new { email = email});
    }

    public Task DeleteAsync(string email)
    {
        _dbSession.Connection.ExecuteAsync(PartnerQuerys.DeletePartner, new { email = email}) ;
    }

    public Task InsertAsync(Partner body)
    {
        _dbSession.Connection.ExecuteAsync(PartnerQuerys.InsertPartner, new { nome = body.Nome,email = body.Email});
    }
}
