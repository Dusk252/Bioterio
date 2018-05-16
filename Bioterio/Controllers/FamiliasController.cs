using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bioterio.Models;

namespace Bioterio.Controllers
{
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
            if (familia.NomeFamilia == null)
            {
                ModelState.AddModelError("NomeFamilia", "O nome é um campo requirido.");
            }
            if (familia.GrupoIdGrupo == 0)
            {
                ModelState.AddModelError("GrupoId", "É requirido que cada família pertença a um grupo.");
            }

            var val_nome = await _context.Familia
                .SingleOrDefaultAsync(m => m.NomeFamilia == familia.NomeFamilia);
            if (val_nome != null)
            {
                ModelState.AddModelError("NomeFamilia", "Não podem existir duas familias com o mesmo nome.");
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
            //ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "NomeGrupo", familia.GrupoIdGrupo);
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
            if (familia.NomeFamilia == null)
            {
                ModelState.AddModelError("NomeFamilia", "O nome é um campo requirido.");
            }
            if (familia.GrupoIdGrupo == 0)
            {
                ModelState.AddModelError("GrupoIdGrupo", "É requirido que cada família pertença a um grupo.");
            }

            var val_nome = await _context.Familia
                .SingleOrDefaultAsync(m => m.NomeFamilia == familia.NomeFamilia);
            if (val_nome != null && val_nome.IdFamilia != familia.IdFamilia)
            {
                ModelState.AddModelError("NomeFamilia", "Não podem existir duas familias com o mesmo nome.");
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
            ViewData["GrupoIdGrupo"] = new SelectList(_context.Grupo, "IdGrupo", "NomeGrupo", familia.GrupoIdGrupo);
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

            var especies = await _context.Especie
                .Where(m => m.FamiliaIdFamilia == id)
                .ToListAsync();

            ViewData["especies"] = especies;

            return View(familia);
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
    }
}
