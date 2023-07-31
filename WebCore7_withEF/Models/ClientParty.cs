using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCore7_withEF.Models
{
    public partial class ClientParty
    {
        [Key]
        [Required] public Int32 PkClientParty { get; set; }
        [Required] public Int32 FkLocation { get; set; }
        [Required][MaxLength(30)] public String Name { get; set; }
        public Boolean? IsActive { get; set; }
        [Required][MaxLength(20)] public String ClientType { get; set; }
        [Required][MaxLength(30)] public String CompanyName { get; set; }
        [Required][MaxLength(50)] public String Address { get; set; }
        [Required][MaxLength(11)] public String ContactNumberPrimary { get; set; }
        [MaxLength(30)] public String? Email { get; set; }
        [MaxLength(20)] public String? FkUserEntity_CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        [MaxLength(20)] public String? FkUserEntity_UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public partial class ClientParty
    {
        [ForeignKey("FkLocation")]
        public virtual Location Location { get; set; }
    }

}
