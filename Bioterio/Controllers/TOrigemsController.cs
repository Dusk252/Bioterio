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
    public class TOrigemsController : Controller
    {
        private readonly bd_lesContext _context;

        public TOrigemsController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: TOrigems
        [Authorize(Roles = "Administrator, ReadOutrasConfiguracoes")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TOrigem.ToListAsync());
        }

        // GET: TOrigems/Details/5
        [Authorize(Roles = "Administrator, ReadOutrasConfiguracoes")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrigem = await _context.TOrigem
                .SingleOrDefaultAsync(m => m.IdTOrigem == id);
            if (tOrigem == null)
            {
                return NotFound();
            }

            return View(tOrigem);
        }

        // GET: TOrigems/Create
        [Authorize(Roles = "Administrator, CreateOutrasConfiguracoes")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TOrigems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, CreateOutrasConfiguracoes")]
        public async Task<IActionResult> Create([Bind("IdTOrigem,descricao")] TOrigem tOrigem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tOrigem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tOrigem);
        }

        // GET: TOrigems/Edit/5
        [Authorize(Roles = "Administrator, EditOutrasConfiguracoes")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrigem = await _context.TOrigem.SingleOrDefaultAsync(m => m.IdTOrigem == id);
            if (tOrigem == null)
            {
                return NotFound();
            }
            return View(tOrigem);
        }

        // POST: TOrigems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, EditOutrasConfiguracoes")]
        public async Task<IActionResult> Edit(int id, [Bind("IdTOrigem,descricao")] TOrigem tOrigem)
        {
            if (id != tOrigem.IdTOrigem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tOrigem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TOrigemExists(tOrigem.IdTOrigem))
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
            return View(tOrigem);
        }

        // GET: TOrigems/Delete/5
        [Authorize(Roles = "Administrator, DeleteOutrasConfiguracoes")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrigem = await _context.TOrigem
                .SingleOrDefaultAsync(m => m.IdTOrigem == id);
            if (tOrigem == null)
            {
                return NotFound();
            }

            return View(tOrigem);
        }

        // POST: TOrigems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, DeleteOutrasConfiguracoes")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tOrigem = await _context.TOrigem.SingleOrDefaultAsync(m => m.IdTOrigem == id);
            _context.TOrigem.Remove(tOrigem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TOrigemExists(int id)
        {
            return _context.TOrigem.Any(e => e.IdTOrigem == id);
        }
    }
}
