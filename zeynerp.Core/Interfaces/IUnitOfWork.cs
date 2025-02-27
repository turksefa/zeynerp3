using zeynerp.Core.Interfaces.Repositories;

namespace zeynerp.Core.Interfaces
{
    public interface IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; }
        IUserRepository UserRepository { get; }
        IInvitationRepository InvitationRepository { get; }
        Task SaveChangesAsync();
    }
}