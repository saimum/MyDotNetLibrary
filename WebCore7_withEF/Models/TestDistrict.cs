using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCore7_withEF.Models
{
    public partial class TestDistrict
    {
        [Key]
        [Required] public Int32 PkTestDistrict { get; set; }
        [Required] public Int32 FkTestDivision { get; set; }
        [Required][MaxLength(50)] public String Name { get; set; }
        [Required] public Boolean IsActive { get; set; }
        public Int32? Data_Int { get; set; }
        public DateTime? Data_DateTime { get; set; }
        [Column(TypeName = "decimal(18,2 )")] public Decimal? Date_Decimal { get; set; }
        public Guid? Data_Uniqueidentifier { get; set; }
    }
    public partial class TestDistrict
    {
        [ForeignKey("FkTestDivision")]
        public virtual TestDivision TestDivision { get; set; }
    }
}
