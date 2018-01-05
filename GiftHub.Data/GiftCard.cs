using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftHub.Data
{
    public class GiftCard
    {
        [Key]
        public int GiftCardId { get; set; }
        public Guid OwnerId { get; set; }
        public int CompanyId { get; set; }
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? AccessNumber { get; set; }
        public DateTimeOffset DonationUtc { get; set; }

        public virtual Company Company { get; set; }
    }
}
