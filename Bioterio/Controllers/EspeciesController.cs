using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bioterio.Models;
using Bioterio.Validation;
using Microsoft.AspNetCore.Authorization;

namespace Bioterio.Controllers
{
    [Authorize(Policy = "AdminRights")]
    public class EspeciesController : Controller
    {
        private readonly bd_lesContext _context;

        public EspeciesController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Especies
        public async Task<IActionResult> Index()
        {
            TempData["origin_controller"] = @Url.Action("Index", "Especies");
            var bd_lesContext = _context.Especie.Include(e => e.FamiliaIdFamiliaNavigation)
                                .ThenInclude(f => f.GrupoIdGrupoNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Especies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie
                .Include(e => e.FamiliaIdFamiliaNavigation)
                .ThenInclude(f => f.GrupoIdGrupoNavigation)
                .SingleOrDefaultAsync(m => m.IdEspecie == id);
            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        // GET: Especies/Create
        public IActionResult Create()
        {
            ViewData["FamiliaIdFamilia"] = new SelectList(_context.Familia, "IdFamilia", "NomeFamilia").Prepend(new SelectListItem() { Text = "---Selecione uma Familia---", Value = "" });
            ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "NomeGrupo").Prepend(new SelectListItem() { Text = "---Selecione um Grupo---", Value = "" });
            return View();
        }

        // POST: Especies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEspecie,NomeCient,NomeVulgar,FamiliaIdFamilia,GrupoIdGrupo")] Especie especie)
        {
            //validation
            var val_nomecient = await _context.Especie
                .SingleOrDefaultAsync(m => m.NomeCient == especie.NomeCient);
            if (val_nomecient != null)
            {
                ModelState.AddModelError("NomeCient", string.Format("Já existe uma espécie com o nome {0}.", especie.NomeCient));
            }
            var val_family_group = await _context.Familia
                .SingleOrDefaultAsync(m => m.IdFamilia == especie.FamiliaIdFamilia);
            if (val_family_group.GrupoIdGrupo != especie.GrupoIdGrupo)
            {
                ModelState.AddModelError("FamiliaIdFamilia", "A familia selecionada não pertence ao grupo selecionado.");
                ModelState.AddModelError("GrupoIdGrupo", "O grupo selecionado não contém a familia selecionada.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(especie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FamiliaIdFamilia"] = new SelectList(_context.Familia, "IdFamilia", "NomeFamilia", especie.FamiliaIdFamilia).Prepend(new SelectListItem() { Text = "---Selecione uma Familia---", Value = "" });
            ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "NomeGrupo", especie.GrupoIdGrupo).Prepend(new SelectListItem() { Text = "---Selecione um Grupo---", Value = "" });
            return View(especie);
        }

        // GET: Especies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie.SingleOrDefaultAsync(m => m.IdEspecie == id);
            if (especie == null)
            {
                return NotFound();
            }
            ViewData["FamiliaIdFamilia"] = new SelectList(_context.Familia, "IdFamilia", "NomeFamilia", especie.FamiliaIdFamilia).Prepend(new SelectListItem() { Text = "---Selecione uma Familia---", Value = "" });
            ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "NomeGrupo", especie.GrupoIdGrupo).Prepend(new SelectListItem() { Text = "---Selecione um Grupo---", Value = "" });
            return View(especie);
        }

        // POST: Especies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecie,NomeCient,NomeVulgar,FamiliaIdFamilia,GrupoIdGrupo")] Especie especie)
        {
            if (id != especie.IdEspecie)
            {
                return NotFound();
            }

            //validation
            var val_nomecient = await _context.Especie
                .SingleOrDefaultAsync(m => m.NomeCient == especie.NomeCient);
            if (val_nomecient != null && val_nomecient.IdEspecie != especie.IdEspecie)
            {
                ModelState.AddModelError("NomeCient", string.Format("Já existe uma espécie com o nome {0}.", especie.NomeCient));
            }
            var val_family_group = await _context.Familia
                .SingleOrDefaultAsync(m => m.IdFamilia == especie.FamiliaIdFamilia);
            if (val_family_group.GrupoIdGrupo != especie.GrupoIdGrupo)
            {
                ModelState.AddModelError("FamiliaIdFamilia", "A familia selecionada não pertence ao grupo selecionado.");
                ModelState.AddModelError("GrupoIdGrupo", "O grupo selecionado não contém a familia selecionada.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var old_especie = await _context.Especie
                .SingleOrDefaultAsync(m => m.IdEspecie == id);
                    _context.Entry(old_especie).CurrentValues.SetValues(especie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecieExists(especie.IdEspecie))
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
            ViewData["FamiliaIdFamilia"] = new SelectList(_context.Familia, "IdFamilia", "NomeFamilia", especie.FamiliaIdFamilia).Prepend(new SelectListItem() { Text = "---Selecione uma Familia---", Value = "" });
            ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "NomeGrupo", especie.GrupoIdGrupo).Prepend(new SelectListItem() { Text = "---Selecione um Grupo---", Value = "" });
            return View(especie);
        }

        // GET: Especies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.Especie
                .Include(e => e.FamiliaIdFamiliaNavigation)
                .Include(e => e.RegNovosAnimais)
                    .ThenInclude(r => r.FornecedorIdFornColectNavigation)
                .SingleOrDefaultAsync(m => m.IdEspecie == id);
            if (especie == null)
            {
                return NotFound();
            }
            if (especie.RegNovosAnimais.Count > 0)
            {
                return View("DeleteDenied", especie);
            }
            else
            {
                return View(especie);
            }
        }

        // POST: Especies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especie = await _context.Especie
                .Include(f => f.FamiliaIdFamiliaNavigation)
                .SingleOrDefaultAsync(m => m.IdEspecie == id);
            _context.Especie.Remove(especie);
            await _context.SaveChangesAsync();

            var check_if_more = await _context.Especie.FirstOrDefaultAsync(m => m.FamiliaIdFamilia == especie.FamiliaIdFamilia);
            if (check_if_more == null)
            {
                TempData["more"] = false;
                TempData["id"] = especie.FamiliaIdFamilia;
                TempData["name"] = especie.FamiliaIdFamiliaNavigation.NomeFamilia;
                TempData["controller"] = "Familias";
                TempData["empty"] = "família";
            }
            TempData["deleted_name"] = especie.NomeCient;
            TempData["deleted_entity"] = "espécie";
            TempData["deleted"] = true;

            string route = TempData["origin_controller"].ToString() ?? @Url.Action("Index", "Especies");
            return Redirect(route);
        }

        private bool EspecieExists(int id)
        {
            return _context.Especie.Any(e => e.IdEspecie == id);
        }

        public async Task<ActionResult> ValidateScientificName(string NomeCient, int IdEspecie)
        {
            var val_nomecient = await _context.Especie
            .SingleOrDefaultAsync(m => m.NomeCient == NomeCient);
            if (val_nomecient == null || val_nomecient.IdEspecie == IdEspecie) return Json(true);
            else return Json(string.Format("Já existe uma espécie com o nome {0}.", NomeCient));
        }
    }
}