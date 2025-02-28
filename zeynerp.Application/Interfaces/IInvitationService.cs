namespace zeynerp.Application.Interfaces
{
    public interface IInvitationService
    {
        Task<bool> SendInvitationAsync(Guid companyId, string email);
    }
}