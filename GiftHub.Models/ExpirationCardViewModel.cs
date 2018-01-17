using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftHub.Models
{
    public class ExpirationCardViewModel
    {
        public int GiftCardId { get; set; }
        public string CompanyName { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
