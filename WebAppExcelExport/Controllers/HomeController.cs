﻿using ClosedXML.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppExcelExport.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public FileResult ExportXL_ClosedXML()
        {
            DataTable dt = new DataTable("sheet1");
            dt.Columns.Add("Col_1", typeof(string));
            dt.Columns.Add("Col_2", typeof(string));
            dt.Columns.Add("Col_3", typeof(int));
            dt.Columns.Add("Col_4", typeof(int));
            dt.Columns.Add("Col_5", typeof(int));
            dt.Columns.Add("Col_6", typeof(int));

            for (int i = 0; i < 100; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "data  a";
                dr[1] = i * 10;
                dr[2] = i * 10;
                dr[3] = i * 10;
                dr[4] = i * 10;
                dr[5] = i * 10;
                dt.Rows.Add(dr);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "file_name_ClosedXML.xlsx");
                }
            }
        }

        public ActionResult ExportXL_EPP()
        {
            try
            {
                DataTable dt = new DataTable("sheet1");
                dt.Columns.Add("Col_1", typeof(string));
                dt.Columns.Add("Col_2", typeof(string));
                dt.Columns.Add("Col_3", typeof(int));
                dt.Columns.Add("Col_4", typeof(int));
                dt.Columns.Add("Col_5", typeof(int));
                dt.Columns.Add("Col_6", typeof(int));

                for (int i = 0; i < 100; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = "data  a";
                    dr[1] = i * 10;
                    dr[2] = i * 10;
                    dr[3] = i * 10;
                    dr[4] = i * 10;
                    dr[5] = i * 10;
                    dt.Rows.Add(dr);
                }

                var memoryStream = new MemoryStream();
                using (var excelPackage = new ExcelPackage(memoryStream))
                {
                    var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells["A1"].LoadFromDataTable(dt, true, TableStyles.None);
                    return File(excelPackage.GetAsByteArray(), "application/octet-stream", "file_name_EPP.xlsx");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}