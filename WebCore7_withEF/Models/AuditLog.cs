using System.ComponentModel.DataAnnotations;

namespace WebCore7_withEF.Models
{
    public class AuditLog
    {
        [Key]
        [Required] public Int64 PkAuditLog { get; set; }
        [Required] public DateTime CreatedAt { get; set; }
        [MaxLength(50)] public String? UserId { get; set; }
        public Guid? KeyGuid { get; set; }
        [MaxLength(50)] public String? Key_1 { get; set; }
        [MaxLength(50)] public String? Value_1 { get; set; }
    }
}
