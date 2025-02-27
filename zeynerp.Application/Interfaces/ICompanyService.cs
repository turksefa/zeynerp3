using zeynerp.Application.DTOs.Company;

namespace zeynerp.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyDto> CreateCompanyAsync(CompanyDto companyDto);
    }
}