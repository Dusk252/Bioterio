using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bioterio.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

namespace Bioterio.Controllers
{
    public class FornecedorcolectorsController : Controller
    {
        private readonly bd_lesContext _context;

        private SelectList types = new SelectList(new List<SelectListItem>() {
                new SelectListItem() { Text = "---Selecione um Tipo---", Value = "" },
                new SelectListItem() { Text = "Colector", Value = "c" },
                new SelectListItem() { Text = "Fornecedor", Value = "f" } }, "Value", "Text");

        public FornecedorcolectorsController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Fornecedorcolectors
        [Authorize(Roles = "Administrator, ReadFornecedor")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fornecedorcolector.ToListAsync());
        }

        // GET: Fornecedorcolectors/Details/5
        [Authorize(Roles = "Administrator, ReadFornecedor")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorcolector = await _context.Fornecedorcolector
                .SingleOrDefaultAsync(m => m.IdFornColect == id);
            if (fornecedorcolector == null)
            {
                return NotFound();
            }

            return View(fornecedorcolector);
        }

        // GET: Fornecedorcolectors/Create
        [Authorize(Roles = "Administrator, CreateFornecedor")]
        public IActionResult Create()
        {
            ViewData["Tipo"] = types;
            return View();
        }

        // POST: Fornecedorcolectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, CreateFornecedor")]
        public async Task<IActionResult> Create([Bind("IdFornColect,Tipo,Nome,Nif,NroLicenca,Morada,Telefone")] Fornecedorcolector fornecedorcolector)
        {
            //validation
            if (!validateNIF(fornecedorcolector.Nif))
            {
                ModelState.AddModelError("Nif", "Insira um NIF válido.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(fornecedorcolector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Tipo"] = types;
            return View(fornecedorcolector);
        }

        // GET: Fornecedorcolectors/Edit/5
        [Authorize(Roles = "Administrator, EditFornecedor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorcolector = await _context.Fornecedorcolector.SingleOrDefaultAsync(m => m.IdFornColect == id);
            if (fornecedorcolector == null)
            {
                return NotFound();
            }

            ViewData["Tipo"] = types;
            return View(fornecedorcolector);
        }

        // POST: Fornecedorcolectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, EditFornecedor")]
        public async Task<IActionResult> Edit(int id, [Bind("IdFornColect,Tipo,Nome,Nif,NroLicenca,Morada,Telefone")] Fornecedorcolector fornecedorcolector)
        {
            if (id != fornecedorcolector.IdFornColect)
            {
                return NotFound();
            }

            //validation
            if (!validateNIF(fornecedorcolector.Nif))
            {
                ModelState.AddModelError("Nif", "Insira um NIF válido.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedorcolector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorcolectorExists(fornecedorcolector.IdFornColect))
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

            ViewData["Tipo"] = types;
            return View(fornecedorcolector);
        }

        // GET: Fornecedorcolectors/Delete/5
        [Authorize(Roles = "Administrator, DeleteFornecedor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorcolector = await _context.Fornecedorcolector
                .Include(f => f.RegNovosAnimais)
                    .ThenInclude(r => r.EspecieIdEspecieNavigation)
                .SingleOrDefaultAsync(m => m.IdFornColect == id);

            if (fornecedorcolector == null)
            {
                return NotFound();
            }

            //check if bound to register
            if (fornecedorcolector.RegNovosAnimais.Count > 0)
            {
                return View("DeleteDenied", fornecedorcolector);
            }
            else
            {
                return View(fornecedorcolector);
            }
        }

        // POST: Fornecedorcolectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, DeleteFornecedor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedorcolector = await _context.Fornecedorcolector.SingleOrDefaultAsync(m => m.IdFornColect == id);
            _context.Fornecedorcolector.Remove(fornecedorcolector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorcolectorExists(int id)
        {
            return _context.Fornecedorcolector.Any(e => e.IdFornColect == id);
        }

        private bool validateNIF(int? nif)
        {
            int[] nif_array = Array.ConvertAll(nif.ToString().ToArray(), c => (int)Char.GetNumericValue(c));
            //check lenght
            if (nif_array.Length != 9) return false;
            //check first digit
            if (nif_array[0] != 1 && nif_array[0] != 2 && nif_array[0] != 5) return false;
            //checkbit validation
            int checkbit = nif_array[0] * 9;
            for (int i = 2; i <= 8; i++)
            {
                checkbit += nif_array[i - 1] * (10 - i);
            }
            checkbit = 11 - (checkbit % 11);
            if (checkbit >= 10) checkbit = 0;
            if (nif_array[8] == checkbit) return true;
            return false;
        }

        public ActionResult ValidateNIF(int NIF)
        {
            if(validateNIF(NIF)) return Json(true);
            else return Json("Insira um NIF válido.");
        }
    }
}
