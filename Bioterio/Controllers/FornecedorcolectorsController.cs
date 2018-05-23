using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bioterio.Models;
using System.Text.RegularExpressions;

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fornecedorcolector.ToListAsync());
        }

        // GET: Fornecedorcolectors/Details/5
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

            string tipo = fornecedorcolector.Tipo.Equals("c") ? "Colector" : "Fornecedor";
            ViewData["tipo_string"] = tipo;
            return View(fornecedorcolector);
        }

        // GET: Fornecedorcolectors/Create
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
        public async Task<IActionResult> Create([Bind("IdFornColect,Tipo,Nome,Nif,NroLicenca,Morada,Telefone")] Fornecedorcolector fornecedorcolector)
        {

            //validation
            if (fornecedorcolector.Tipo == null)
            {
                ModelState.AddModelError("Tipo", "Por favor escolha um tipo.");
            }
            if (fornecedorcolector.Nome == null)
            {
                ModelState.AddModelError("Nome", "O nome é um campo requirido.");
            }
            if (fornecedorcolector.Nif == null)
            {
                ModelState.AddModelError("Nif", "O NIF é um campo requirido.");
            }
            else if (!validateNIF(fornecedorcolector.Nif)) {
                ModelState.AddModelError("Nif", "Insira um NIF válido.");
            }
            if (fornecedorcolector.NroLicenca == null)
            {
                ModelState.AddModelError("NroLicenca", "O número de licença é um campo requirido.");
            }
            /*if (Regex.IsMatch(fornecedorcolector.NroLicenca.ToString(), @"\D"))
            {
                ModelState.AddModelError("Licença", "Insira um número de licença válido.");
            }
            if (!int.TryParse(fornecedorcolector.NroLicenca.ToString(), out int i))
            {
                ModelState.AddModelError("Licença", "Insira um número de licença válido.");
            }*/
            if (fornecedorcolector.Morada == null)
            {
                ModelState.AddModelError("Morada", "A morada é um campo requirido.");
            }
            if (fornecedorcolector.Telefone == null)
            {
                ModelState.AddModelError("Telefone", "O telefone é um campo requirido.");
            }
            else if (!Regex.IsMatch(fornecedorcolector.Telefone, @"^\+?[\s\d]*$")) {
                ModelState.AddModelError("Telefone", "Insira um número de telefone válido.");
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
        public async Task<IActionResult> Edit(int id, [Bind("IdFornColect,Tipo,Nome,Nif,NroLicenca,Morada,Telefone")] Fornecedorcolector fornecedorcolector)
        {
            if (id != fornecedorcolector.IdFornColect)
            {
                return NotFound();
            }

            //validation
            if (fornecedorcolector.Tipo == null)
            {
                ModelState.AddModelError("Tipo", "Por favor escolha um tipo.");
            }
            if (fornecedorcolector.Nome == null)
            {
                ModelState.AddModelError("Nome", "O nome é um campo requirido.");
            }
            if (fornecedorcolector.Nif == null)
            {
                ModelState.AddModelError("Nif", "O NIF é um campo requirido.");
            }
            else if (!validateNIF(fornecedorcolector.Nif))
            {
                ModelState.AddModelError("Nif", "Insira um NIF válido.");
            }

            if (fornecedorcolector.NroLicenca == null)
            {
                ModelState.AddModelError("NroLicenca", "O número de licença é um campo requirido.");
            }
            if (fornecedorcolector.Morada == null)
            {
                ModelState.AddModelError("Morada", "A morada é um campo requirido.");
            }
            if (fornecedorcolector.Telefone == null)
            {
                ModelState.AddModelError("Telefone", "O telefone é um campo requirido.");
            }
            else if (!Regex.IsMatch(fornecedorcolector.Telefone, @"^\+?[\s\d]*$"))
            {
                ModelState.AddModelError("Telefone", "Insira um número de telefone válido.");
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
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Fornecedorcolectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
    }
}
