using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bioterio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Bioterio.Controllers
{
    public class PerfisController : Controller
    {
        private readonly bd_lesContext _context;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PerfisController(bd_lesContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Perfis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Perfil.ToListAsync());
        }

        // GET: Perfis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Perfil = await _context.Perfil
                .Include(p => p.Roles)
                .SingleOrDefaultAsync(m => m.IdPerfil == id);
            if (Perfil == null)
            {
                return NotFound();
            }
            var i = 0;
            var permissions = new List<Dictionary<string, string>>();
            var dic = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> entry in Authorization.ApplicationUsersManager.Constants.CategoryRoles)
            {
                if (i % 4 == 0)
                {
                    if (i != 0) permissions.Add(dic);
                    dic = new Dictionary<string, string>();
                }
                dic.Add(entry.Key, entry.Value);
                i++;
            }
            permissions.Add(dic);
            ViewData["permissions"] = permissions;

            var roles = new List<string>();
            var profileRoles = await _context.ProfileRole.Where(p => p.IdPerfil == id).ToListAsync();
            foreach (ProfileRole role in profileRoles)
            {
                roles.Add(_roleManager.FindByIdAsync(role.RoleId).Result.Name);
            }
            ViewData["checked"] = roles;
            return View(Perfil);
        }

        [Authorize(Policy = "ElevatedRights")]
        // GET: Perfis/Create
        public IActionResult Create()
        {
            var i = 0;
            var permissions = new List<Dictionary<string, string>>();
            var dic = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> entry in Bioterio.Authorization.ApplicationUsersManager.Constants.CategoryRoles)
            {
                if (i % 4 == 0)
                {
                    if (i!=0) permissions.Add(dic);
                    dic = new Dictionary<string, string>();
                }
                dic.Add(entry.Key, entry.Value);
                i++;
            }
            permissions.Add(dic);
            ViewData["permissions"] = permissions;
            ViewData["checked"] = new List<string>();
            return View();
        }

        [Authorize(Policy = "ElevatedRights")]
        // POST: Perfis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPerfil,NomePerfil,IsDefault")] Perfil Perfil, List<string> roles)
        {
            //validation
            var val_code = await _context.Perfil
                .SingleOrDefaultAsync(p => p.NomePerfil == Perfil.NomePerfil);
            if (val_code != null)
            {
                ModelState.AddModelError("NomePerfil", string.Format("Já existe um Perfil com o nome {0}.", Perfil.NomePerfil));
            }

            if (ModelState.IsValid)
            {
                //check if default exists
                if (Perfil.IsDefault == 1)
                {
                    var default_profile = await _context.Perfil.SingleOrDefaultAsync(p => p.IsDefault == 1);
                    default_profile.IsDefault = 0;
                    _context.Perfil.Attach(default_profile);
                    _context.Entry(default_profile).Property(p => p.IsDefault).IsModified = true;
                }
                else
                {
                    Perfil.IsDefault = 0;
                }
                _context.Add(Perfil);
                foreach(string role in roles)
                {
                    _context.Add(new ProfileRole { IdPerfil = Perfil.IdPerfil, RoleId = await _roleManager.GetRoleIdAsync(await _roleManager.FindByNameAsync(role)) });
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["checked"] = roles;
            return View(Perfil);
        }

        [Authorize(Policy = "ElevatedRights")]
        // GET: Perfis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id == 1)
            {
                return View("AccessDenied");
            }

            var Perfil = await _context.Perfil.SingleOrDefaultAsync(m => m.IdPerfil == id);
            if (Perfil == null)
            {
                return NotFound();
            }
            var i = 0;
            var permissions = new List<Dictionary<string, string>>();
            var dic = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> entry in Authorization.ApplicationUsersManager.Constants.CategoryRoles)
            {
                if (i % 4 == 0)
                {
                    if (i != 0) permissions.Add(dic);
                    dic = new Dictionary<string, string>();
                }
                dic.Add(entry.Key, entry.Value);
                i++;
            }
            permissions.Add(dic);
            ViewData["permissions"] = permissions;

            var roles = new List<string>();
            var profileRoles = await _context.ProfileRole.Where(p => p.IdPerfil == id).ToListAsync();
            foreach(ProfileRole role in profileRoles)
            {
                roles.Add(_roleManager.FindByIdAsync(role.RoleId).Result.Name);
            }
            ViewData["checked"] = roles;
            return View(Perfil);
        }

        [Authorize(Policy = "ElevatedRights")]
        // POST: Perfis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPerfil,NomePerfil,IsDefault")] Perfil Perfil, List<string> roles)
        {
            if (id != Perfil.IdPerfil)
            {
                return NotFound();
            }
            if (id == 1)
            {
                return View("AccessDenied");
            }

            //validation
            var val_code = await _context.Perfil
                .SingleOrDefaultAsync(p => p.NomePerfil == Perfil.NomePerfil);
            if (val_code != null && val_code.IdPerfil != Perfil.IdPerfil)
            {
                ModelState.AddModelError("NomePerfil", string.Format("Já existe um Perfil com o nome {0}.", Perfil.NomePerfil));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (roles != null)
                    {
                        string temp;
                        var for_add = new List<ProfileRole>();
                        var for_remove = new List<ProfileRole>();
                        var current_roles = await _context.ProfileRole
                            .Where(p => p.IdPerfil == id).ToListAsync();
                        foreach(ProfileRole role in current_roles)
                        {
                            temp = _roleManager.FindByIdAsync(role.RoleId).Result.Name;
                            //temp = new ProfileRole { IdPerfil = id, RoleId = _roleManager.FindByNameAsync(role).Result.Id };
                            if (roles.Contains(temp))
                            {
                                roles.Remove(temp);
                            }
                            else
                            {
                                for_remove.Add(role);
                            }
                        }
                        foreach(string role in roles)
                        {
                            for_add.Add(new ProfileRole { IdPerfil = id, RoleId = _roleManager.FindByNameAsync(role).Result.Id });
                        }
                        _context.ProfileRole.AddRange(for_add);
                        _context.ProfileRole.RemoveRange(for_remove);
                    }
                    var default_profile = await _context.Perfil.SingleOrDefaultAsync(p => p.IsDefault == 1);
                    if (default_profile.IdPerfil == Perfil.IdPerfil)
                    {
                        Perfil.IsDefault = 1;
                    }
                    else
                    {
                        if (Perfil.IsDefault == 1)
                        {
                            default_profile.IsDefault = 0;
                            _context.Perfil.Attach(default_profile);
                            _context.Entry(default_profile).Property(p => p.IsDefault).IsModified = true;
                        }
                        else
                        {
                            Perfil.IsDefault = 0;
                        }
                    }
                    var old_perfil = await _context.Perfil
                .SingleOrDefaultAsync(m => m.IdPerfil == id);
                    _context.Entry(old_perfil).CurrentValues.SetValues(Perfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfilExists(Perfil.IdPerfil))
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
            ViewData["roles"] = await _context.Roles.ToListAsync();
            return View(Perfil);
        }

        [Authorize(Policy = "ElevatedRights")]
        // GET: Perfis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id == 1)
            {
                return View("AccessDenied");
            }

            var Perfil = await _context.Perfil
                .SingleOrDefaultAsync(m => m.IdPerfil == id);
            if (Perfil == null)
            {
                return NotFound();
            }

            var roles = new List<string>();
            var profileRoles = await _context.ProfileRole.Where(p => p.IdPerfil == id).ToListAsync();
            foreach (ProfileRole role in profileRoles)
            {
                roles.Add(_roleManager.FindByIdAsync(role.RoleId).Result.Name);
            }
            ViewData["checked"] = roles;
            return View(Perfil);
        }

        [Authorize(Policy = "ElevatedRights")]
        // POST: Perfis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var defaultId = _context.Perfil.SingleOrDefault(m => m.IsDefault == 1).IdPerfil;
            if (id == 1 || id == defaultId)
            {
                return View("AccessDenied");
            }
            var Perfil = await _context.Perfil.SingleOrDefaultAsync(m => m.IdPerfil == id);
            var users = await _context.ApplicationUsers.Where(u => u.IdPerfil == id).ToListAsync();

            List<ProfileRole> default_profileroles = await _context.ProfileRole
                .Where(p => p.IdPerfil == defaultId)
                .ToListAsync();
            foreach (ApplicationUsers user in users)
            {
                user.IdPerfil = defaultId;
                _context.ApplicationUsers.Attach(user);
                _context.Entry(user).Property(p => p.IdPerfil).IsModified = true;
                var roles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, roles.ToArray());
                foreach (ProfileRole role in default_profileroles)
                {
                    string role_name = _roleManager.FindByIdAsync(role.RoleId).Result.Name;
                    if (await _roleManager.RoleExistsAsync(role_name))
                        await _userManager.AddToRoleAsync(user, role_name);
                }
            }
            var profileroles = await _context.ProfileRole.Where(p => p.IdPerfil == id).ToListAsync();
            _context.RemoveRange(profileroles);
            _context.Perfil.Remove(Perfil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfilExists(int id)
        {
            return _context.Perfil.Any(e => e.IdPerfil == id);
        }

        public async Task<ActionResult> ValidateNomePerfil(string NomePerfil, int IdPerfil)
        {
            var val_codigoPerfil = await _context.Perfil
            .SingleOrDefaultAsync(m => m.NomePerfil == NomePerfil);
            if (val_codigoPerfil == null || val_codigoPerfil.IdPerfil == IdPerfil) return Json(true);
            else return Json(string.Format("Já existe um Perfil com o nome {0}.", NomePerfil));
        }
    }
}
