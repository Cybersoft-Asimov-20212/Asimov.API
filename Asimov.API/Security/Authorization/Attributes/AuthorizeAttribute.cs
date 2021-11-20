using System;
using System.Linq;
using Asimov.API.Directors.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Asimov.API.Security.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // if actions is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // Authorization process
            var director = (Director) context.HttpContext.Items["Director"];
            if (director == null)
                context.Result = new JsonResult(new {message = "Unauthorized"})
                    {StatusCode = StatusCodes.Status401Unauthorized};

        }
    }
}