using Application.Models;

namespace Application.Interface.Data.Repository;
public interface IPartnerRepository
{
    void Delete(string email);
    void Insert(Partner body);
    Task<Partner?> GetByEmailAsync(string email);
}
