using GiftHub.Models;

namespace GiftHub.Contracts
{
    public interface ICompanyService
    {
        bool CreateCompany(CompanyCreateViewModel model);
        CompanyDetailViewModel GetCompanyById(int companyId);
    }
}
