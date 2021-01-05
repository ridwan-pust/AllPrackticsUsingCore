using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllPrackticsUsingCore.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Create(List<Course> courses)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(Member member)
        {
            if (ModelState.IsValid)
            {
                //_context.AddRange(member);
                //await _context.SaveChangesAsync();

                //return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
    }
}
