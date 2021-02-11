using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MASFinalWebApp;
using MASFinalWebApp.Models;

namespace MASFinalWebApp.Controllers
{
    public class InsurancePackagesController : Controller
    {
        private readonly InsurexDbContext _context;

        public InsurancePackagesController(InsurexDbContext context)
        {
            _context = context;
        }

        // GET: InsurancePackages
        public async Task<IActionResult> Index()
        {
            return View(await _context.InsurancePackages.ToListAsync());
        }

        // GET: InsurancePackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurancePackage = await _context.InsurancePackages
                .Include(s => s.InsurancesInPackages)
                .ThenInclude(s => s.Insurances)
                .FirstOrDefaultAsync(m => m.InsurancePackageID == id);
            if (insurancePackage == null)
            {
                return NotFound();
            }

            return View(insurancePackage);
        }

        // GET: InsurancePackages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsurancePackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsurancePackageID,Name")] InsurancePackage insurancePackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insurancePackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insurancePackage);
        }

        // GET: InsurancePackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurancePackage = await _context.InsurancePackages.FindAsync(id);
            if (insurancePackage == null)
            {
                return NotFound();
            }
            return View(insurancePackage);
        }

        // POST: InsurancePackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InsurancePackageID,Name")] InsurancePackage insurancePackage)
        {
            if (id != insurancePackage.InsurancePackageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insurancePackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsurancePackageExists(insurancePackage.InsurancePackageID))
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
            return View(insurancePackage);
        }

        // GET: InsurancePackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurancePackage = await _context.InsurancePackages
                .FirstOrDefaultAsync(m => m.InsurancePackageID == id);
            if (insurancePackage == null)
            {
                return NotFound();
            }

            return View(insurancePackage);
        }

        // POST: InsurancePackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insurancePackage = await _context.InsurancePackages.FindAsync(id);
            _context.InsurancePackages.Remove(insurancePackage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsurancePackageExists(int id)
        {
            return _context.InsurancePackages.Any(e => e.InsurancePackageID == id);
        }
    }
}
