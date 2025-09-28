using Application.Models;
using Application.ResultPattern;

namespace Application.Interface.Data.Repository;
public interface IPartnerRepository
{
    Result InsertAsync(Partner body);
}
