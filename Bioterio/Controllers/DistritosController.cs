using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bioterio.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Bioterio.Controllers
{
    [Authorize(Policy = "AdminRights")]
    public class DistritosController : Controller
    {
        private readonly bd_lesContext _context;

        public DistritosController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Distritos
        public async Task<IActionResult> Index()
        {
            TempData["origin_controller"] = @Url.Action("Index", "Distritos");
            return View(await _context.Distrito.ToListAsync());
        }

        // GET: Distritos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distrito
                .SingleOrDefaultAsync(m => m.IdDistrito == id);
            if (distrito == null)
            {
                return NotFound();
            }

            return View(distrito);
        }

        // GET: Distritos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Distritos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeDistrito")] Distrito distrito)
        {
            //validation
            var val_nome = await _context.Distrito
                .SingleOrDefaultAsync(m => m.NomeDistrito == distrito.NomeDistrito);
            if (val_nome != null)
            {
                ModelState.AddModelError("NomeDistrito", string.Format("Já existe um distrito com o nome {0}.", distrito.NomeDistrito));
            }
            if (ModelState.IsValid)
            {
                _context.Add(distrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(distrito);
        }

        // GET: Distritos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distrito.SingleOrDefaultAsync(m => m.IdDistrito == id);
            if (distrito == null)
            {
                return NotFound();
            }
            return View(distrito);
        }

        // POST: Distritos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeDistrito")] Distrito distrito)
        {
            if (id != distrito.IdDistrito)
            {
                return NotFound();
            }

            //validation
            var val_nome = await _context.Distrito
                .SingleOrDefaultAsync(m => m.NomeDistrito == distrito.NomeDistrito);
            if (val_nome != null  && val_nome.IdDistrito != distrito.IdDistrito)
            {
                ModelState.AddModelError("NomeDistrito", string.Format("Já existe um distrito com o nome {0}.", distrito.NomeDistrito));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(distrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistritoExists(distrito.IdDistrito))
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
            return View(distrito);
        }

        // GET: Distritos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distrito
                .Include(e => e.Localcaptura)
                    .ThenInclude(r => r.RegNovosAnimais)
                .SingleOrDefaultAsync(m => m.IdDistrito == id);
            if (distrito == null)
            {
                return NotFound();
            }

            List<Localcaptura> bound = new List<Localcaptura>();

                foreach (Localcaptura c in distrito.Localcaptura)
                {
                    if (c.RegNovosAnimais.Count > 0)
                    {
                        bound.Add(c);
                    }
                }
                if (bound.Count > 0)
                {
                    return View("DeleteDenied", distrito);
                }

            var concelhos = await _context.Concelho
                .Where(c => c.DistritoId == id)
                .ToListAsync();

            ViewData["concelhos"] = concelhos;

            return View(distrito);
        }

        // POST: Distritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var distrito = await _context.Distrito
                .Include(d => d.Concelho)
                .Include(d => d.Localcaptura)
                .SingleOrDefaultAsync(m => m.IdDistrito == id);
            _context.Distrito.Remove(distrito);
            _context.Concelho.RemoveRange(distrito.Concelho);
            _context.Localcaptura.RemoveRange(distrito.Localcaptura);
            await _context.SaveChangesAsync();

            TempData["deleted_name"] = distrito.NomeDistrito;
            TempData["deleted_entity"] = "distrito";
            TempData["deleted"] = true;

            string route = TempData["origin_controller"].ToString() ?? @Url.Action("Index", "Distritos");
            return Redirect(route);
        }

        private bool DistritoExists(int id)
        {
            return _context.Distrito.Any(e => e.IdDistrito == id);
        }

        [HttpPost]
        public string GetConcelhosList(string id)
        {
            string result = null;
            try
            {
                int IdDistrito = Convert.ToInt32(id);
                List<Concelho> concelhos = _context.Concelho
                    .Where(c => c.DistritoId == IdDistrito)
                    .ToList();
                result = JsonConvert.SerializeObject(concelhos);
            }
            catch (FormatException)
            {
            }
            Console.WriteLine(result);
            return result;
        }

        public async Task<ActionResult> ValidateDistritoName(string NomeDistrito, int IdDistrito)
        {
            var val_nomegrupo = await _context.Distrito
            .SingleOrDefaultAsync(m => m.NomeDistrito == NomeDistrito);
            if (val_nomegrupo == null || val_nomegrupo.IdDistrito == IdDistrito) return Json(true);
            else return Json(string.Format("Já existe um distrito com o nome {0}.", NomeDistrito));
        }
    }
}
