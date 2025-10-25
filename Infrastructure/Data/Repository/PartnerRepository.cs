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

    public void Delete(string email)
    {
        _dbSession.Connection.Execute(PartnerQuerys.DeletePartner, new { email = email}) ;
    }

    public void Insert(Partner body)
    {
        _dbSession.Connection.Execute(PartnerQuerys.InsertPartner, new { nome = body.Nome,email = body.Email});
    }
}
