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
    public class InsuranceAgreementsController : Controller
    {
        private readonly InsurexDbContext _context;

        public InsuranceAgreementsController(InsurexDbContext context)
        {
            _context = context;
        }

        // GET: InsuranceAgreements
        public async Task<IActionResult> Index()
        {
            var insurexDbContext = _context.InsuranceAgreements.Include(i => i.Client).Include(i => i.Insurance).Include(i => i.InsurancePackage);
            return View(await insurexDbContext.ToListAsync());
        }

        // GET: InsuranceAgreements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceAgreement = await _context.InsuranceAgreements
                .Include(i => i.Client)
                .Include(i => i.Insurance)
                .Include(i => i.InsurancePackage)
                .FirstOrDefaultAsync(m => m.InsuranceID == id);
            if (insuranceAgreement == null)
            {
                return NotFound();
            }

            return View(insuranceAgreement);
        }

        // GET: InsuranceAgreements/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clients, "PersonID", "PersonID");
            ViewData["InsuranceID"] = new SelectList(_context.Insurances, "InsuranceID", "InsuranceID");
            ViewData["InsurancePackageID"] = new SelectList(_context.InsurancePackages, "InsurancePackageID", "InsurancePackageID");
            return View();
        }

        // POST: InsuranceAgreements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsuranceAgreementID,Price,BuyDate,State,DateFrom,DateTo,AdditionalInfo,InsuranceID,InsurancePackageID,ClientID,InvoiceID")] InsuranceAgreement insuranceAgreement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuranceAgreement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "PersonID", "PersonID", insuranceAgreement.ClientID);
            ViewData["InsuranceID"] = new SelectList(_context.Insurances, "InsuranceID", "InsuranceID", insuranceAgreement.InsuranceID);
            ViewData["InsurancePackageID"] = new SelectList(_context.InsurancePackages, "InsurancePackageID", "InsurancePackageID", insuranceAgreement.InsurancePackageID);
            return View(insuranceAgreement);
        }

        // GET: InsuranceAgreements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceAgreement = await _context.InsuranceAgreements.FindAsync(id);
            if (insuranceAgreement == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "PersonID", "PersonID", insuranceAgreement.ClientID);
            ViewData["InsuranceID"] = new SelectList(_context.Insurances, "InsuranceID", "InsuranceID", insuranceAgreement.InsuranceID);
            ViewData["InsurancePackageID"] = new SelectList(_context.InsurancePackages, "InsurancePackageID", "InsurancePackageID", insuranceAgreement.InsurancePackageID);
            return View(insuranceAgreement);
        }

        // POST: InsuranceAgreements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("InsuranceAgreementID,Price,BuyDate,State,DateFrom,DateTo,AdditionalInfo,InsuranceID,InsurancePackageID,ClientID,InvoiceID")] InsuranceAgreement insuranceAgreement)
        {
            if (id != insuranceAgreement.InsuranceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuranceAgreement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceAgreementExists(insuranceAgreement.InsuranceID))
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
            ViewData["ClientID"] = new SelectList(_context.Clients, "PersonID", "PersonID", insuranceAgreement.ClientID);
            ViewData["InsuranceID"] = new SelectList(_context.Insurances, "InsuranceID", "InsuranceID", insuranceAgreement.InsuranceID);
            ViewData["InsurancePackageID"] = new SelectList(_context.InsurancePackages, "InsurancePackageID", "InsurancePackageID", insuranceAgreement.InsurancePackageID);
            return View(insuranceAgreement);
        }

        // GET: InsuranceAgreements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceAgreement = await _context.InsuranceAgreements
                .Include(i => i.Client)
                .Include(i => i.Insurance)
                .Include(i => i.InsurancePackage)
                .FirstOrDefaultAsync(m => m.InsuranceID == id);
            if (insuranceAgreement == null)
            {
                return NotFound();
            }

            return View(insuranceAgreement);
        }

        // POST: InsuranceAgreements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var insuranceAgreement = await _context.InsuranceAgreements.FindAsync(id);
            _context.InsuranceAgreements.Remove(insuranceAgreement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceAgreementExists(int? id)
        {
            return _context.InsuranceAgreements.Any(e => e.InsuranceID == id);
        }
    }
}
