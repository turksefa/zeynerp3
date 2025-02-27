using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Domain.Entities;
using zeynerp.Core.Interfaces.Repositories;
using zeynerp.Infrastructure.Persistence.Data;
using zeynerp.Infrastructure.Persistence.Repositories.Base;

namespace zeynerp.Infrastructure.Persistence.Repositories
{
    public class InvitationRepository : Repository<Invitation>, IInvitationRepository
    {
        public InvitationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Invitation?> GetByEmailAndCompanyAsync(string email, Guid companyId) =>
            await _context.Invitations.FirstOrDefaultAsync(i => i.Email == email && i.CompanyId == companyId);

        public async Task<Invitation?> GetByTokenAsync(Guid token) =>
            await _context.Invitations.FirstOrDefaultAsync(i => i.Token == token);
    }
}