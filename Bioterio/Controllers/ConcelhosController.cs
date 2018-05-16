using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bioterio.Models;

namespace Bioterio.Controllers
{
    public class ConcelhosController : Controller
    {
        private readonly bd_lesContext _context;

        public ConcelhosController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Concelhos
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.Concelho.Include(c => c.Distrito);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Concelhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Concelho = await _context.Concelho
                .Include(c => c.Distrito)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Concelho == null)
            {
                return NotFound();
            }

            return View(Concelho);
        }

        // GET: Concelhos/Create
        public IActionResult Create()
        {
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id");
            return View();
        }

        // POST: Concelhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeConcelho,DistritoId")] Concelho Concelho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Concelho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id", Concelho.DistritoId);
            return View(Concelho);
        }

        // GET: Concelhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Concelho = await _context.Concelho.SingleOrDefaultAsync(m => m.Id == id);
            if (Concelho == null)
            {
                return NotFound();
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id", Concelho.DistritoId);
            return View(Concelho);
        }

        // POST: Concelhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeConcelho,DistritoId")] Concelho Concelho)
        {
            if (id != Concelho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Concelho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcelhoExists(Concelho.Id))
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
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id", Concelho.DistritoId);
            return View(Concelho);
        }

        // GET: Concelhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Concelho = await _context.Concelho
                .Include(c => c.Distrito)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Concelho == null)
            {
                return NotFound();
            }

            return View(Concelho);
        }

        // POST: Concelhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Concelho = await _context.Concelho.SingleOrDefaultAsync(m => m.Id == id);
            _context.Concelho.Remove(Concelho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcelhoExists(int id)
        {
            return _context.Concelho.Any(e => e.Id == id);
        }
    }
}
