using GiftHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftHub.Contracts
{
    public interface IGiftCardService
    {
        IEnumerable<GiftCardViewModel> GetCards();
        bool CreateGiftCard(GiftCardCreateViewModel model);
    }
}
