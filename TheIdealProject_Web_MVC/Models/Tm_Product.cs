//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheIdealProject_Web_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TM_Product
    {
        public long TM_ProductPk { get; set; }
        public long TL_ProductFk { get; set; }
        public string Product_DevelperNote { get; set; }
        public long Product_TM_SubCategoryFk { get; set; }
        public long Product_TL_SubCategoryFk { get; set; }
        public Nullable<bool> Product_IsActive { get; set; }
        public Nullable<bool> Product_IsViewable { get; set; }
        public Nullable<bool> Product_IsDeleted { get; set; }
        public string Product_Code { get; set; }
        public string Product_Name { get; set; }
        public Nullable<long> Product_Price { get; set; }
        public Nullable<long> Product_TM_UserFk_Creator_Nt { get; set; }
        public Nullable<System.DateTime> Product_CreatedAt_Nt { get; set; }
        public Nullable<long> Product_TM_UserFk_Modifier_Nt { get; set; }
        public Nullable<System.DateTime> Product_ModifiedAt_Nt { get; set; }
    }
}
