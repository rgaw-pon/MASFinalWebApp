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
    public class InvoicesController : Controller
    {
        private readonly InsurexDbContext _context;

        public InvoicesController(InsurexDbContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var insurexDbContext = _context.Invoices.Include(i => i.InsuranceAgreement);
            return View(await insurexDbContext.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.InsuranceAgreement)
                .FirstOrDefaultAsync(m => m.InvoiceNo == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            ViewData["InsuranceAgreementRefID"] = new SelectList(_context.InsuranceAgreements, "InsuranceAgreementID", "InsuranceAgreementID");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceNo,DateOfIssue,BillingInfo,AdditionalInfo,InsuranceAgreementRefID")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InsuranceAgreementRefID"] = new SelectList(_context.InsuranceAgreements, "InsuranceAgreementID", "InsuranceAgreementID", invoice.InsuranceAgreementRefID);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["InsuranceAgreementRefID"] = new SelectList(_context.InsuranceAgreements, "InsuranceAgreementID", "InsuranceAgreementID", invoice.InsuranceAgreementRefID);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("InvoiceNo,DateOfIssue,BillingInfo,AdditionalInfo,InsuranceAgreementRefID")] Invoice invoice)
        {
            if (id != invoice.InvoiceNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.InvoiceNo))
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
            ViewData["InsuranceAgreementRefID"] = new SelectList(_context.InsuranceAgreements, "InsuranceAgreementID", "InsuranceAgreementID", invoice.InsuranceAgreementRefID);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.InsuranceAgreement)
                .FirstOrDefaultAsync(m => m.InvoiceNo == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(string id)
        {
            return _context.Invoices.Any(e => e.InvoiceNo == id);
        }
    }
}
