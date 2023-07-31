using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCore7_withEF.Models
{
    public partial class BridgingScaleMeter
    {
        [Key]
        [Required] public Int32 PkBridgingScaleMeter { get; set; }
        [MaxLength(50)] public String? Name { get; set; }
        [Required] public Int32 FkBridgingScaleBrandModel { get; set; }
        [Required] public Int32 FkLocation { get; set; }
        public Int32? FkGate { get; set; }
    }
    public partial class BridgingScaleMeter
    {
        [ForeignKey("FkBridgingScaleBrandModel")]
        public virtual BridgingScaleBrandModel BridgingScaleBrandModel { get; set; }

        [ForeignKey("FkLocation")]
        public virtual Location Location { get; set; }

        [ForeignKey("FkGate")]
        public virtual Gate Gate { get; set; }
    }
}
