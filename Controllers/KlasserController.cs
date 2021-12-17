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
    public class KlasserController : Controller
    {
        private readonly FiskContext _context;

        public KlasserController(FiskContext context)
        {
            _context = context;
        }

        // GET: Klasser
        public async Task<IActionResult> Index()
        {
            try
            {
                 return View(await _context.Klasser.ToListAsync());
            }
            catch (Exception)
            {
                return RedirectToAction("EnFulErrorSida");
            }

         
        }

        // GET: Klasser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klass = await _context.Klasser
                .FirstOrDefaultAsync(m => m.KlassId == id);
            if (klass == null)
            {
                return NotFound();
            }

            try
            {
                 return View(klass);
            }
            catch (Exception)
            {
                return RedirectToAction("EnFulErrorSida");
            }

           
        }

        // GET: Klasser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klasser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlassId,FiskKlass")] Klass klass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            try
            {
                return View(klass); 
            }
            catch (Exception)
            {
                return RedirectToAction("EnFulErrorSida");
            }

            
        }

        // GET: Klasser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klass = await _context.Klasser.FindAsync(id);
            if (klass == null)
            {
                return NotFound();
            }
            try
            {
            return View(klass);
               
            }
            catch (Exception)
            {
                return RedirectToAction("EnFulErrorSida");
            }
            
            
        }

        // POST: Klasser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KlassId,FiskKlass")] Klass klass)
        {
            if (id != klass.KlassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlassExists(klass.KlassId))
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
            return View(klass);
        }

        // GET: Klasser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klass = await _context.Klasser
                .FirstOrDefaultAsync(m => m.KlassId == id);
            if (klass == null)
            {
                return NotFound();
            }

            try
            {
               
            return View(klass);  
            }
            catch (Exception)
            {
                return RedirectToAction("EnFulErrorSida");
            }


        }

        // POST: Klasser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klass = await _context.Klasser.FindAsync(id);
            _context.Klasser.Remove(klass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlassExists(int id)
        {
            return _context.Klasser.Any(e => e.KlassId == id);
        }
    }
}
