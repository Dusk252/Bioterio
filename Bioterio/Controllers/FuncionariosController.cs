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
    [Authorize(Policy = "AdminRights")]
    public class FuncionariosController : Controller
    {
        private readonly bd_lesContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public FuncionariosController(bd_lesContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            var func_list = await _context.Funcionario.ToListAsync();
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (Funcionario f in func_list) {
                var user = await _context.ApplicationUsers
                    .SingleOrDefaultAsync(u => u.FuncionarioIdFuncionario == f.IdFuncionario);
                userViewModels.Add(new UserViewModel { UserName = user.UserName, NomeCompleto = f.NomeCompleto, PhoneNumber = user.PhoneNumber, IdFuncionario = f.IdFuncionario, Permissions = _userManager.GetRolesAsync(user).Result.FirstOrDefault() ?? "User"  });
            }

            return View(userViewModels);
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .SingleOrDefaultAsync(m => m.IdFuncionario == id);

            var user = await _context.ApplicationUsers
                .SingleOrDefaultAsync(u => u.FuncionarioIdFuncionario == id);

            if (funcionario == null || user == null)
            {
                return NotFound();
            }

            return View(new UserViewModel { UserName = user.UserName, NomeCompleto = funcionario.NomeCompleto, PhoneNumber = user.PhoneNumber, IdFuncionario = funcionario.IdFuncionario, Permissions = _userManager.GetRolesAsync(user).Result.FirstOrDefault() ?? "User" } );
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                var user = new ApplicationUser { UserName = registerViewModel.UserName, PhoneNumber = registerViewModel.PhoneNumber, FuncionarioIdFuncionario = func.IdFuncionario };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    if (await _roleManager.RoleExistsAsync(registerViewModel.Permissions))
                        await _userManager.AddToRoleAsync(user, registerViewModel.Permissions);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _context.Remove(func);
                    await _context.SaveChangesAsync();
                }
            }
            return View(registerViewModel);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .SingleOrDefaultAsync(m => m.IdFuncionario == id);

            var user = await _context.ApplicationUsers
                .SingleOrDefaultAsync(u => u.FuncionarioIdFuncionario == id);

            if (funcionario == null || user == null)
            {
                return NotFound();
            }

            return View(new UserViewModel { UserName = user.UserName, NomeCompleto = funcionario.NomeCompleto, PhoneNumber = user.PhoneNumber, IdFuncionario = funcionario.IdFuncionario, Permissions = _userManager.GetRolesAsync(user).Result.FirstOrDefault() ?? "User" });
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                func.NomeCompleto = userViewModel.NomeCompleto;

                try
                {
                    _context.Update(user);
                    _context.Update(func);
                    await _context.SaveChangesAsync();
                    var roles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, roles.ToArray());
                    if (await _roleManager.RoleExistsAsync(userViewModel.Permissions))
                        await _userManager.AddToRoleAsync(user, userViewModel.Permissions);
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .SingleOrDefaultAsync(m => m.IdFuncionario == id);

            var user = await _context.ApplicationUsers
                .SingleOrDefaultAsync(u => u.FuncionarioIdFuncionario == id);

            if (funcionario == null || user == null)
            {
                return NotFound();
            }

            return View(new UserViewModel { UserName = user.UserName, NomeCompleto = funcionario.NomeCompleto, PhoneNumber = user.PhoneNumber, IdFuncionario = funcionario.IdFuncionario, Permissions = _userManager.GetRolesAsync(user).Result.FirstOrDefault() ?? "User" });
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario.SingleOrDefaultAsync(m => m.IdFuncionario == id);
            _context.Funcionario.Remove(funcionario);
            var user = await _context.ApplicationUsers
                .SingleOrDefaultAsync(u => u.FuncionarioIdFuncionario == id);
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
    }
}
