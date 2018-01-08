using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiftHub.Data
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public decimal CompanyAmount { get; set; }

        public virtual ICollection<GiftCard> GiftCards { get; set; }
    }
}
