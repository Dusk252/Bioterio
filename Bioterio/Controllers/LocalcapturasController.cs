using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bioterio.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bioterio.Controllers
{
    [Authorize(Policy = "AdminRights")]
    public class LocalcapturasController : Controller
    {
        private readonly bd_lesContext _context;

        public LocalcapturasController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Localcapturas
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.Localcaptura.Include(l => l.Concelho).Include(l => l.Distrito);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Localcapturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localcaptura = await _context.Localcaptura
                .Include(l => l.Concelho)
                .Include(l => l.Distrito)
                .SingleOrDefaultAsync(m => m.IdLocalCaptura == id);
            if (localcaptura == null)
            {
                return NotFound();
            }

            return View(localcaptura);
        }

        // GET: Localcapturas/Create
        public IActionResult Create()
        {
            ViewData["ConcelhoId"] = new SelectList(_context.Concelho, "Id", "NomeConcelho");
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id");
            return View();
        }

        // POST: Localcapturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLocalCaptura,Localidade,Latitude,Longitude,ConcelhoId,DistritoId")] Localcaptura localcaptura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localcaptura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConcelhoId"] = new SelectList(_context.Concelho, "Id", "NomeConcelho", localcaptura.ConcelhoId);
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id", localcaptura.DistritoId);
            return View(localcaptura);
        }

        // GET: Localcapturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localcaptura = await _context.Localcaptura.SingleOrDefaultAsync(m => m.IdLocalCaptura == id);
            if (localcaptura == null)
            {
                return NotFound();
            }
            ViewData["ConcelhoId"] = new SelectList(_context.Concelho, "Id", "NomeConcelho", localcaptura.ConcelhoId);
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id", localcaptura.DistritoId);
            return View(localcaptura);
        }

        // POST: Localcapturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLocalCaptura,Localidade,Latitude,Longitude,ConcelhoId,DistritoId")] Localcaptura localcaptura)
        {
            if (id != localcaptura.IdLocalCaptura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localcaptura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalcapturaExists(localcaptura.IdLocalCaptura))
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
            ViewData["ConcelhoId"] = new SelectList(_context.Concelho, "Id", "NomeConcelho", localcaptura.ConcelhoId);
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id", localcaptura.DistritoId);
            return View(localcaptura);
        }

        // GET: Localcapturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localcaptura = await _context.Localcaptura
                .Include(l => l.Concelho)
                .Include(l => l.Distrito)
                .SingleOrDefaultAsync(m => m.IdLocalCaptura == id);
            if (localcaptura == null)
            {
                return NotFound();
            }

            return View(localcaptura);
        }

        // POST: Localcapturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localcaptura = await _context.Localcaptura.SingleOrDefaultAsync(m => m.IdLocalCaptura == id);
            _context.Localcaptura.Remove(localcaptura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalcapturaExists(int id)
        {
            return _context.Localcaptura.Any(e => e.IdLocalCaptura == id);
        }
    }
}
