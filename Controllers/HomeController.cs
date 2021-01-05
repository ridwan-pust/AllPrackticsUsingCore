using AllPrackticsUsingCore.DBModels;
using AllPrackticsUsingCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AllPrackticsUsingCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AllCoreContext _context;

        public HomeController(ILogger<HomeController> logger, AllCoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.DivList.OrderBy(x => x.Name).ToList());
        }

        public JsonResult getDistrict(int id)
        {
            if (id <= 0)
            {
                return Json(new { result = "failed", message = "Id cannot be zero or negative." });
            }

            var districts = _context.District.Where(x => x.DivListId == id).OrderBy(x => x.Name);
            if (districts != null && districts.Count() > 0)
            {
                return Json(new { result = "ok", message = "District data is found.", mydata = districts });
            }
            else
            {
                return Json(new { result = "failed", message = "No data found." });
            }
        }

        public JsonResult getUpazila(int id)
        {
            if (id <= 0)
            {
                return Json(new { result = "failed", message = "Id cannot be zero or negative." });
            }

            var upazila = _context.Upazila.Where(x => x.DistrictId == id).OrderBy(x => x.Name);
            if (upazila != null && upazila.Count() > 0)
            {
                return Json(new { result = "ok", message = "Upazila data is found.", mydata = upazila });
            }
            else
            {
                return Json(new { result = "failed", message = "No data found." });
            }
        }


        [HttpPost]
        public JsonResult SaveUpazila(int dsid, string upzname)
        {
            var ds = _context.District.FirstOrDefault(x => x.Id == dsid);
            if (ds == null)
            {
                return Json(new { result = "failed", message = "Sorry ! District is not found." });
            }
            if (string.IsNullOrEmpty(upzname))
            {
                return Json(new { result = "failed", message = "Sorry ! Null or Empty could not be stored." });
            }
            Upazila upz = new Upazila();
            upz.Name = upzname;
            upz.DistrictId = dsid;

            _context.Upazila.Add(upz);
            _context.SaveChanges();

            return Json(new { result = "ok", message = "Upazila info is saved successfully." });
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
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
