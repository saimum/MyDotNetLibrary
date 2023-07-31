using System.ComponentModel.DataAnnotations;

namespace WebCore7_withEF.Models
{
    public class TestDivision
    {
        [Key]
        [Required] public Int32 PkTestDivision { get; set; }
        [Required][MaxLength(50)] public String Name { get; set; }
        [Required] public Boolean IsActive { get; set; }
    }
}
