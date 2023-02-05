using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheIdealProject_CoreWebMVC.Controllers
{
    public class ReportController : Controller
    {
        //public IActionResult Index(
        // string VehicleWeightTransaction_StartingDate = "",
        // string VehicleWeightTransaction_EndingDate = "",
        // string BridgingScaleMeter_First_FkLocation = "",
        // string VehicleWeightTransaction_FkCompany = "",
        // string VehicleWeightTransaction_FkMaterial = "",
        // string VehicleWeightTransaction_VehicleNumber = ""
        // )
        //{
        //    ViewBag.FkLocation = new SelectList(mainDb.Location, "PkLocation", "Name", BridgingScaleMeter_First_FkLocation);
        //    ViewBag.FkCompany = new SelectList(mainDb.Company, "PkCompany", "Name", VehicleWeightTransaction_FkCompany);
        //    ViewBag.FkMaterial = new SelectList(mainDb.Material, "PkMaterial", "Name", VehicleWeightTransaction_FkMaterial);


        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    if (!VehicleWeightTransaction_StartingDate.IsNullOrEmpty())
        //    {
        //        parameters.Add(new SqlParameter("@VehicleWeightTransaction_StartingDate", VehicleWeightTransaction_StartingDate));
        //    }
        //    if (!@VehicleWeightTransaction_EndingDate.IsNullOrEmpty())
        //    {
        //        parameters.Add(new SqlParameter("@VehicleWeightTransaction_EndingDate", VehicleWeightTransaction_EndingDate));
        //    }
        //    if (!BridgingScaleMeter_First_FkLocation.IsNullOrEmpty())
        //    {
        //        parameters.Add(new SqlParameter("@BridgingScaleMeter_First_FkLocation", BridgingScaleMeter_First_FkLocation));
        //    }
        //    if (!VehicleWeightTransaction_FkCompany.IsNullOrEmpty())
        //    {
        //        parameters.Add(new SqlParameter("@VehicleWeightTransaction_FkCompany", VehicleWeightTransaction_FkCompany));
        //    }
        //    if (!VehicleWeightTransaction_FkMaterial.IsNullOrEmpty())
        //    {
        //        parameters.Add(new SqlParameter("@VehicleWeightTransaction_FkMaterial", VehicleWeightTransaction_FkMaterial));
        //    }
        //    if (!VehicleWeightTransaction_VehicleNumber.IsNullOrEmpty())
        //    {
        //        parameters.Add(new SqlParameter("@VehicleWeightTransaction_VehicleNumber", VehicleWeightTransaction_VehicleNumber));
        //    }

        //    var data = SpToDictionaryConverter.Convert(mainDb.Database.GetDbConnection(), "MYSP_GetVehicleWeightTransactionDetailList", parameters);
        //    return View(data);
        //}

        #region
  
//alter PROCEDURE[dbo].[MYSP_GetVehicleWeightTransactionDetailList]
//        (
//@VehicleWeightTransaction_StartingDate datetime=null,
//@VehicleWeightTransaction_EndingDate datetime = null,
//@BridgingScaleMeter_First_FkLocation int=null,
//@VehicleWeightTransaction_FkCompany int=null,
//@VehicleWeightTransaction_FkMaterial int=null,
//@VehicleWeightTransaction_VehicleNumber varchar(20)=null
//)
//AS
//select 0 as FirstColumn
//,VehicleWeightTransaction.*
//,VehicleWeightTransaction.PkVehicleWeightTransaction as 'vehicleWeightTransactionId'
//,FORMAT(VehicleWeightTransaction.EntryDatetime_First, 'dd/MM/yy HH:mm tt') as EntryDatetime_First_Formatted
//,FORMAT(VehicleWeightTransaction.EntryDatetime_Second, 'dd/MM/yy HH:mm tt') as EntryDatetime_Second_Formatted

//--Common
//,Company.Name as CompanyName
//,Material.Name as MaterialName
//,ClientParty.Name as ClientPartyName

//--First
//,BridgingScaleMeter_First.Name as BridgingScaleMeter_First_Name
//,BridgingScaleMeter_Second.Name as BridgingScaleMeter_Second_Name

//--End
//,UserEntity_First.FullName as UserEntity_First_FullName
//,UserEntity_Second.FullName as UserEntity_Second_FullName

//,0 as LastColumn
//from VehicleWeightTransaction
//--Common
//join Company on VehicleWeightTransaction.FkCompany = Company.PkCompany
//join Material on VehicleWeightTransaction.FkMaterial = Material.PkMaterial
//join ClientParty on VehicleWeightTransaction.FkClientParty = ClientParty.PkClientParty

//--First
//join UserEntity as UserEntity_First on VehicleWeightTransaction.FkUserEntity_First = UserEntity_First.PkUserEntity
//join BridgingScaleMeter BridgingScaleMeter_First on VehicleWeightTransaction.FkBridgingScaleMeter_First = BridgingScaleMeter_First.PkBridgingScaleMeter
//join Location BridgingScaleMeter_First_Location on BridgingScaleMeter_First.FkLocation = BridgingScaleMeter_First_Location.PkLocation

//--Second
//left join UserEntity as UserEntity_Second on VehicleWeightTransaction.FkUserEntity_Second = UserEntity_Second.PkUserEntity
//left join BridgingScaleMeter BridgingScaleMeter_Second on VehicleWeightTransaction.FkBridgingScaleMeter_Second = BridgingScaleMeter_Second.PkBridgingScaleMeter
//left join Location BridgingScaleMeter_Second_Location on BridgingScaleMeter_Second.FkLocation = BridgingScaleMeter_Second_Location.PkLocation


//where 1=1
//AND (@VehicleWeightTransaction_StartingDate is null OR VehicleWeightTransaction.EntryDatetime_First >= @VehicleWeightTransaction_StartingDate)
//AND(@VehicleWeightTransaction_EndingDate is null OR VehicleWeightTransaction.EntryDatetime_First<@VehicleWeightTransaction_EndingDate)
//AND(@BridgingScaleMeter_First_FkLocation is null OR BridgingScaleMeter_First.FkLocation = @BridgingScaleMeter_First_FkLocation)
//AND(@VehicleWeightTransaction_FkCompany is null OR VehicleWeightTransaction.FkCompany<@VehicleWeightTransaction_FkCompany)
//AND(@VehicleWeightTransaction_FkMaterial is null OR VehicleWeightTransaction.FkMaterial<@VehicleWeightTransaction_FkMaterial)
//AND((@VehicleWeightTransaction_VehicleNumber is null) OR(VehicleWeightTransaction.VehicleNumber like '%'+@VehicleWeightTransaction_VehicleNumber+'%'))



        #endregion

    }
}
