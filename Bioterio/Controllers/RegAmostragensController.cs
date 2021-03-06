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
    public class RegAmostragensController : Controller
    {
        private readonly bd_lesContext _context;

        public RegAmostragensController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: RegAmostragens
        [Authorize(Roles = "Administrator, ReadRegisto")]
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.RegAmostragens.Include(r => r.TanqueIdTanqueNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: RegAmostragens/Details/5
        [Authorize(Roles = "Administrator, ReadRegisto")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regAmostragens = await _context.RegAmostragens
                .Include(r => r.TanqueIdTanqueNavigation)
                .SingleOrDefaultAsync(m => m.IdRegAmo == id);
            if (regAmostragens == null)
            {
                return NotFound();
            }
            regAmostragens.data = regAmostragens.Data.Day + "/" + regAmostragens.Data.Month + "/" + regAmostragens.Data.Year;

            return View(regAmostragens);
        }

        // GET: RegAmostragens/Create
        [Authorize(Roles = "Administrator, CreateRegisto")]
        public IActionResult Create()
        {

            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque");
            return View();
  
        }

        // POST: RegAmostragens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, CreateRegisto")]
        public async Task<IActionResult> Create([Bind("IdRegAmo,Data,PesoMedio,NroIndividuos,PesoTotal,TanqueIdTanque")] RegAmostragens regAmostragens)
        {   
            if (ModelState.IsValid)
            {
                _context.Add(regAmostragens);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque");
            return View(regAmostragens);
        }

        // GET: RegAmostragens/Edit/5
        [Authorize(Roles = "Administrator, EditRegisto")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regAmostragens = await _context.RegAmostragens.SingleOrDefaultAsync(m => m.IdRegAmo == id);
            if (regAmostragens == null || regAmostragens.isarchived==1)
            {
                return NotFound();
            }
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque.Where(p => p.isarchived == 0), "IdTanque", "codidenttanque", regAmostragens.TanqueIdTanque);
            return View(regAmostragens);
        }

        // POST: RegAmostragens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, EditRegisto")]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegAmo,Data,PesoMedio,NroIndividuos,PesoTotal,TanqueIdTanque")] RegAmostragens regAmostragens)
        {
            if (id != regAmostragens.IdRegAmo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regAmostragens);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegAmostragensExists(regAmostragens.IdRegAmo))
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
            ViewData["TanqueIdTanque"] = new SelectList(_context.Tanque, "IdTanque", "codidenttanque", regAmostragens.TanqueIdTanque);
            return View(regAmostragens);
        }

        // GET: RegAmostragens/Delete/5
        [Authorize(Roles = "Administrator, DeleteRegisto")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regAmostragens = await _context.RegAmostragens
                .Include(r => r.TanqueIdTanqueNavigation)
                .SingleOrDefaultAsync(m => m.IdRegAmo == id);
            
            if (regAmostragens == null)
            {
                return NotFound();
            }
            regAmostragens.data = regAmostragens.Data.Day + "/" + regAmostragens.Data.Month + "/" + regAmostragens.Data.Year;
            return View(regAmostragens);
        }

        // POST: RegAmostragens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, DeleteRegisto")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regAmostragens = await _context.RegAmostragens.SingleOrDefaultAsync(m => m.IdRegAmo == id);
            _context.RegAmostragens.Remove(regAmostragens);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegAmostragensExists(int id)
        {
            return _context.RegAmostragens.Any(e => e.IdRegAmo == id);
        }
    }
}
