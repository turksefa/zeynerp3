using AutoMapper;
using zeynerp.Application.DTOs.Company;
using zeynerp.Application.Interfaces;
using zeynerp.Core.Domain.Entities;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CompanyDto> CreateCompanyAsync(CompanyDto companyDto)
        {          
            var company = await _unitOfWork.CompanyRepository.AddAsync(_mapper.Map<Company>(companyDto));
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CompanyDto>(company);
        }
    }
}