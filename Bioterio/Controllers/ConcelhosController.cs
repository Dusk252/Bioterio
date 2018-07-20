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
    public class ConcelhosController : Controller
    {
        private readonly bd_lesContext _context;

        public ConcelhosController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Concelhos
        [Authorize(Roles = "Administrator, ReadLocalizacao")]
        public async Task<IActionResult> Index()
        {
            TempData["origin_controller"] = @Url.Action("Index", "Concelhos");
            var bd_lesContext = _context.Concelho.Include(c => c.Distrito);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Concelhos/Details/5
        [Authorize(Roles = "Administrator, ReadLocalizacao")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concelho = await _context.Concelho
                .Include(c => c.Distrito)
                .SingleOrDefaultAsync(m => m.IdConcelho == id);
            if (concelho == null)
            {
                return NotFound();
            }

            return View(concelho);
        }

        // GET: Concelhos/Create
        [Authorize(Roles = "Administrator, CreateLocalizacao")]
        public IActionResult Create()
        {
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "IdDistrito", "NomeDistrito").Prepend(new SelectListItem() { Text = "---Selecione um Distrito---", Value = "" }); ;
            return View();
        }

        // POST: Concelhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, CreateLocalizacao")]
        public async Task<IActionResult> Create([Bind("Id,NomeConcelho,DistritoId")] Concelho concelho)
        {
            //validation
            var val_nome = await _context.Concelho
                .SingleOrDefaultAsync(m => m.NomeConcelho == concelho.NomeConcelho);
            if (val_nome != null && val_nome.NomeConcelho != concelho.NomeConcelho)
            {
                ModelState.AddModelError("NomeDistrito", string.Format("Já existe um concelho com o nome {0}.", concelho.NomeConcelho));
            }
            if (ModelState.IsValid)
            {
                _context.Add(concelho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "IdDistrito", "NomeDistrito", concelho.DistritoId).Prepend(new SelectListItem() { Text = "---Selecione um Distrito---", Value = "" }); ;
            return View(concelho);
        }

        // GET: Concelhos/Edit/5
        [Authorize(Roles = "Administrator, EditLocalizacao")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concelho = await _context.Concelho.SingleOrDefaultAsync(m => m.IdConcelho == id);
            if (concelho == null)
            {
                return NotFound();
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "IdDistrito", "NomeDistrito", concelho.DistritoId).Prepend(new SelectListItem() { Text = "---Selecione um Distrito---", Value = "" }); ;
            return View(concelho);
        }

        // POST: Concelhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, EditLocalizacao")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeConcelho,DistritoId")] Concelho concelho)
        {
            if (id != concelho.IdConcelho)
            {
                return NotFound();
            }

            //validation
            var val_nome = await _context.Concelho
                .SingleOrDefaultAsync(m => m.NomeConcelho == concelho.NomeConcelho);
            if (val_nome != null && val_nome.NomeConcelho != concelho.NomeConcelho)
            {
                ModelState.AddModelError("NomeDistrito", string.Format("Já existe um concelho com o nome {0}.", concelho.NomeConcelho));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concelho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcelhoExists(concelho.IdConcelho))
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
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "IdDistrito", "NomeDistrito", concelho.DistritoId).Prepend(new SelectListItem() { Text = "---Selecione um Distrito---", Value = "" }); ;
            return View(concelho);
        }

        // GET: Concelhos/Delete/5
        [Authorize(Roles = "Administrator, DeleteLocalizacao")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concelho = await _context.Concelho
                .Include(c => c.Distrito)
                .Include(c => c.Localcaptura)
                    .ThenInclude(l => l.RegNovosAnimais)
                .SingleOrDefaultAsync(m => m.IdConcelho == id);
            if (concelho == null)
            {
                return NotFound();
            }
            List<Localcaptura> bound = new List<Localcaptura>();
            foreach(Localcaptura c in concelho.Localcaptura)
            {
                if (c.RegNovosAnimais.Count > 0)
                {
                    bound.Add(c);
                }
            }
            if (bound.Count > 0)
            {
                return View("DeleteDenied", concelho);
            }

            return View(concelho);
        }

        // POST: Concelhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, DeleteLocalizacao")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concelho = await _context.Concelho
                .Include(c => c.Distrito)
                .SingleOrDefaultAsync(m => m.IdConcelho == id);
            _context.Concelho.Remove(concelho);
            await _context.SaveChangesAsync();

            var check_if_more = await _context.Concelho.FirstOrDefaultAsync(m => m.DistritoId == concelho.DistritoId);
            if (check_if_more == null)
            {
                TempData["more"] = false;
                TempData["id"] = concelho.DistritoId;
                TempData["name"] = concelho.Distrito.NomeDistrito;
                TempData["controller"] = "Distritos";
                TempData["empty"] = "distrito";
            }
            TempData["deleted_name"] = concelho.NomeConcelho;
            TempData["deleted_entity"] = "concelho";
            TempData["deleted"] = true;

            string route = TempData["origin_controller"].ToString() ?? @Url.Action("Index", "Concelhos");
            return Redirect(route);
        }

        private bool ConcelhoExists(int id)
        {
            return _context.Concelho.Any(e => e.IdConcelho == id);
        }

        public async Task<ActionResult> ValidateConcelhoName(string NomeConcelho, int IdConcelho)
        {
            var val_nomeconcelho = await _context.Concelho
            .SingleOrDefaultAsync(m => m.NomeConcelho == NomeConcelho);
            if (val_nomeconcelho == null || val_nomeconcelho.IdConcelho == IdConcelho) return Json(true);
            else return Json(string.Format("Já existe um concelho com o nome {0}.", NomeConcelho));
        }
    }
}
