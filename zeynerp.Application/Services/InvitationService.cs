using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using zeynerp.Application.Interfaces;
using zeynerp.Core.Domain.Entities;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services
{
    public class InvitationService : IInvitationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        public InvitationService(IUnitOfWork unitOfWork, IEmailSender emailSender, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _configuration = configuration;
        }

        public async Task<bool> SendInvitationAsync(Guid companyId, string email)
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

                var baseUrl = _configuration["ApplicationUrl"];
                var invitationUrl = $"{baseUrl}/invitation/{invitation.Token}";
                await _emailSender.SendEmailAsync(email, "Invitation to join company",
                    $"You have been invited to join {company.Name}. Please accept the invitation by <a href='{invitationUrl}'>clicking here</a>.");
            };
            
            return true;
        }
    }
}