using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCore7_withEF.Models
{
    public class Company
    {
        [Key]
        [Required] public Int32 PkCompany { get; set; }
        [Required][MaxLength(20)] public String Name { get; set; }
        [MaxLength(10)] public String? FkBaseCompany { get; set; }
        public Boolean? IsActive { get; set; }
        [MaxLength(20)] public String? FkUserEntity_CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        [MaxLength(20)] public String? FkUserEntity_UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
