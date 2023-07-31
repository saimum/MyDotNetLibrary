using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCore7_withEF.Models
{
    public partial class VW_VehicleWeightTransaction_Detail
    {
        [Key]
        [Required] public Int64 vehicleWeightTransactionId { get; set; }
        [MaxLength(30)] public String? VehicleNumber { get; set; }
        public Int32? FkCompany { get; set; }
        [MaxLength(10)] public String? FirstWeightType { get; set; }
        public Int32? FkMaterial { get; set; }
        public Int32? FkClientParty { get; set; }
        public Int32? FkBridgingScaleMeter_First { get; set; }
        [MaxLength(10)] public String? FkUserEntity_First { get; set; }
        public Int32? Weight_First { get; set; }
        [MaxLength(50)] public String? DriverInfo_First { get; set; }
        [MaxLength(15)] public String? DriverPhoneNumber_First { get; set; }
        [MaxLength(50)] public String? HelperInfo_First { get; set; }
        [MaxLength(30)] public String? DeviceId_First { get; set; }
        [MaxLength(8000)] public String? EntryDatetime_First { get; set; }
        [MaxLength(10)] public String? EntryType_First { get; set; }
        [MaxLength(50)] public String? AppDevNote_First { get; set; }
        public Int32? FkBridgingScaleMeter_Second { get; set; }
        [MaxLength(10)] public String? FkUserEntity_Second { get; set; }
        public Int32? Weight_Second { get; set; }
        [MaxLength(50)] public String? DriverInfo_Second { get; set; }
        [MaxLength(15)] public String? DriverPhoneNumber_Second { get; set; }
        [MaxLength(50)] public String? HelperInfo_Second { get; set; }
        [MaxLength(30)] public String? DeviceId_Second { get; set; }
        [MaxLength(8000)] public String? EntryDatetime_Second { get; set; }
        [MaxLength(10)] public String? EntryType_Second { get; set; }
        [MaxLength(50)] public String? AppDevNote_Second { get; set; }
        public Int32? WeightDifference { get; set; }
        [MaxLength(30)] public String? ShortStatus { get; set; }
        [Required][MaxLength(20)] public String CompanyName { get; set; }
        [Required][MaxLength(50)] public String MaterialName { get; set; }
        [Required][MaxLength(30)] public String ClientPartyName { get; set; }
        [MaxLength(50)] public String? entryGivenBy_First { get; set; }
        [MaxLength(50)] public String? entryGivenBy_Second { get; set; }
        [Required] public Int32 LastColumn { get; set; }
    }
}
