using zeynerp.Core.Domain.Entities;
using zeynerp.Core.Interfaces.Repositories;
using zeynerp.Infrastructure.Persistence.Data;
using zeynerp.Infrastructure.Persistence.Repositories.Base;

namespace zeynerp.Infrastructure.Persistence.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}