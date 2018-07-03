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
    public class FamiliasController : Controller
    {
        private readonly bd_lesContext _context;

        public FamiliasController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Familias
        public async Task<IActionResult> Index()
        {
            TempData["origin_controller"] = @Url.Action("Index", "Familias");
            var bd_lesContext = _context.Familia.Include(f => f.GrupoIdGrupoNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Familias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familia
                .Include(f => f.GrupoIdGrupoNavigation)
                .SingleOrDefaultAsync(m => m.IdFamilia == id);
            if (familia == null)
            {
                return NotFound();
            }

            return View(familia);
        }

        // GET: Familias/Create
        public IActionResult Create()
        {
            ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "NomeGrupo").Prepend(new SelectListItem() { Text = "---Selecione um Grupo---", Value = "" });
            return View();
        }

        // POST: Familias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFamilia,NomeFamilia,GrupoIdGrupo")] Familia familia)
        {
            //validation
            var val_nome = await _context.Familia
                .SingleOrDefaultAsync(m => m.NomeFamilia == familia.NomeFamilia);
            if (val_nome != null)
            {
                ModelState.AddModelError("NomeFamilia", string.Format("Já existe uma família com o nome {0}.", familia.NomeFamilia));
            }

            if (ModelState.IsValid)
            {
                _context.Add(familia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "NomeGrupo", familia.GrupoIdGrupo).Prepend(new SelectListItem() { Text = "---Selecione um Grupo---", Value = "" });
            return View(familia);
        }

        // GET: Familias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familia.SingleOrDefaultAsync(m => m.IdFamilia == id);
            if (familia == null)
            {
                return NotFound();
            }
            ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "NomeGrupo").Prepend(new SelectListItem() { Text = "---Selecione um Grupo---", Value = "" });
            return View(familia);
        }

        // POST: Familias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFamilia,NomeFamilia,GrupoIdGrupo")] Familia familia)
        {
            if (id != familia.IdFamilia)
            {
                return NotFound();
            }

            //validation
            var val_nome = await _context.Familia
                .SingleOrDefaultAsync(m => m.NomeFamilia == familia.NomeFamilia);
            if (val_nome != null && val_nome.IdFamilia != familia.IdFamilia)
            {
                ModelState.AddModelError("NomeFamilia", string.Format("Já existe uma família com o nome {0}.", familia.NomeFamilia));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //update family
                    var old_familia = await _context.Familia
                        .SingleOrDefaultAsync(m => m.IdFamilia == id);

                 /*   var old_familia = await _context.Familia
                .SingleOrDefaultAsync(m => m.IdFamilia == id);*/
                    _context.Entry(old_familia).CurrentValues.SetValues(familia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliaExists(familia.IdFamilia))
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
            ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "NomeGrupo").Prepend(new SelectListItem() { Text = "---Selecione um Grupo---", Value = "" });
            return View(familia);
        }

        // GET: Familias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familia
                .Include(f => f.GrupoIdGrupoNavigation)
                .SingleOrDefaultAsync(m => m.IdFamilia == id);
            if (familia == null)
            {
                return NotFound();
            }

            //get species belonging to family
            var especies = await _context.Especie
                .Include(e => e.RegNovosAnimais)
                    .ThenInclude(r => r.FornecedorIdFornColectNavigation)
                .Where(m => m.FamiliaIdFamilia == id)
                .ToListAsync();

            //check if species are associated with registers (don't delete if so)
            List<Especie> bound_species = new List<Especie>();
            foreach (Especie e in especies)
            {
                if (e.RegNovosAnimais.Count > 0)
                {
                    bound_species.Add(e);
                }
            }
            if (bound_species.Count > 0)
            {
                ViewData["especies"] = bound_species;
                return View("DeleteDenied", familia);
            }
            else
            {
                ViewData["especies"] = especies;
                return View(familia);
            }
        }

        // POST: Familias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familia = await _context.Familia
                .Include(f => f.GrupoIdGrupoNavigation)
                .SingleOrDefaultAsync(m => m.IdFamilia == id);
            var especies = await _context.Especie
                .Where(m => m.FamiliaIdFamilia == id)
                .ToArrayAsync();

            _context.Familia.Remove(familia);
            _context.Especie.RemoveRange(especies);
            await _context.SaveChangesAsync();

            var check_if_more = await _context.Familia.FirstOrDefaultAsync(m => m.GrupoIdGrupo == familia.GrupoIdGrupo);
            if (check_if_more == null)
            {
                TempData["more"] = false;
                TempData["id"] = familia.GrupoIdGrupo;
                TempData["name"] = familia.GrupoIdGrupoNavigation.NomeGrupo;
                TempData["controller"] = "Grupos";
                TempData["empty"] = "grupo";
            }
            TempData["deleted_name"] = familia.NomeFamilia;
            TempData["deleted_entity"] = "família";
            TempData["deleted"] = true;

            string route = TempData["origin_controller"].ToString() ?? @Url.Action("Index", "Familias");
            return Redirect(route);

        }

        private bool FamiliaExists(int id)
        {
            return _context.Familia.Any(e => e.IdFamilia == id);
        }

        public async Task<ActionResult> ValidateFamilyName(string NomeFamilia, int IdFamilia)
        {
            var val_nomefamilia = await _context.Familia
            .SingleOrDefaultAsync(m => m.NomeFamilia == NomeFamilia);
            if (val_nomefamilia == null || val_nomefamilia.IdFamilia == IdFamilia) return Json(true);
            else return Json(string.Format("Já existe uma família com o nome {0}.", NomeFamilia));
        }
    }
}
