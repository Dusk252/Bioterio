using Bioterio.Authorization;
using Bioterio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static Bioterio.Authorization.ApplicationUsersManager;

namespace Bioterio.Data
{
    public static class SeedData
    {
        #region snippet_Initialize
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new bd_lesContext(
                serviceProvider.GetRequiredService<DbContextOptions<bd_lesContext>>()))
            {
                // The password is set with the following command:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything
                var profileID = await EnsureProfile("admin", 0, context);
                await EnsureProfile("default", 1, context);
                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin", profileID, context);
                await EnsureRole(serviceProvider, adminID, Constants.AdministratorsRole, profileID, context);

                //var uid = await EnsureUser(serviceProvider, testUserPw, "manager", context);
                //await EnsureRole(serviceProvider, uid, Constants.ManagersRole);

                await SeedDBAsync(serviceProvider, context, adminID);
            }
        }

        private static async Task<int> EnsureProfile(string ProfileName, int Default, bd_lesContext _context)
        {
            var profile = await _context.Perfil.SingleOrDefaultAsync(p => p.NomePerfil == ProfileName);
            if (profile == null && ProfileName != null)
            {
                profile = new Perfil { NomePerfil = ProfileName, IsDefault = Default };
                _context.Add(profile);
                await _context.SaveChangesAsync();
            }
            return profile.IdPerfil;
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName, int ProfileID, bd_lesContext _context)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUsers>>();

            var func = new Funcionario { NomeCompleto = UserName };

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null && UserName != null && ProfileID != 0)
            {
                _context.Add(func);
                await _context.SaveChangesAsync();
                user = new ApplicationUsers { UserName = UserName, FuncionarioIdFuncionario = func.IdFuncionario, IdPerfil = ProfileID };
                var result = await userManager.CreateAsync(user, testUserPw);
                if (!result.Succeeded)
                {
                    Console.WriteLine(result.Errors);
                    _context.Remove(func);
                    await _context.SaveChangesAsync();
                }
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role, int ProfileID, bd_lesContext _context)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            IdentityRole IRole = null;

            if (!await roleManager.RoleExistsAsync(role))
            {
                IRole = new IdentityRole(role);
                IR = await roleManager.CreateAsync(IRole);
            }
            else
            {
                IRole = roleManager.FindByNameAsync(role).Result;
            }

            ProfileRole PR = await _context.ProfileRole.SingleOrDefaultAsync(pr => pr.IdPerfil == ProfileID && pr.RoleId == IRole.Id);
            if (PR == null)
            {
                PR = new ProfileRole { IdPerfil = ProfileID, RoleId = IRole.Id};
                _context.Add(PR);
                await _context.SaveChangesAsync();
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUsers>>();

            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
        #endregion
        #region snippet1
        public static async Task SeedDBAsync(IServiceProvider serviceProvider, bd_lesContext context, string uid)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            foreach (KeyValuePair<string, string> entry in Constants.CategoryRoles)
            {
                if (!await roleManager.RoleExistsAsync(entry.Key))
                {
                    await roleManager.CreateAsync(new IdentityRole(entry.Key));
                }
            }

            //if (context.Contact.Any())
            //{
            //    return;   // DB has been seeded
            //}

            //context.Contact.AddRange(
            //#region snippet_Contact
            //    new Contact
            //    {
            //        Name = "Debra Garcia",
            //        Address = "1234 Main St",
            //        City = "Redmond",
            //        State = "WA",
            //        Zip = "10999",
            //        Email = "debra@example.com",
            //        Status = ContactStatus.Approved,
            //        OwnerID = adminID
            //    },
            //#endregion
            // );

            if (context.RegNovosAnimais.Any())
            {
                return; //DB already seeded
            }

            //var userManager = serviceProvider.GetService<UserManager<ApplicationUsers>>();

            //var user = await userManager.FindByIdAsync(uid);

            //context.RegNovosAnimais.AddRange(
            //    new RegNovosAnimais
            //    {
            //        NroExemplares = 2,
            //        NroMachos = 1,
            //        NroFemeas = 1,
            //        Imaturos = 0,
            //        Juvenis = 0,
            //        Larvas = 0,
            //        Ovos = 0,
            //        DataNasc = new DateTime(2017, 08, 22),
            //        Idade = 22,
            //        PesoMedio = 1,
            //        CompMedio = 45,
            //        DuracaoViagem = new TimeSpan(1220),
            //        TempPartida = 2,
            //        TempChegada = 3,
            //        NroContentores = 3,
            //        TipoContentor = "sakura",
            //        VolContentor = (float)2.3,
            //        VolAgua = (float)1.2,
            //        NroCaixasIsoter = 2,
            //        NroMortosCheg = 0,
            //        SatO2transp = (float)0.11,
            //        Anestesico = 1,
            //        Gelo = 0,
            //        AdicaoO2 = 0,
            //        Arejamento = 0,
            //        Refrigeracao = 1,
            //        sedacao = 0,
            //        RespTransporte = "DHL",
            //        EspecieIdEspecie = 1,
            //        FornecedorIdFornColect = 1,
            //        TOrigemIdTOrigem = 1,
            //        LocalCapturaIdLocalCaptura = 1,
            //        TipoEstatutoGeneticoIdTipoEstatutoGenetico = 1,
            //        FuncionarioIdFuncionario = user.FuncionarioIdFuncionario,
            //        FuncionarioIdFuncionario1 = user.FuncionarioIdFuncionario
            //    }
            //    );

            context.SaveChanges();
        }
        #endregion
    }
}
