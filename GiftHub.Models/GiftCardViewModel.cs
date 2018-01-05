using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftHub.Models
{
    public class GiftCardViewModel
    {
        public string CompanyName { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset DonationUtc { get; set; }
    }
}
