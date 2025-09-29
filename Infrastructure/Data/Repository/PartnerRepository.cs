using Application.Interface.Data.Repository;
using Application.Models;
using Application.ResultPattern;
using Infrastructure.Data.Querys;
using System.Data;

namespace Infrastructure.Data.Repository;
public class PartnerRepository : IPartnerRepository
{
    private readonly DbSession _dbSession;

    public PartnerRepository(DbSession dbSession)
    {
        _dbSession = dbSession;
    }

    public Result InsertAsync(Partner body)
    {
        using IDbCommand command = _dbSession.Connection.CreateCommand();

        command.CommandText = PartnerQuerys.InsertPartner;

        var nomeParameter = command.CreateParameter();
        nomeParameter.ParameterName = "@nome";
        nomeParameter.Value = body.Nome;
        command.Parameters.Add(nomeParameter);

        var emailParameter = command.CreateParameter();
        emailParameter.ParameterName = "@email";
        emailParameter.Value = body.Email.Value;
        command.Parameters.Add(emailParameter);

        command.ExecuteNonQuery();

        return new Result("Parceiro inserido com sucesso", true);
    }
}
