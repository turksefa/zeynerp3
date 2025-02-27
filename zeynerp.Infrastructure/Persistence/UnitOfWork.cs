using zeynerp.Core.Interfaces;
using zeynerp.Core.Interfaces.Repositories;
using zeynerp.Infrastructure.Persistence.Data;

namespace zeynerp.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IInvitationRepository _invitationRepository;

        public UnitOfWork(ApplicationDbContext context, ICompanyRepository companyRepository, IUserRepository userRepository, IInvitationRepository invitationRepository)
        {
            _context = context;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
            _invitationRepository = invitationRepository;
        }

        public ICompanyRepository CompanyRepository => _companyRepository;

        public IUserRepository UserRepository => _userRepository;

        public IInvitationRepository InvitationRepository => _invitationRepository;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}