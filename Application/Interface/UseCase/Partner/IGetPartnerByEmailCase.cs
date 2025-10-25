using Application.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.UseCase.Partner;
public interface IGetPartnerByEmailCase
{
    Task<Result> ExecuteAsync(string email);
}
