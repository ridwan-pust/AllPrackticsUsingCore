using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AllPrackticsUsingCore.Data;
using AllPrackticsUsingCore.Models;

namespace AllPrackticsUsingCore.Controllers
{
    public class BedInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BedInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BedInformations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BedInformation.Include(b => b.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BedInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedInformation = await _context.BedInformation
                .Include(b => b.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bedInformation == null)
            {
                return NotFound();
            }

            return View(bedInformation);
        }

        // GET: BedInformations/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name");
            return View();
        }

        // POST: BedInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( BedInformation bedInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bedInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name", bedInformation.StudentId);
            return View(bedInformation);
        }

        // GET: BedInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedInformation = await _context.BedInformation.FindAsync(id);
            if (bedInformation == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name", bedInformation.StudentId);
            return View(bedInformation);
        }

        // POST: BedInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,EnrolementDate,Description,Rent,Partial,StudentId")] BedInformation bedInformation)
        {
            if (id != bedInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bedInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BedInformationExists(bedInformation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name", bedInformation.StudentId);
            return View(bedInformation);
        }

        // GET: BedInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedInformation = await _context.BedInformation
                .Include(b => b.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bedInformation == null)
            {
                return NotFound();
            }

            return View(bedInformation);
        }

        // POST: BedInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bedInformation = await _context.BedInformation.FindAsync(id);
            _context.BedInformation.Remove(bedInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BedInformationExists(int id)
        {
            return _context.BedInformation.Any(e => e.Id == id);
        }
    }
}
