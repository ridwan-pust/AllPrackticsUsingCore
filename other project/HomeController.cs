using Microsoft.Reporting.WebForms;
using RDLC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RDLC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult Report()
        {
            using (AllCoreEntities db = new AllCoreEntities())
            {
                var v = db.districts.ToList();

                return View(v);
            }
        }

        public ActionResult StudentReport()
        {
            using (AllCoreEntities db = new AllCoreEntities())
            {
                var v = db.Database.SqlQuery<sp_GetStuden_Result>("exec sp_GetStuden");

                return View(v);
            }
        }


        public ActionResult GenerateReport(string typeOfReport)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Report"), "MyFirstReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            List<district> cm = new List<district>();
            using (AllCoreEntities dc = new AllCoreEntities())
            {
                cm = dc.districts.ToList();
            }
            ReportDataSource rd = new ReportDataSource("DataSet1", cm);
            lr.DataSources.Add(rd);
            string reportType = typeOfReport;
            string mimeType;
            string encoding;
            string fileNameExtension = (typeOfReport == "Excel") ? "xlsx" : (typeOfReport == "PDF")?"pdf":"doc";

            Warning[] warning;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                "",
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warning);

            return File(renderedBytes, mimeType); 
        }
    }
}
    