using Application.Models;

namespace Application.Interface.Data.Repository;
public interface IPartnerRepository
{
    Task DeleteAsync(string email);
    Task InsertAsync(Partner body);
    Task<Partner?> GetByEmailAsync(string email);
}
