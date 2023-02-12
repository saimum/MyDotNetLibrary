using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_RDLC.Models;

namespace Web_RDLC
{
    public partial class ReportViewerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string searchText = string.Empty;

                if (Request.QueryString["searchText"] != null)
                {
                    searchText = Request.QueryString["searchText"].ToString();
                }

                List<Customer> customers = new List<Customer>() {
                new Customer(){Id=1, Name="Cusotmer 1" },
                new Customer(){Id=2, Name="Cusotmer 2" },
                new Customer(){Id=3, Name="Cusotmer 3" },
                new Customer(){Id=4, Name="Cusotmer 4" },
                new Customer(){Id=5, Name="Cusotmer 5" },
                new Customer(){Id=6, Name="Cusotmer 6" },
                new Customer(){Id=7, Name="Cusotmer 7" },
                new Customer(){Id=8, Name="Cusotmer 8" },
                new Customer(){Id=9, Name="Cusotmer 9" },
                new Customer(){Id=10, Name="Cusotmer 10" },
                };
                CustomerListReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/Report1.rdlc");
                CustomerListReportViewer.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("CustomerDataSet", customers);
                CustomerListReportViewer.LocalReport.DataSources.Add(rdc);
                CustomerListReportViewer.LocalReport.Refresh();
                CustomerListReportViewer.DataBind();
            }
        }
    }
}