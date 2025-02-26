using zeynerp.Core.Domain.Entities;
using zeynerp.Core.Repositories;
using zeynerp.Infrastructure.Persistence.Data;
using zeynerp.Infrastructure.Persistence.Repositories.Base;

namespace zeynerp.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}