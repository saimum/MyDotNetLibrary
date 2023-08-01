using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using WebCoreWithRDLC.Models;

namespace WebCoreWithRDLC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnv;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnv)
        {
            _logger = logger;
            _webHostEnv = webHostEnv;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EmployeeSalaryInfo()
        {
            var dt = new DataTable();
            dt.Columns.Add("EmployeeName", typeof(string));
            dt.Columns.Add("Salary", typeof(string));
            dt.Columns.Add("Department", typeof(string));

            // Add rows with fake data
            for (int i = 0; i < 100; i++)
            {
                dt.Rows.Add("John Doe", "5000", "Finance");
                dt.Rows.Add("Jane Smith", "6000", "Human Resources");
                dt.Rows.Add("Mike Johnson", "4500", "Marketing");
                dt.Rows.Add("Sarah Thompson", "5500", "IT");
                dt.Rows.Add("David Lee", "7000", "Sales");
            }

            string mimeType = "";
            int extension = 1;
            var path = $"{_webHostEnv.WebRootPath}\\ReportFormats\\rptEmpSalaryInfo.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "prm1", "RDLC Report" },
                { "prm2", DateTime.Now.ToString("dd-MMM-yyyy") },
                { "prm3", "Employee Salary Report" }
            };

            //Add Path
            LocalReport localReport = new LocalReport(path);

            localReport.AddDataSource("DataSet1", dt);

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var res = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);

            return File(res.MainStream, "application/pdf");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}