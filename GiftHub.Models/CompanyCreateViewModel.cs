using System.ComponentModel.DataAnnotations;

namespace GiftHub.Models
{
    public class CompanyCreateViewModel
    {
        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }
        public int? CompanyId { get; set; }
    }
}
