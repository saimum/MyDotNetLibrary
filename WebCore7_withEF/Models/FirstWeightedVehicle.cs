using System.ComponentModel.DataAnnotations;

namespace WebCore7_withEF.Models
{
	public class FirstWeightedVehicle
	{
		[Key]
		[Required] public Int64 PkVehicleWeightTransaction { get; set; }
		[MaxLength(30)] public String? VehicleNumber { get; set; }
		public Int32 FkLocation { get; set; }
	}
}
