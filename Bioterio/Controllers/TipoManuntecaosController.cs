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
    public class TipoManuntecaosController : Controller
    {
        private readonly bd_lesContext _context;

        public TipoManuntecaosController(bd_lesContext context)
        {
            _context = context;
        }

        private TipoManuntecao setRelations(TipoManuntecao tipomanutencao, int? id)
        {
            var regTratamento = _context.RegTratamento.Where(b => EF.Property<int>(b, "AgenteTratIdAgenTra") == id);
            tipomanutencao.regManutecao = regTratamento;

            if (tipomanutencao.regManutecao.Any())
            {
                tipomanutencao.isDeletable = false;
            }
            else
            {
                tipomanutencao.isDeletable = true;
            }
            return tipomanutencao;
        }

        // GET: TipoManuntecaos
        [Authorize(Roles = "Administrator, ReadOutrasConfiguracoes")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoManuntecao.ToListAsync());
        }

        // GET: TipoManuntecaos/Details/5
        [Authorize(Roles = "Administrator, ReadOutrasConfiguracoes")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoManuntecao = await _context.TipoManuntecao
                .SingleOrDefaultAsync(m => m.IdTManutencao == id);
            if (tipoManuntecao == null)
            {
                return NotFound();
            }

            return View(tipoManuntecao);
        }

        // GET: TipoManuntecaos/Create
        [Authorize(Roles = "Administrator, CreateOutrasConfiguracoes")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoManuntecaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, CreateOutrasConfiguracoes")]
        public async Task<IActionResult> Create([Bind("IdTManutencao,TManutencao")] TipoManuntecao tipoManuntecao)
        {
            var cTCodefindany = _context.TipoManuntecao.Where(b => EF.Property<string>(b, "TManutencao").Equals(tipoManuntecao.TManutencao));
            if (cTCodefindany.Any())
            {
                ModelState.AddModelError("TManutencao", string.Format("Este Tipo de Manutencao já existe.", tipoManuntecao.TManutencao));
            }
            if (ModelState.IsValid)
            {
                _context.Add(tipoManuntecao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoManuntecao);
        }

        // GET: TipoManuntecaos/Edit/5
        [Authorize(Roles = "Administrator, EditOutrasConfiguracoes")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoManuntecao = await _context.TipoManuntecao.SingleOrDefaultAsync(m => m.IdTManutencao == id);
            if (tipoManuntecao == null)
            {
                return NotFound();
            }
            return View(tipoManuntecao);
        }

        // POST: TipoManuntecaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, EditOutrasConfiguracoes")]
        public async Task<IActionResult> Edit(int id, [Bind("IdTManutencao,TManutencao")] TipoManuntecao tipoManuntecao)
        {
            if (id != tipoManuntecao.IdTManutencao)
            {
                return NotFound();
            }
            var cTCodefindany = _context.TipoManuntecao.Where(b => EF.Property<string>(b, "TManutencao").Equals(tipoManuntecao.TManutencao));
            if (cTCodefindany.Any())
            {
                ModelState.AddModelError("TManutencao", string.Format("Este Tipo de Manutencao  já existe.", tipoManuntecao.TManutencao));
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoManuntecao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoManuntecaoExists(tipoManuntecao.IdTManutencao))
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
            return View(tipoManuntecao);
        }

        // GET: TipoManuntecaos/Delete/5
        [Authorize(Roles = "Administrator, DeleteOutrasConfiguracoes")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoManuntecao = await _context.TipoManuntecao
                .SingleOrDefaultAsync(m => m.IdTManutencao == id);
            tipoManuntecao = setRelations(tipoManuntecao, tipoManuntecao.IdTManutencao);
            if (tipoManuntecao == null)
            {
                return NotFound();
            }

            return View(tipoManuntecao);
        }

        // POST: TipoManuntecaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, DeleteOutrasConfiguracoes")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoManuntecao = await _context.TipoManuntecao.SingleOrDefaultAsync(m => m.IdTManutencao == id);
            _context.TipoManuntecao.Remove(tipoManuntecao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoManuntecaoExists(int id)
        {
            return _context.TipoManuntecao.Any(e => e.IdTManutencao == id);
        }
    }
}
