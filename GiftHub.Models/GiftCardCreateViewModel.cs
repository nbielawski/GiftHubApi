using GiftHub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftHub.Models
{
    public class GiftCardCreateViewModel
    {
        public string CompanyName { get; set; }
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? AccessNumber { get; set; }
    }
}
