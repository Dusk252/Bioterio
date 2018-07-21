using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bioterio;
using Bioterio.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bioterio.Controllers
{
    public class RegRemocoesController : Controller
    {
        private readonly bd_lesContext _context;

        public RegRemocoesController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: RegRemocoes
        [Authorize(Roles = "Administrator, ReadRegisto")]
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.RegRemocoes.Include(r => r.MotivoIdMotivoNavigation).Include(r => r.TanqueIdTanqueNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: RegRemocoes/Details/5
        [Authorize(Roles = "Administrator, ReadRegisto")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regRemocoes = await _context.RegRemocoes
                .Include(r => r.MotivoIdMotivoNavigation)
                .Include(r => r.TanqueIdTanqueNavigation)
                .SingleOrDefaultAsync(m => m.IdRegRemo == id);
            if (regRemocoes == null)
            {
                return NotFound();
            }

            return View(regRemocoes);
        }

        // GET: RegRemocoes/Create
        [Authorize(Roles = "Administrator, CreateRegisto")]
        public IActionResult Create()
        {
            ViewData["MotivoIdMotivo"] = new SelectList(_context.Motivo, "IdMotivo", "NomeMotivo");
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque");
            return View();
        }

        // POST: RegRemocoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, CreateRegisto")]
        public async Task<IActionResult> Create([Bind("IdRegRemo,Date,NroRemocoes,MotivoIdMotivo,CausaMorte,TanqueIdTanque")] RegRemocoes regRemocoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regRemocoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MotivoIdMotivo"] = new SelectList(_context.Motivo, "IdMotivo", "NomeMotivo", regRemocoes.MotivoIdMotivo);
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque");
            return View(regRemocoes);
        }

        // GET: RegRemocoes/Edit/5
        [Authorize(Roles = "Administrator, EditRegisto")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regRemocoes = await _context.RegRemocoes.SingleOrDefaultAsync(m => m.IdRegRemo == id);
            if (regRemocoes == null || regRemocoes.isarchived==1)
            {
                return NotFound();
            }
            ViewData["MotivoIdMotivo"] = new SelectList(_context.Motivo, "IdMotivo", "NomeMotivo", regRemocoes.MotivoIdMotivo);
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque", regRemocoes.TanqueIdTanque);
            return View(regRemocoes);
        }

        // POST: RegRemocoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, EditRegisto")]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegRemo,Date,NroRemocoes,MotivoIdMotivo,CausaMorte,TanqueIdTanque")] RegRemocoes regRemocoes)
        {
            if (id != regRemocoes.IdRegRemo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regRemocoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegRemocoesExists(regRemocoes.IdRegRemo))
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
            ViewData["MotivoIdMotivo"] = new SelectList(_context.Motivo, "IdMotivo", "NomeMotivo", regRemocoes.MotivoIdMotivo);
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque, "IdTanque", "Sala", regRemocoes.TanqueIdTanque);
            return View(regRemocoes);
        }

        // GET: RegRemocoes/Delete/5
        [Authorize(Roles = "Administrator, DeleteRegisto")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regRemocoes = await _context.RegRemocoes
                .Include(r => r.MotivoIdMotivoNavigation)
                .Include(r => r.TanqueIdTanqueNavigation)
                .SingleOrDefaultAsync(m => m.IdRegRemo == id);
            if (regRemocoes == null)
            {
                return NotFound();
            }

            return View(regRemocoes);
        }

        // POST: RegRemocoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, DeleteRegisto")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regRemocoes = await _context.RegRemocoes.SingleOrDefaultAsync(m => m.IdRegRemo == id);
            _context.RegRemocoes.Remove(regRemocoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegRemocoesExists(int id)
        {
            return _context.RegRemocoes.Any(e => e.IdRegRemo == id);
        }
    }
}
