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
    public class LotesController : Controller
    {
        private readonly bd_lesContext _context;

        public LotesController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Lotes
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.Lote.Include(l => l.FuncionarioIdFuncionarioNavigation).Include(l => l.RegNovosAnimaisIdRegAnimalNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Lotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote
                .Include(l => l.FuncionarioIdFuncionarioNavigation)
                .Include(l => l.RegNovosAnimaisIdRegAnimalNavigation)
                .SingleOrDefaultAsync(m => m.IdLote == id);
            if (lote == null)
            {
                return NotFound();
            }

            return View(lote);
        }

        [Authorize(Policy = "ElevatedRights")]
        // GET: Lotes/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto");
            ViewData["RegNovosAnimaisIdRegAnimal"] = new SelectList(_context.RegNovosAnimais, "IdRegAnimal", "RespTransporte");
            return View();
        }

        [Authorize(Policy = "ElevatedRights")]
        // POST: Lotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLote,CodigoLote,DataInicio,DataFim,Observacoes,RegNovosAnimaisIdRegAnimal,FuncionarioIdFuncionario")] Lote lote)
        {
            //validation
            var val_code = await _context.Lote
                .SingleOrDefaultAsync(m => m.CodigoLote == lote.CodigoLote);
            if (val_code != null)
            {
                ModelState.AddModelError("CodigoLote", string.Format("Já existe um lote com o código {0}.", lote.CodigoLote));
            }
            if (lote.DataFim < lote.DataInicio)
            {
                ModelState.AddModelError("DataFim", "A Data de Fim é menor que a Data de Inicio.");
                ModelState.AddModelError("DataInicio", "A Data de Fim é menor que a Data de Inicio.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(lote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", lote.FuncionarioIdFuncionario);
            ViewData["RegNovosAnimaisIdRegAnimal"] = new SelectList(_context.RegNovosAnimais, "IdRegAnimal", "RespTransporte", lote.RegNovosAnimaisIdRegAnimal);
            return View(lote);
        }

        [Authorize(Policy = "ElevatedRights")]
        // GET: Lotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote.SingleOrDefaultAsync(m => m.IdLote == id);
            if (lote == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", lote.FuncionarioIdFuncionario);
            ViewData["RegNovosAnimaisIdRegAnimal"] = new SelectList(_context.RegNovosAnimais, "IdRegAnimal", "RespTransporte", lote.RegNovosAnimaisIdRegAnimal);
            return View(lote);
        }

        [Authorize(Policy = "ElevatedRights")]
        // POST: Lotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLote,CodigoLote,DataInicio,DataFim,Observacoes,RegNovosAnimaisIdRegAnimal,FuncionarioIdFuncionario")] Lote lote)
        {
            if (id != lote.IdLote)
            {
                return NotFound();
            }

            //validation
            var val_code = await _context.Lote
                .SingleOrDefaultAsync(m => m.CodigoLote == lote.CodigoLote);
            if (val_code != null && val_code.IdLote != lote.IdLote)
            {
                ModelState.AddModelError("CodigoLote", string.Format("Já existe um lote com o código {0}.", lote.CodigoLote));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoteExists(lote.IdLote))
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
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", lote.FuncionarioIdFuncionario);
            ViewData["RegNovosAnimaisIdRegAnimal"] = new SelectList(_context.RegNovosAnimais, "IdRegAnimal", "RespTransporte", lote.RegNovosAnimaisIdRegAnimal);
            return View(lote);
        }

        [Authorize(Policy = "ElevatedRights")]
        // GET: Lotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote
                .Include(l => l.FuncionarioIdFuncionarioNavigation)
                .Include(l => l.RegNovosAnimaisIdRegAnimalNavigation)
                .SingleOrDefaultAsync(m => m.IdLote == id);
            if (lote == null)
            {
                return NotFound();
            }

            return View(lote);
        }

        [Authorize(Policy = "ElevatedRights")]
        // POST: Lotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lote = await _context.Lote.SingleOrDefaultAsync(m => m.IdLote == id);
            _context.Lote.Remove(lote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoteExists(int id)
        {
            return _context.Lote.Any(e => e.IdLote == id);
        }

        public async Task<ActionResult> ValidateCodigoLote(string CodigoLote, int IdLote)
        {
            var val_codigolote = await _context.Lote
            .SingleOrDefaultAsync(m => m.CodigoLote == CodigoLote);
            if (val_codigolote == null || val_codigolote.IdLote == IdLote) return Json(true);
            else return Json(string.Format("Já existe um lote com o código {0}.", CodigoLote));
        }

        public ActionResult ValidateDates(DateTime DataInicio, DateTime DataFim)
        {
            if (DataInicio <= DataFim) return Json(true);
            else return Json("A Data de Fim é menor que a Data de Inicio.");
        }
    }
}
