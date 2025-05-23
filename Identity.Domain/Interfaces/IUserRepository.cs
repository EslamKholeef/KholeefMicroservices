using Identity.Domain.Entities;

namespace Identity.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetByIdAsync(int id);
        Task<AppUser?> GetByEmailAsync(string email);
    }
}
