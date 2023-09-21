using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Registerloginpage.Models;

namespace Registerloginpage.Controllers
{
    [Authorize]
    public class TblproductsController : Controller
    {
        private readonly Sample6Context _context;

        public TblproductsController(Sample6Context context)
        {
            _context = context;
        }

        // GET: Tblproducts
        public async Task<IActionResult> Index()
        {
            var sample6Context = _context.Tblproducts.Include(t => t.Category);
            return View(await sample6Context.ToListAsync());
        }

        // GET: Tblproducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tblproducts == null)
            {
                return NotFound();
            }

            var tblproduct = await _context.Tblproducts
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.Productid == id);
            if (tblproduct == null)
            {
                return NotFound();
            }

            return View(tblproduct);
        }

        // GET: Tblproducts/Create
        public IActionResult Create()
        {
            ViewData["Categoryid"] = new SelectList(_context.Tblcategories, "Categoryid", "Categoryid");
            return View();
        }

        // POST: Tblproducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Productid,Name,Price,Categoryid")] Tblproduct tblproduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblproduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoryid"] = new SelectList(_context.Tblcategories, "Categoryid", "Categoryid", tblproduct.Categoryid);
            return View(tblproduct);
        }

        // GET: Tblproducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tblproducts == null)
            {
                return NotFound();
            }

            var tblproduct = await _context.Tblproducts.FindAsync(id);
            if (tblproduct == null)
            {
                return NotFound();
            }
            ViewData["Categoryid"] = new SelectList(_context.Tblcategories, "Categoryid", "Categoryid", tblproduct.Categoryid);
            return View(tblproduct);
        }

        // POST: Tblproducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Productid,Name,Price,Categoryid")] Tblproduct tblproduct)
        {
            if (id != tblproduct.Productid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblproduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblproductExists(tblproduct.Productid))
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
            ViewData["Categoryid"] = new SelectList(_context.Tblcategories, "Categoryid", "Categoryid", tblproduct.Categoryid);
            return View(tblproduct);
        }

        // GET: Tblproducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tblproducts == null)
            {
                return NotFound();
            }

            var tblproduct = await _context.Tblproducts
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.Productid == id);
            if (tblproduct == null)
            {
                return NotFound();
            }

            return View(tblproduct);
        }

        // POST: Tblproducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tblproducts == null)
            {
                return Problem("Entity set 'Sample6Context.Tblproducts'  is null.");
            }
            var tblproduct = await _context.Tblproducts.FindAsync(id);
            if (tblproduct != null)
            {
                _context.Tblproducts.Remove(tblproduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblproductExists(int id)
        {
          return (_context.Tblproducts?.Any(e => e.Productid == id)).GetValueOrDefault();
        }
    }
}
