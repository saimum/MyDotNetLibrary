using System.ComponentModel.DataAnnotations;

namespace WebCore7_withEF.Models
{
    public class Location
    {
        [Key]
        [Required] public Int32 PkLocation { get; set; }
        [Required][MaxLength(20)] public String Name { get; set; }
        [MaxLength(50)] public String? LocationDetail_1 { get; set; }
        [MaxLength(50)] public String? LocationDetail_2 { get; set; }
    }
}
