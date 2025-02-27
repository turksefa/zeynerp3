using zeynerp.Core.Domain.Entities;

namespace zeynerp.Application.Interfaces
{
    public interface IInvitationService
    {
        Task<bool> SendInvitationAsync(Guid companyId, string email, string token);
    }
}