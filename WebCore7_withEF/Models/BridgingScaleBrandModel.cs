using System.ComponentModel.DataAnnotations;

namespace WebCore7_withEF.Models
{
    public class BridgingScaleBrandModel
    {
        [Key]
        [Required] public Int32 PkBridgingScaleBrandModel { get; set; }
        [MaxLength(20)] public String? BrandModel { get; set; }
    }
}
