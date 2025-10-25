using Application.Interface.Data.Repository;
using Application.Interface.UseCase.Partner;
using Application.Models;
using Application.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.UseCase.Partner;
public class GetPartnerByEmailCase : IGetPartnerByEmailCase
{
    private readonly IPartnerRepository _partnerRepository;
    public GetPartnerByEmailCase(IPartnerRepository partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }

    public async Task<Result> ExecuteAsync(string email)
    {
        Models.Partner partner = await _partnerRepository.GetByEmailAsync(email);

        if(partner is null)
            return new Result("Parceiro não encontrado", true);

        return new Result(partner, true);
    }
}
