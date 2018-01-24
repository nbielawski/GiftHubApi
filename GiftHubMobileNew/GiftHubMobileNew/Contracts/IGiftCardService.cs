using GiftHub.Models;
using GiftHubMobileNew.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GiftHubMobileNew.Contracts
{
    public interface IGiftCardService
    {
        Task<bool> Login(string username, string password);

        Task<List<GiftCardViewModel>> GetAll();

        Task<bool> MakeDonationAsync(GiftCardCreateViewModel card);

        Task<List<CompanyDropDown>> GetCompanies();

    }
}
