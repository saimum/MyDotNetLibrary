using System.ComponentModel.DataAnnotations;

namespace WebCore7_withEF.Models
{
    public class BaseCompany
    {
        [Key]
        [Required]
        [MaxLength(10)]
        public String PkBaseCompany { get; set; }
    }
}
