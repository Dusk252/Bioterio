using System.Threading.Tasks;
using Bioterio.Data;
using Bioterio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using static Bioterio.Authorization.ApplicationUserManager;

namespace Bioterio.Authorization
{
    public class UserIsOwnerAuthorizationHandler
                : AuthorizationHandler<OperationAuthorizationRequirement, RegNovosAnimais>
    {
        UserManager<ApplicationUser> _userManager;

        public UserIsOwnerAuthorizationHandler(UserManager<ApplicationUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   RegNovosAnimais resource)
        {
            if (context.User == null || resource == null)
            {
                // Return Task.FromResult(0) if targeting a version of
                // .NET Framework older than 4.6:
                return Task.CompletedTask;
            }

            // If we're not asking for CRUD permission, return.

            if (requirement.Name != Constants.CreateOperationName &&
                requirement.Name != Constants.ReadOperationName &&
                requirement.Name != Constants.UpdateOperationName &&
                requirement.Name != Constants.DeleteOperationName)
            {
                return Task.CompletedTask;
            }
            var user = _userManager.GetUserAsync(context.User).Result;
            if (resource.FuncionarioIdFuncionario == user.FuncionarioIdFuncionario || resource.FuncionarioIdFuncionario1 == user.FuncionarioIdFuncionario)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}