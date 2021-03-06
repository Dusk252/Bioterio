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
    public class CircuitoTanquesController : Controller
    {
        private readonly bd_lesContext _context;

        public CircuitoTanquesController(bd_lesContext context)
        {
            _context = context;
        }

        private CircuitoTanque setRelations(CircuitoTanque cirTanque, int? id)
        {

            var tanques = _context.Tanque.Include(t => t.LoteIdLoteNavigation).Where(b => EF.Property<int>(b, "CircuitoTanqueIdCircuito") == id);
            var regCondAmb = _context.RegCondAmb.Where(b => EF.Property<int>(b, "CircuitoTanqueIdCircuito") == id);
            cirTanque.tanquesCol = tanques;

            cirTanque.regCondAmb = regCondAmb;

            if (cirTanque.regCondAmb.Any() || cirTanque.tanquesCol.Any())
            {
                cirTanque.isDeletable = false;
            }
            else
            {
                cirTanque.isDeletable = true;
            }

            return cirTanque;
        }
        // GET: CircuitoTanques
        [Authorize(Roles = "Administrator, ReadCircuitoTanques")]
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.CircuitoTanque.Include(c => c.ProjetoIdProjetoNavigation);
            return View(await bd_lesContext.ToListAsync());
        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
 
        public  Boolean validateCircuito(CircuitoTanque c)
        {
            double initTimestamp = Convert.ToDouble(GetTimestamp(c.DataCriacao));
            double finalTimestamp = Convert.ToDouble(GetTimestamp(c.DataFinal));
            if(initTimestamp > finalTimestamp)
            {
                return false;
            }
            var circuitoTanque = _context.CircuitoTanque.Where(b => EF.Property<int>(b, "ProjetoIdProjeto") == c.ProjetoIdProjeto);
            if (circuitoTanque.Any())
            {
                return false;
            }
            return true;

        }

        // GET: CircuitoTanques/Details/5
        [Authorize(Roles = "Administrator, ReadCircuitoTanques")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circuitoTanque = await _context.CircuitoTanque
                .Include(c => c.ProjetoIdProjetoNavigation)
                .SingleOrDefaultAsync(m => m.IdCircuito == id);

            circuitoTanque = setRelations(circuitoTanque, id);
            circuitoTanque.dateFinal = circuitoTanque.DataFinal.Day + "/" + circuitoTanque.DataFinal.Month + "/" + circuitoTanque.DataFinal.Year;
            circuitoTanque.dateCriacao = circuitoTanque.DataCriacao.Day + "/" + circuitoTanque.DataCriacao.Month + "/" + circuitoTanque.DataCriacao.Year;

            if (circuitoTanque == null)
            {
                return NotFound();
            }

            return View(circuitoTanque);
        }

        // GET: CircuitoTanques/Create
        [Authorize(Roles = "Administrator, CreateCircuitoTanques")]
        public IActionResult Create()
        {
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto.Where(p => p.isarchived == 0), "IdProjeto", "Nome");
            return View();
        }

        // POST: CircuitoTanques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, CreateCircuitoTanques")]
        public async Task<IActionResult> Create([Bind("IdCircuito,ProjetoIdProjeto,CodigoCircuito,DataCriacao,DataFinal")] CircuitoTanque circuitoTanque)
        {
            if (circuitoTanque.DataCriacao > circuitoTanque.DataFinal)
            {
                ModelState.AddModelError("DataCriacao", string.Format("Data inicial não pode ser posterior á data inicial", circuitoTanque.DataCriacao));
            }
            var cTfindany = _context.CircuitoTanque.Where(b => EF.Property<int>(b, "ProjetoIdProjeto") == circuitoTanque.ProjetoIdProjeto).Where(b => EF.Property<int>(b, "isarchived") == 0);
            if (cTfindany.Any())
            {
                ModelState.AddModelError("ProjetoIdProjeto", string.Format("Este Projecto ja possui um Circuito Tanque Associado", circuitoTanque.ProjetoIdProjeto));
            }
            var cTCodefindany = _context.CircuitoTanque.Where(b => EF.Property<string>(b, "CodigoCircuito").Equals( circuitoTanque.CodigoCircuito));
            if (cTCodefindany.Any())
            {
                ModelState.AddModelError("CodigoCircuito", string.Format("Já Existe um circuito com este Código", circuitoTanque.CodigoCircuito));
            }
            if (ModelState.IsValid)
            {
                _context.Add(circuitoTanque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto.Where(c => c.isarchived == 0), "IdProjeto", "Nome", circuitoTanque.ProjetoIdProjeto);
            return View(circuitoTanque);
        }

        // GET: CircuitoTanques/Edit/5
        [Authorize(Roles = "Administrator, EditCircuitoTanques")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circuitoTanque = await _context.CircuitoTanque.SingleOrDefaultAsync(m => m.IdCircuito == id);

            if (circuitoTanque == null || circuitoTanque.isarchived == 1)
            {
                return NotFound();
            }
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto.Where(c => c.isarchived == 0), "IdProjeto", "Nome", circuitoTanque.ProjetoIdProjeto);
            return View(circuitoTanque);
        }

        // POST: CircuitoTanques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, EditCircuitoTanques")]
        public async Task<IActionResult> Edit(int id, [Bind("IdCircuito,ProjetoIdProjeto,CodigoCircuito,DataCriacao,DataFinal")] CircuitoTanque circuitoTanque)
        {
            if (id != circuitoTanque.IdCircuito || circuitoTanque.isarchived == 1)
            {
                return NotFound();
            }
            if (circuitoTanque.DataCriacao > circuitoTanque.DataFinal)
            {
                ModelState.AddModelError("DataCriacao", string.Format("Data inicial não pode ser posterior á data inicial", circuitoTanque.DataCriacao));
            }
            var cTfindany = _context.CircuitoTanque.Where(b => EF.Property<int>(b, "ProjetoIdProjeto") == circuitoTanque.ProjetoIdProjeto).Where(b => EF.Property<int>(b, "isarchived") == 0).Where(b => EF.Property<int>(b, "IdCircuito") != circuitoTanque.IdCircuito);
            if (cTfindany.Any())
            {
                ModelState.AddModelError("ProjetoIdProjeto", string.Format("Este Projecto ja possui um Circuito Tanque Associado", circuitoTanque.ProjetoIdProjeto));
            }
            var cTCodefindany = _context.CircuitoTanque.Where(b => EF.Property<string>(b, "CodigoCircuito").Equals(circuitoTanque.CodigoCircuito)).Where(b => EF.Property<int>(b, "IdCircuito") != circuitoTanque.IdCircuito);
            if (cTCodefindany.Any())
            {
                ModelState.AddModelError("CodigoCircuito", string.Format("Já Existe um circuito com este Código", circuitoTanque.CodigoCircuito));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(circuitoTanque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CircuitoTanqueExists(circuitoTanque.IdCircuito))
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
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto.Where(p=> p.isarchived == 0), "IdProjeto", "Nome", circuitoTanque.ProjetoIdProjeto);
            return View(circuitoTanque);
        }

        // GET: CircuitoTanques/Delete/5
        [Authorize(Roles = "Administrator, DeleteCircuitoTanques")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circuitoTanque = await _context.CircuitoTanque
                .Include(c => c.ProjetoIdProjetoNavigation)
                .SingleOrDefaultAsync(m => m.IdCircuito == id);
            circuitoTanque.dateFinal = circuitoTanque.DataFinal.Day + "/" + circuitoTanque.DataFinal.Month + "/" + circuitoTanque.DataFinal.Year;
            circuitoTanque.dateCriacao = circuitoTanque.DataCriacao.Day + "/" + circuitoTanque.DataCriacao.Month + "/" + circuitoTanque.DataCriacao.Year;
            circuitoTanque = setRelations(circuitoTanque, circuitoTanque.IdCircuito);
           
            
            if (circuitoTanque == null)
            {
                return NotFound();
            }

            return View(circuitoTanque);
        }

        // POST: CircuitoTanques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, DeleteCircuitoTanques")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var circuitoTanque = await _context.CircuitoTanque.SingleOrDefaultAsync(m => m.IdCircuito == id);
            var tanques = _context.Tanque.Where(b => EF.Property<int>(b, "CircuitoTanqueIdCircuito") == id);
            var regCondAmb = _context.RegCondAmb.Where(b => EF.Property<int>(b, "CircuitoTanqueIdCircuito") == id);
            foreach (var tanque in tanques)
            {
                var regRemocoes = _context.RegRemocoes.Where(b => EF.Property<int>(b, "TanqueIdTanque") == tanque.IdTanque);
                var regAmostragens = _context.RegAmostragens.Where(b => EF.Property<int>(b, "TanqueIdTanque") == tanque.IdTanque);
                var regManu = _context.RegManutencao.Where(b => EF.Property<int>(b, "TanqueIdTanque") == tanque.IdTanque);
                var regTrat = _context.RegTratamento.Where(b => EF.Property<int>(b, "TanqueIdTanque") == tanque.IdTanque);
                var regAli = _context.RegAlimentar.Where(b => EF.Property<int>(b, "TanqueIdTanque") == tanque.IdTanque);
                foreach (var regRemocao in regRemocoes)
                {
                    regRemocao.isarchived = 1;
                    _context.RegRemocoes.Update(regRemocao);
                }
                foreach (var regAmostragem in regAmostragens)
                {
                    regAmostragem.isarchived = 1;
                    _context.RegAmostragens.Update(regAmostragem);
                }
                foreach (var regManutencao in regManu)
                {
                    regManutencao.isarchived = 1;
                    _context.RegManutencao.Update(regManutencao);
                }
                foreach (var regTratamento in regTrat)
                {
                    regTratamento.isarchived = 1;
                    _context.RegTratamento.Update(regTratamento);
                }
                foreach (var regAlimentacao in regAli)
                {
                    regAlimentacao.isarchived = 1;
                    _context.RegAlimentar.Update(regAlimentacao);
                }
                tanque.isarchived = 1;
                _context.Tanque.Update(tanque);
            }
            foreach (var condAmb in regCondAmb)
            {
                condAmb.isarchived = 1;
                _context.RegCondAmb.Update(condAmb);
            }
            circuitoTanque.isarchived = 1;
            _context.CircuitoTanque.Update(circuitoTanque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CircuitoTanqueExists(int id)
        {
            return _context.CircuitoTanque.Any(e => e.IdCircuito == id);
        }
    }
}
