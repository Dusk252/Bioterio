﻿using System;
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
    public class RegManutencaosController : Controller
    {
        private readonly bd_lesContext _context;

        public RegManutencaosController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: RegManutencaos
        [Authorize(Roles = "Administrator, ReadRegisto")]
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.RegManutencao.Include(r => r.TanqueIdTanqueNavigation).Include(r => r.TipoManuntecaoIdTManutencaoNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: RegManutencaos/Details/5
        [Authorize(Roles = "Administrator, ReadRegisto")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regManutencao = await _context.RegManutencao
                .Include(r => r.TanqueIdTanqueNavigation)
                .Include(r => r.TipoManuntecaoIdTManutencaoNavigation)
                .SingleOrDefaultAsync(m => m.IdRegMan == id);
            if (regManutencao == null)
            {
                return NotFound();
            }
            regManutencao.data = regManutencao.Data.Day + "/" + regManutencao.Data.Month + "/" + regManutencao.Data.Year;


            return View(regManutencao);
        }

        // GET: RegManutencaos/Create
        [Authorize(Roles = "Administrator, CreateRegisto")]
        public IActionResult Create()
        {
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque");

            ViewData["TipoManuntecaoIdTManutencao"] = new SelectList(_context.TipoManuntecao, "IdTManutencao", "TManutencao");
            return View();
        }

        // POST: RegManutencaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, CreateRegisto")]
        public async Task<IActionResult> Create([Bind("IdRegMan,Data,TipoManuntecaoIdTManutencao,TanqueIdTanque")] RegManutencao regManutencao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regManutencao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque");

            ViewData["TipoManuntecaoIdTManutencao"] = new SelectList(_context.TipoManuntecao, "IdTManutencao", "TManutencao");
            return View(regManutencao);
        }

        // GET: RegManutencaos/Edit/5
        [Authorize(Roles = "Administrator, EditRegisto")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regManutencao = await _context.RegManutencao.SingleOrDefaultAsync(m => m.IdRegMan == id);
            if (regManutencao == null || regManutencao.isarchived == 1)
            {
                return NotFound();
            }
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque", regManutencao.TanqueIdTanque);

            ViewData["TipoManuntecaoIdTManutencao"] = new SelectList(_context.TipoManuntecao, "IdTManutencao", "TManutencao", regManutencao.TipoManuntecaoIdTManutencao);
            return View(regManutencao);
        }

        // POST: RegManutencaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, EditRegisto")]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegMan,Data,TipoManuntecaoIdTManutencao,TanqueIdTanque")] RegManutencao regManutencao)
        {
            if (id != regManutencao.IdRegMan || regManutencao.isarchived == 1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regManutencao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegManutencaoExists(regManutencao.IdRegMan))
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
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque", regManutencao.TanqueIdTanque);

            ViewData["TipoManuntecaoIdTManutencao"] = new SelectList(_context.TipoManuntecao, "IdTManutencao", "TManutencao", regManutencao.TipoManuntecaoIdTManutencao);
            return View(regManutencao);
        }

        // GET: RegManutencaos/Delete/5
        [Authorize(Roles = "Administrator, DeleteRegisto")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regManutencao = await _context.RegManutencao
                .Include(r => r.TanqueIdTanqueNavigation)
                .Include(r => r.TipoManuntecaoIdTManutencaoNavigation)
                .SingleOrDefaultAsync(m => m.IdRegMan == id);
            if (regManutencao == null || regManutencao.isarchived == 1)
            {
                return NotFound();
            }
            regManutencao.data = regManutencao.Data.Day + "/" + regManutencao.Data.Month + "/" + regManutencao.Data.Year;

            return View(regManutencao);
        }

        // POST: RegManutencaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, DeleteRegisto")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regManutencao = await _context.RegManutencao.SingleOrDefaultAsync(m => m.IdRegMan == id);
            _context.RegManutencao.Remove(regManutencao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegManutencaoExists(int id)
        {
            return _context.RegManutencao.Any(e => e.IdRegMan == id);
        }
    }
}
