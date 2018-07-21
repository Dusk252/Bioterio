using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bioterio.Models;
using Bioterio.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Bioterio.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly bd_lesContext _context;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public FuncionariosController(bd_lesContext context, UserManager<ApplicationUsers> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Funcionarios
        [Authorize(Roles = "Administrator, ReadUtilizador")]
        public async Task<IActionResult> Index()
        {
            var func_list = await _context.Funcionario
                .ToListAsync();
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (Funcionario f in func_list) {
                var user = await _context.ApplicationUsers
                    .Include(u => u.PerfilNavigation)
                    .SingleOrDefaultAsync(u => u.FuncionarioIdFuncionario == f.IdFuncionario);
                UserViewModel uvm = new UserViewModel { UserName = user.UserName, NomeCompleto = f.NomeCompleto, PhoneNumber = user.PhoneNumber, IdFuncionario = f.IdFuncionario, IdPerfil = user.PerfilNavigation.IdPerfil, NomePerfil = user.PerfilNavigation.NomePerfil };
                userViewModels.Add(uvm);
            }

            return View(userViewModels);
        }

        // GET: Funcionarios/Details/5
        [Authorize(Roles = "Administrator, ReadUtilizador")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .SingleOrDefaultAsync(m => m.IdFuncionario == id);

            var user = await _context.ApplicationUsers
                .Include(u => u.PerfilNavigation)
                .SingleOrDefaultAsync(u => u.FuncionarioIdFuncionario == id);

            if (funcionario == null || user == null)
            {
                return NotFound();
            }

            return View(new UserViewModel { UserName = user.UserName, NomeCompleto = funcionario.NomeCompleto, PhoneNumber = user.PhoneNumber, IdFuncionario = funcionario.IdFuncionario, IdPerfil = user.PerfilNavigation.IdPerfil, NomePerfil = user.PerfilNavigation.NomePerfil } );
        }

        // GET: Funcionarios/Create
        [Authorize(Roles = "Administrator, CreateUtilizador")]
        public IActionResult Create()
        {
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdPerfil", "NomePerfil").Prepend(new SelectListItem() { Text = "---Selecione um Perfil---", Value = "" });
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, CreateUtilizador")]
        public async Task<IActionResult> Create(RegisterViewModel registerViewModel)
        {
            var user2 = await _userManager.FindByNameAsync(registerViewModel.UserName);
            if (user2 != null)
            {
                ModelState.AddModelError("UserName", string.Format("Já existe um utilizador com o nome {0}.", registerViewModel.UserName));
            }
            if (ModelState.IsValid)
            {
                var func = new Funcionario { NomeCompleto = registerViewModel.NomeCompleto };
                if (registerViewModel.NomeCompleto != null)
                {
                    _context.Add(func);
                    await _context.SaveChangesAsync();
                }
                var user = new ApplicationUsers { UserName = registerViewModel.UserName, PhoneNumber = registerViewModel.PhoneNumber, FuncionarioIdFuncionario = func.IdFuncionario, IdPerfil = registerViewModel.IdPerfil };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    List<ProfileRole> roles = await _context.ProfileRole
                        .Where(p => p.IdPerfil == user.IdPerfil)
                        .ToListAsync();
                    foreach(ProfileRole role in roles)
                    {
                        string role_name = _roleManager.FindByIdAsync(role.RoleId).Result.Name;
                        if (await _roleManager.RoleExistsAsync(role_name))
                            await _userManager.AddToRoleAsync(user, role_name);
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _context.Remove(func);
                    await _context.SaveChangesAsync();
                }
            }
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdPerfil", "NomePerfil").Prepend(new SelectListItem() { Text = "---Selecione um Perfil---", Value = "" });
            return View(registerViewModel);
        }

        // GET: Funcionarios/Edit/5
        [Authorize(Roles = "Administrator, EditUtilizador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .SingleOrDefaultAsync(m => m.IdFuncionario == id);

            var user = await _context.ApplicationUsers
                .Include(u => u.PerfilNavigation)
                .SingleOrDefaultAsync(u => u.FuncionarioIdFuncionario == id);

            if (funcionario == null || user == null)
            {
                return NotFound();
            }
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdPerfil", "NomePerfil", user.IdPerfil).Prepend(new SelectListItem() { Text = "---Selecione um Perfil---", Value = "" });
            return View(new UserViewModel { UserName = user.UserName, NomeCompleto = funcionario.NomeCompleto, PhoneNumber = user.PhoneNumber, IdFuncionario = funcionario.IdFuncionario, IdPerfil = user.PerfilNavigation.IdPerfil, NomePerfil = user.PerfilNavigation.NomePerfil });
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, EditUtilizador")]
        public async Task<IActionResult> Edit(int id, UserViewModel userViewModel)
        {
            var func = await _context.Funcionario
                .SingleOrDefaultAsync(f => f.IdFuncionario == id);
            var user = await _context.ApplicationUsers
                   .SingleOrDefaultAsync(u => u.FuncionarioIdFuncionario == id);
            if (func == null || user == null)
            {
                return NotFound();
            }
            var user2 = await _userManager.FindByNameAsync(userViewModel.UserName);
            if (user2 != null && user2.FuncionarioIdFuncionario != id)
            {
                ModelState.AddModelError("UserName", string.Format("Já existe um utilizador com o nome {0}.", userViewModel.UserName));
            }

            if (ModelState.IsValid)
            {
                user.UserName = userViewModel.UserName;
                user.PhoneNumber = userViewModel.PhoneNumber;
                user.IdPerfil = userViewModel.IdPerfil;
                func.NomeCompleto = userViewModel.NomeCompleto;

                try
                {
                    _context.Update(user);
                    _context.Update(func);
                    await _context.SaveChangesAsync();
                    var roles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, roles.ToArray());
                    List<ProfileRole> profileroles = await _context.ProfileRole
                        .Where(p => p.IdPerfil == userViewModel.IdPerfil)
                        .ToListAsync();
                    foreach (ProfileRole role in profileroles)
                    {
                        string role_name = _roleManager.FindByIdAsync(role.RoleId).Result.Name;
                        if (await _roleManager.RoleExistsAsync(role_name))
                            await _userManager.AddToRoleAsync(user, role_name);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(func.IdFuncionario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(userViewModel);
        }

        // GET: Funcionarios/Delete/5
        [Authorize(Roles = "Administrator, DeleteUtilizador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(l => l.Lote)
                .Include(r => r.RegNovosAnimaisFuncionarioIdFuncionarioNavigation)
                .Include(r2 => r2.RegNovosAnimaisFuncionarioIdFuncionario1Navigation)
                .SingleOrDefaultAsync(m => m.IdFuncionario == id);

            if (funcionario.RegNovosAnimaisFuncionarioIdFuncionario1Navigation.Count() > 0 || funcionario.RegNovosAnimaisFuncionarioIdFuncionarioNavigation.Count() > 0)
            {
                return View("DeleteDenied", funcionario);
            }

            var user = await _context.ApplicationUsers
                .Include(u => u.PerfilNavigation)
                .SingleOrDefaultAsync(u => u.FuncionarioIdFuncionario == id);

            if (funcionario == null || user == null)
            {
                return NotFound();
            }
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdPerfil", "NomePerfil", user.IdPerfil).Prepend(new SelectListItem() { Text = "---Selecione um Perfil---", Value = "" });
            return View(new UserViewModel { UserName = user.UserName, NomeCompleto = funcionario.NomeCompleto, PhoneNumber = user.PhoneNumber, IdFuncionario = funcionario.IdFuncionario, IdPerfil = user.PerfilNavigation.IdPerfil, NomePerfil = user.PerfilNavigation.NomePerfil });
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, DeleteUtilizador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario.SingleOrDefaultAsync(m => m.IdFuncionario == id);
            var user = await _context.ApplicationUsers
                .SingleOrDefaultAsync(u => u.FuncionarioIdFuncionario == id);
            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles.ToArray());
            _context.Funcionario.Remove(funcionario);
            await _userManager.DeleteAsync(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.IdFuncionario == id);
        }

        public async Task<ActionResult> ValidateUserName(string UserName, int IdFuncionario)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user == null || user.FuncionarioIdFuncionario == IdFuncionario) return Json(true);
            else return Json(string.Format("Já existe um utilizador com o nome {0}.", UserName));
        }

        [AllowAnonymous]
        public async Task<ActionResult> ValidateUserNameOnCreate(string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user == null) return Json(true);
            else return Json(string.Format("Já existe um utilizador com o nome {0}.", UserName));
        }
    }
}
