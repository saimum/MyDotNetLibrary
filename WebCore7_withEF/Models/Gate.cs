using System.ComponentModel.DataAnnotations;

namespace WebCore7_withEF.Models
{
    public class Gate
    {
        [Key]
        [Required] public Int32 PkGate { get; set; }
        [Required] public Int32 FkLocation { get; set; }
        [Required][MaxLength(20)] public String Name { get; set; }
    }
}
