using AutoMapper;
using zeynerp.Application.Interfaces;
using zeynerp.Core.Domain.Entities;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services
{
    public class InvitationService : IInvitationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvitationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> SendInvitationAsync(Guid companyId, string email, string token)
        {
            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(companyId);
            if (company == null)
                return false;
            
            var existingInvitation = await _unitOfWork.InvitationRepository.GetByEmailAndCompanyAsync(email, companyId);
            if (existingInvitation == null)
            {
                var invitation = new Invitation
                {
                    CompanyId = companyId,
                    Email = email,
                    Token = Guid.NewGuid(),
                    IsAccepted = false
                };

                await _unitOfWork.InvitationRepository.AddAsync(invitation);
                await _unitOfWork.SaveChangesAsync();
            }
            return true;
        }
    }
}