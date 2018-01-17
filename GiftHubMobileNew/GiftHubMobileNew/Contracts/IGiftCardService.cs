using GiftHub.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GiftHubMobileNew.Contracts
{
    public interface IGiftCardService
    {
        Task<bool> Login(string username, string password);

        Task<bool> AddNew(GiftCardCreateViewModel card);
    }
}
