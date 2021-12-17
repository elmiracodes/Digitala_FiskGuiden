using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Digitala_FiskGuiden.Models;

namespace Digitala_FiskGuiden.Controllers
{
    public class FiskGuideController : Controller
    {
        private readonly FiskContext _context;

        public FiskGuideController(FiskContext context)
        {
            _context = context;
        }

        // GET: FiskGuide
        public async Task<IActionResult> Index()
        {
            var fiskContext = _context.Fiskar.Include(f => f.Klass);


            // TRY CATCH SOM TAR DIG TILL VID FEL, SE ENFULSIDACONTROLLER SAMT INDEX
            try
            {
                return View(await fiskContext.ToListAsync());
            }
            catch (Exception)
            {
                return RedirectToAction("EnFulErrorSida");
            }

            
        }

        // GET: FiskGuide/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisk = await _context.Fiskar
                .Include(f => f.Klass)
                .FirstOrDefaultAsync(m => m.FiskId == id);
            if (fisk == null)
            {
                return NotFound();
            }
            // TRY CATCH SOM TAR DIG TILL VID FEL, SE ENFULSIDACONTROLLER SAMT INDEX

            try
            {
               return View(fisk);
            }
            catch (Exception)
            {
                return RedirectToAction("EnFulErrorSida");
            }

            
        }

        // GET: FiskGuide/Create
        public IActionResult Create()
        {
            ViewData["KlassId"] = new SelectList(_context.Klasser, "KlassId", "FiskKlass");
            return View();
        }

        // POST: FiskGuide/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FiskId,Art,Fakta,KlassId")] Fisk fisk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fisk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlassId"] = new SelectList(_context.Klasser, "KlassId", "KlassId", fisk.KlassId);
            try
            {
                return View(fisk);
            }
            catch (Exception)
            {
                return RedirectToAction("EnFulErrorSida");
            }
        }

        // GET: FiskGuide/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisk = await _context.Fiskar.FindAsync(id);
            if (fisk == null)
            {
                return NotFound();
            }
            ViewData["KlassId"] = new SelectList(_context.Klasser, "KlassId", "FiskKlass", fisk.KlassId);
            return View(fisk);
        }

        // POST: FiskGuide/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FiskId,Art,Fakta,KlassId")] Fisk fisk)
        {
            if (id != fisk.FiskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fisk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiskExists(fisk.FiskId))
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
            ViewData["KlassId"] = new SelectList(_context.Klasser, "KlassId", "KlassId", fisk.KlassId);
            return View(fisk);
        }

        // GET: FiskGuide/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisk = await _context.Fiskar
                .Include(f => f.Klass)
                .FirstOrDefaultAsync(m => m.FiskId == id);
            if (fisk == null)
            {
                return NotFound();
            }

            return View(fisk);
        }

        // POST: FiskGuide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fisk = await _context.Fiskar.FindAsync(id);
            _context.Fiskar.Remove(fisk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiskExists(int id)
        {

            return _context.Fiskar.Any(e => e.FiskId == id);
        }
    }
}
