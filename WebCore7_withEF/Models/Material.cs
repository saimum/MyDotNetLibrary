using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCore7_withEF.Models
{
    public partial class Material
    {
        [Key]
        [Required] public Int32 PkMaterial { get; set; }
        [Required] public Int32 FkLocation { get; set; }
        [Required][MaxLength(50)] public String Name { get; set; }
        public Boolean? IsActive { get; set; }
        [MaxLength(20)] public String? FkUserEntity_CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        [MaxLength(20)] public String? FkUserEntity_UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
   
    public partial class Material
    {
        [ForeignKey("FkLocation")]
        public virtual Location Location { get; set; }
    }
}
