using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCore7_withEF.Models
{
    public partial class UserEntity
    {
        [Key]
        [Required][MaxLength(20)] public String PkUserEntity { get; set; }
        [MaxLength(50)] public String? FullName { get; set; }
        [MaxLength(20)] public String? UserRole { get; set; }
        [Required] public Boolean IsActive { get; set; }
        public Boolean? IsActiveFromHris { get; set; }
        [MaxLength(999)] public String? Password_Encrypted { get; set; }
        public Int32? FkBridgingScaleMeter { get; set; }
    }
    public partial class UserEntity
    {
        [ForeignKey("FkBridgingScaleMeter")]
        public virtual BridgingScaleMeter BridgingScaleMeter { get; set; }

    }
}
