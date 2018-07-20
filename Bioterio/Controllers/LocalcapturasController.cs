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
    public class LocalcapturasController : Controller
    {
        private readonly bd_lesContext _context;

        public LocalcapturasController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Localcapturas
        [Authorize(Roles = "Administrator, ReadLocalizacao")]
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.Localcaptura.Include(l => l.Concelho).Include(l => l.Distrito);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Localcapturas/Details/5
        [Authorize(Roles = "Administrator, ReadLocalizacao")]
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
        [Authorize(Roles = "Administrator, CreateLocalizacao")]
        public IActionResult Create()
        {
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "IdDistrito", "NomeDistrito").Prepend(new SelectListItem() { Text = "---Selecione um Distrito---", Value = "" });
            ViewData["ConcelhoId"] = new SelectList(_context.Concelho, "IdConcelho", "NomeConcelho").Prepend(new SelectListItem() { Text = "---Selecione um Concelho---", Value = "" });
            return View();
        }

        // POST: Localcapturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, CreateLocalizacao")]
        public async Task<IActionResult> Create([Bind("IdLocalCaptura,Localidade,Latitude,Longitude,ConcelhoId,DistritoId")] Localcaptura localcaptura)
        {

            //validation
            var val_concelho_distrito = await _context.Concelho
                .SingleOrDefaultAsync(m => m.IdConcelho == localcaptura.ConcelhoId);
            if (val_concelho_distrito.DistritoId != localcaptura.DistritoId)
            {
                ModelState.AddModelError("DistritoId", "O distrito selecionado não contém o concelho selecionado.");
                ModelState.AddModelError("ConcelhoId", "O concelho selecionado não pertence ao distrito selecionado.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(localcaptura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "IdDistrito", "NomeDistrito").Prepend(new SelectListItem() { Text = "---Selecione um Distrito---", Value = "" });
            ViewData["ConcelhoId"] = new SelectList(_context.Concelho, "IdConcelho", "NomeConcelho").Prepend(new SelectListItem() { Text = "---Selecione um Concelho---", Value = "" });
            return View(localcaptura);
        }

        // GET: Localcapturas/Edit/5
        [Authorize(Roles = "Administrator, EditLocalizacao")]
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
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "IdDistrito", "NomeDistrito").Prepend(new SelectListItem() { Text = "---Selecione um Distrito---", Value = "" });
            ViewData["ConcelhoId"] = new SelectList(_context.Concelho, "IdConcelho", "NomeConcelho").Prepend(new SelectListItem() { Text = "---Selecione um Concelho---", Value = "" });
            return View(localcaptura);
        }

        // POST: Localcapturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, EditLocalizacao")]
        public async Task<IActionResult> Edit(int id, [Bind("IdLocalCaptura,Localidade,Latitude,Longitude,ConcelhoId,DistritoId")] Localcaptura localcaptura)
        {
            if (id != localcaptura.IdLocalCaptura)
            {
                return NotFound();
            }

            //validation
            var val_concelho_distrito = await _context.Concelho
                .SingleOrDefaultAsync(m => m.IdConcelho == localcaptura.ConcelhoId);
            if (val_concelho_distrito.DistritoId != localcaptura.DistritoId)
            {
                ModelState.AddModelError("DistritoId", "O distrito selecionado não contém o concelho selecionado.");
                ModelState.AddModelError("ConcelhoId", "O concelho selecionado não pertence ao distrito selecionado.");
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
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "IdDistrito", "NomeDistrito").Prepend(new SelectListItem() { Text = "---Selecione um Distrito---", Value = "" });
            ViewData["ConcelhoId"] = new SelectList(_context.Concelho, "IdConcelho", "NomeConcelho").Prepend(new SelectListItem() { Text = "---Selecione um Concelho---", Value = "" });
            return View(localcaptura);
        }

        // GET: Localcapturas/Delete/5
        [Authorize(Roles = "Administrator, DeleteLocalizacao")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localcaptura = await _context.Localcaptura
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
        [Authorize(Roles = "Administrator, DeleteLocalizacao")]
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
