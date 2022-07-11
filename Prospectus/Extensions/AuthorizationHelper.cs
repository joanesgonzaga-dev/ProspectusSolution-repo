using Microsoft.AspNetCore.Authorization;
using Prospectus.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prospectus.Extensions
{
    //Custom class
    public class PermissaoNecessaria : IAuthorizationRequirement
    {
        public string Permissao { get; }

        public PermissaoNecessaria(string permissao)
        {
            Permissao = permissao;
        }
    }

    public class PermissaoProdutoHandler : AuthorizationHandler<PermissaoNecessaria>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissaoNecessaria requisito)
        {
            if (context.User.HasClaim(c => c.Type == "ProdutoPermissao" && c.Value.Contains(requisito.Permissao)))
            {
                context.Succeed(requisito);
            }

            return Task.CompletedTask;
        }
    }
}
