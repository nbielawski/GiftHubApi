using System;
using System.Collections.Generic;
using System.Text;

namespace GiftHubMobileNew.Models
{
    internal class GiftCardCreate
    {
        public string CompanyName { get; set; }
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? AccessNumber { get; set; }
    }
}
