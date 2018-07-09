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
    public class RegNovosAnimaisController : Controller
    {
        private readonly bd_lesContext _context;

        public RegNovosAnimaisController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: RegNovosAnimais
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.RegNovosAnimais.Include(r => r.FornecedorIdFornColectNavigation).Include(r => r.FuncionarioIdFuncionario1Navigation).Include(r => r.FuncionarioIdFuncionarioNavigation).Include(r => r.TOrigemIdTOrigemNavigation).Include(r => r.TipoEstatutoGeneticoIdTipoEstatutoGeneticoNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: RegNovosAnimais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regNovosAnimais = await _context.RegNovosAnimais
                .Include(r => r.FornecedorIdFornColectNavigation)
                .Include(r => r.FuncionarioIdFuncionario1Navigation)
                .Include(r => r.FuncionarioIdFuncionarioNavigation)
                .Include(r => r.TOrigemIdTOrigemNavigation)
                .Include(r => r.TipoEstatutoGeneticoIdTipoEstatutoGeneticoNavigation)
                .SingleOrDefaultAsync(m => m.IdRegAnimal == id);
            if (regNovosAnimais == null)
            {
                return NotFound();
            }

            return View(regNovosAnimais);
        }

        [Authorize(Policy = "ElevatedRights")]
        // GET: RegNovosAnimais/Create
        public IActionResult Create()
        {
            ViewData["EspecieIdEspecie"] = new SelectList(_context.Especie, "IdEspecie", "NomeCient").Prepend(new SelectListItem() { Text = "---Selecione uma Espécie---", Value = "" });
            ViewData["FornecedorIdFornColect"] = new SelectList(_context.Fornecedorcolector, "IdFornColect", "Nome").Prepend(new SelectListItem() { Text = "---Selecione um Fornecedor/Colector---", Value = "" });
            ViewData["FuncionarioIdFuncionario1"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto").Prepend(new SelectListItem() { Text = "---Selecione um Funcionário---", Value = "" });
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto").Prepend(new SelectListItem() { Text = "---Selecione um Funcionário---", Value = "" });
            var locais =
              _context.Localcaptura
                .Select(s => new
                {
                    LocalId = s.IdLocalCaptura,
                    Description = string.Format("{0} ({1} {2})", s.Localidade, s.Latitude, s.Longitude)
                })
                .ToList();
            ViewData["LocalCapturaIdLocalCaptura"] = new SelectList(locais, "LocalId", "Description").Prepend(new SelectListItem() { Text = "---Selecione um Local de Captura---", Value = "" });
            ViewData["TOrigem"] = new List<TOrigem>(_context.TOrigem);
            ViewData["TOrigem"] = new List<TOrigem>(_context.TOrigem);
            ViewData["TipoEstatutoGenetico"] = new List<Tipoestatutogenetico>(_context.Tipoestatutogenetico);
            return View();
        }

        // POST: RegNovosAnimais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Policy = "ElevatedRights")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegAnimal,NroExemplares,NroMachos,NroFemeas,Imaturos,Juvenis,Larvas,Ovos,DataNasc,Idade,PesoMedio,CompMedio,DuracaoViagem,TempPartida,TempChegada,NroContentores,TipoContentor,VolContentor,VolAgua,NroCaixasIsoter,NroMortosCheg,SatO2transp,Anestesico,Gelo,AdicaoO2,Arejamento,Refrigeracao,sedacao,RespTransporte,EspecieIdEspecie,FornecedorIdFornColect,TOrigemIdTOrigem,LocalCapturaIdLocalCaptura,TipoEstatutoGeneticoIdTipoEstatutoGenetico,FuncionarioIdFuncionario,FuncionarioIdFuncionario1")] RegNovosAnimais regNovosAnimais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regNovosAnimais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecieIdEspecie"] = new SelectList(_context.Especie, "IdEspecie", "NomeCient").Prepend(new SelectListItem() { Text = "---Selecione uma Espécie---", Value = "" });
            ViewData["FornecedorIdFornColect"] = new SelectList(_context.Fornecedorcolector, "IdFornColect", "Nome").Prepend(new SelectListItem() { Text = "---Selecione um Fornecedor/Colector---", Value = "" });
            ViewData["FuncionarioIdFuncionario1"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto").Prepend(new SelectListItem() { Text = "---Selecione um Funcionário---", Value = "" });
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto").Prepend(new SelectListItem() { Text = "---Selecione um Funcionário---", Value = "" });
            var locais =
              _context.Localcaptura
                .Select(s => new
                {
                    LocalId = s.IdLocalCaptura,
                    Description = string.Format("{0} ({1} {2})", s.Localidade, s.Latitude, s.Longitude)
                })
                .ToList();
            ViewData["LocalCapturaIdLocalCaptura"] = new SelectList(locais, "LocalId", "Description").Prepend(new SelectListItem() { Text = "---Selecione um Local de Captura---", Value = "" });
            ViewData["TOrigem"] = new List<TOrigem>(_context.TOrigem);
            ViewData["TOrigem"] = new List<TOrigem>(_context.TOrigem);
            ViewData["TipoEstatutoGenetico"] = new List<Tipoestatutogenetico>(_context.Tipoestatutogenetico);
            return View(regNovosAnimais);
        }

        // GET: RegNovosAnimais/Edit/5
        [Authorize(Policy = "ElevatedRights")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regNovosAnimais = await _context.RegNovosAnimais.SingleOrDefaultAsync(m => m.IdRegAnimal == id);
            if (regNovosAnimais == null)
            {
                return NotFound();
            }
            ViewData["EspecieIdEspecie"] = new SelectList(_context.Especie, "IdEspecie", "NomeCient").Prepend(new SelectListItem() { Text = "---Selecione uma Espécie---", Value = "" });
            ViewData["FornecedorIdFornColect"] = new SelectList(_context.Fornecedorcolector, "IdFornColect", "Nome").Prepend(new SelectListItem() { Text = "---Selecione um Fornecedor/Colector---", Value = "" });
            ViewData["FuncionarioIdFuncionario1"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto").Prepend(new SelectListItem() { Text = "---Selecione um Funcionário---", Value = "" });
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto").Prepend(new SelectListItem() { Text = "---Selecione um Funcionário---", Value = "" });
            var locais =
              _context.Localcaptura
                .Select(s => new
                {
                    LocalId = s.IdLocalCaptura,
                    Description = string.Format("{0} ({1} {2})", s.Localidade, s.Latitude, s.Longitude)
                })
                .ToList();
            ViewData["LocalCapturaIdLocalCaptura"] = new SelectList(locais, "LocalId", "Description").Prepend(new SelectListItem() { Text = "---Selecione um Local de Captura---", Value = "" });
            ViewData["TOrigem"] = new List<TOrigem>(_context.TOrigem);
            ViewData["TipoEstatutoGenetico"] = new List<Tipoestatutogenetico>(_context.Tipoestatutogenetico);
            return View(regNovosAnimais);
        }

        // POST: RegNovosAnimais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Policy = "ElevatedRights")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegAnimal,NroExemplares,NroMachos,NroFemeas,Imaturos,Juvenis,Larvas,Ovos,DataNasc,Idade,PesoMedio,CompMedio,DuracaoViagem,TempPartida,TempChegada,NroContentores,TipoContentor,VolContentor,VolAgua,NroCaixasIsoter,NroMortosCheg,SatO2transp,Anestesico,Gelo,AdicaoO2,Arejamento,Refrigeracao,sedacao,RespTransporte,EspecieIdEspecie,FornecedorIdFornColect,TOrigemIdTOrigem,LocalCapturaIdLocalCaptura,TipoEstatutoGeneticoIdTipoEstatutoGenetico,FuncionarioIdFuncionario,FuncionarioIdFuncionario1")] RegNovosAnimais regNovosAnimais)
        {
            if (id != regNovosAnimais.IdRegAnimal)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regNovosAnimais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegNovosAnimaisExists(regNovosAnimais.IdRegAnimal))
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
            ViewData["EspecieIdEspecie"] = new SelectList(_context.Especie, "IdEspecie", "NomeCient").Prepend(new SelectListItem() { Text = "---Selecione uma Espécie---", Value = "" });
            ViewData["FornecedorIdFornColect"] = new SelectList(_context.Fornecedorcolector, "IdFornColect", "Nome").Prepend(new SelectListItem() { Text = "---Selecione um Fornecedor/Colector---", Value = "" });
            ViewData["FuncionarioIdFuncionario1"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto").Prepend(new SelectListItem() { Text = "---Selecione um Funcionário---", Value = "" });
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto").Prepend(new SelectListItem() { Text = "---Selecione um Funcionário---", Value = "" });
            var locais =
              _context.Localcaptura
                .Select(s => new
                {
                    LocalId = s.IdLocalCaptura,
                    Description = string.Format("{0} ({1} {2})", s.Localidade, s.Latitude, s.Longitude)
                })
                .ToList();
            ViewData["LocalCapturaIdLocalCaptura"] = new SelectList(locais, "LocalId", "Description").Prepend(new SelectListItem() { Text = "---Selecione um Local de Captura---", Value = "" });
            ViewData["TOrigem"] = new List<TOrigem>(_context.TOrigem);
            ViewData["TipoEstatutoGenetico"] = new List<Tipoestatutogenetico>(_context.Tipoestatutogenetico);
            return View(regNovosAnimais);
        }

        // GET: RegNovosAnimais/Delete/5
        [Authorize(Policy = "ElevatedRights")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //TO DO: remove eager loading for unused properties
            var regNovosAnimais = await _context.RegNovosAnimais
                .Include(r => r.FornecedorIdFornColectNavigation)
                .Include(r => r.FuncionarioIdFuncionario1Navigation)
                .Include(r => r.FuncionarioIdFuncionarioNavigation)
                .Include(r => r.TOrigemIdTOrigemNavigation)
                .Include(r => r.TipoEstatutoGeneticoIdTipoEstatutoGeneticoNavigation)
                .Include(r => r.Lote)
                .SingleOrDefaultAsync(m => m.IdRegAnimal == id);

            if (regNovosAnimais == null)
            {
                return NotFound();
            }

            //check if bound to lot
            if (regNovosAnimais.Lote.Count > 0)
            {
                return View("DeleteDenied", regNovosAnimais);
            }
            else
            {
                return View(regNovosAnimais);
            }
        }

        // POST: RegNovosAnimais/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "ElevatedRights")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regNovosAnimais = await _context.RegNovosAnimais
                .Include(e => e.EspecieIdEspecieNavigation)
                .SingleOrDefaultAsync(m => m.IdRegAnimal == id);
            var lotes_locked = await _context.Lote
                .Where(m => m.RegNovosAnimaisIdRegAnimal == regNovosAnimais.IdRegAnimal)
                .ToListAsync();
            if (lotes_locked == null)
            {
                _context.RegNovosAnimais.Remove(regNovosAnimais);

                TempData["deleted_name"] = regNovosAnimais.EspecieIdEspecieNavigation.NomeCient + "|" + regNovosAnimais.NroExemplares;
                TempData["deleted_entity"] = "registo";
                TempData["deleted"] = true;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Delete));
            }

        }

        private bool RegNovosAnimaisExists(int id)
        {
            return _context.RegNovosAnimais.Any(e => e.IdRegAnimal == id);
        }

    }
}
