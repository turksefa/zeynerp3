using zeynerp.Core.Domain.Entities;

namespace zeynerp.Application.Interfaces
{
    public interface IUserService
    {
        Task UpdateUserAsync(ApplicationUser applicationUser);
    }
}