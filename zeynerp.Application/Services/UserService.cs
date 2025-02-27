using zeynerp.Application.Interfaces;
using zeynerp.Core.Domain.Entities;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task UpdateUserAsync(ApplicationUser applicationUser)
        {
            _unitOfWork.UserRepository.Update(applicationUser);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}