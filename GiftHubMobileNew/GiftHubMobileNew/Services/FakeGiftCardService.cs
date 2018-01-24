using GiftHub.Models;
using GiftHubMobileNew.Contracts;
using GiftHubMobileNew.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GiftHubMobileNew.Services
{
    internal class FakeGiftCardService : IGiftCardService
    {
        public Task<bool> MakeDonationAsync(GiftCardCreateViewModel card)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Login(string username, string password)
        {
            return true;
        }

        public Task<List<GiftCardViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyDropDown>> GetCompanies()
        {
            throw new NotImplementedException();
        }
    }
}
