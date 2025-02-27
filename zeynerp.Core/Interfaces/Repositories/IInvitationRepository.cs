using zeynerp.Core.Domain.Entities;
using zeynerp.Core.Interfaces.Repositories.Base;

namespace zeynerp.Core.Interfaces.Repositories
{
    public interface IInvitationRepository : IRepository<Invitation>
    {
        Task<Invitation?> GetByTokenAsync(Guid token);
        Task<Invitation?> GetByEmailAndCompanyAsync(string email, Guid companyId);
    }
}