using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bioterio.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Bioterio.Controllers
{
    [Authorize(Policy = "AdminRights")]
    public class GruposController : Controller
    {
        private readonly bd_lesContext _context;

        public GruposController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Grupos
        public async Task<IActionResult> Index()
        {
            TempData["origin_controller"] = @Url.Action("Index", "Grupos");
            return View(await _context.Grupo.ToListAsync());
        }

        // GET: Grupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupo
                .SingleOrDefaultAsync(m => m.IdGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // GET: Grupos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrupo,NomeGrupo")] Grupo grupo)
        {
            //validation
            var val_nome = await _context.Grupo
                .SingleOrDefaultAsync(m => m.NomeGrupo == grupo.NomeGrupo);
            if (val_nome != null)
            {
                ModelState.AddModelError("NomeGrupo", string.Format("Já existe um grupo com o nome {0}.", grupo.NomeGrupo));
            }

            if (ModelState.IsValid)
            {
                _context.Add(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupo);
        }

        // GET: Grupos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupo.SingleOrDefaultAsync(m => m.IdGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }
            return View(grupo);
        }

        // POST: Grupos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrupo,NomeGrupo")] Grupo grupo)
        {
            if (id != grupo.IdGrupo)
            {
                return NotFound();
            }

            //validation
            var val_nome = await _context.Grupo
                .SingleOrDefaultAsync(m => m.NomeGrupo == grupo.NomeGrupo);
            if (val_nome != null && val_nome.IdGrupo != grupo.IdGrupo)
            {
                ModelState.AddModelError("NomeGrupo", string.Format("Já existe um grupo com o nome {0}.", grupo.NomeGrupo));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var old_grupo = await _context.Grupo
                .SingleOrDefaultAsync(m => m.IdGrupo == id);
                    _context.Entry(old_grupo).CurrentValues.SetValues(grupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoExists(grupo.IdGrupo))
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
            return View(grupo);
        }

        // GET: Grupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupo
                .SingleOrDefaultAsync(m => m.IdGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            //get families and species belonging to group
            var familias = await _context.Familia
                .Include(f => f.Especie)
                    .ThenInclude(e => e.RegNovosAnimais)
                        .ThenInclude(r => r.FornecedorIdFornColectNavigation)
                .Where(f => f.GrupoIdGrupo == id)
                .ToListAsync();
            var especies = new List<Especie>();
            foreach (var f in familias) {
                especies.AddRange(f.Especie);
            }
            ViewData["familias"] = familias;

            //check if species belonging to group have associations with registers
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
                return View("DeleteDenied", grupo);
            }
            else
            {
                ViewData["especies"] = especies;
                return View(grupo);
            }
        }

        // POST: Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupo = await _context.Grupo.SingleOrDefaultAsync(m => m.IdGrupo == id);
            var familias = await _context.Familia
                .Include(f => f.Especie)
                .Where(f => f.GrupoIdGrupo == id)
                .ToListAsync();
            var especies = new List<Especie>();
            foreach (var f in familias)
            {
                especies.AddRange(f.Especie);
            }
            _context.Grupo.Remove(grupo);
            _context.Familia.RemoveRange(familias);
            _context.Especie.RemoveRange(especies);
            await _context.SaveChangesAsync();

            TempData["deleted_name"] = grupo.NomeGrupo;
            TempData["deleted_entity"] = "grupo";
            TempData["deleted"] = true;

            string route = TempData["origin_controller"].ToString() ?? @Url.Action("Index", "Grupos");
            return Redirect(route);
        }

        private bool GrupoExists(int id)
        {
            return _context.Grupo.Any(e => e.IdGrupo == id);
        }

        [HttpPost]
        public string GetFamilyList(string id)
        {
            string result = null;
            try
            {
                int IdGrupo = Convert.ToInt32(id);
                List<Familia> familias = _context.Familia
                    .Where(f => f.GrupoIdGrupo == IdGrupo)
                    .ToList();
                result = JsonConvert.SerializeObject(familias);
            }
            catch (FormatException)
            {
            }
            Console.WriteLine(result);
            return result;
        }

        public async Task<ActionResult> ValidateGroupName(string NomeGrupo, int IdGrupo)
        {
            var val_nomegrupo = await _context.Grupo
            .SingleOrDefaultAsync(m => m.NomeGrupo == NomeGrupo);
            if (val_nomegrupo == null || val_nomegrupo.IdGrupo == IdGrupo) return Json(true);
            else return Json(string.Format("Já existe um grupo com o nome {0}.", NomeGrupo));
        }
    }
}
