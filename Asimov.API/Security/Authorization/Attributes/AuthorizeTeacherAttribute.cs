using System;
using System.Linq;
using Asimov.API.Teachers.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Asimov.API.Security.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeTeacherAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // if actions is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // Authorization process
            var teacher = (Teacher) context.HttpContext.Items["Teacher"];
            if (teacher == null)
                context.Result = new JsonResult(new {message = "Unauthorized t"})
                    {StatusCode = StatusCodes.Status401Unauthorized};

        }
    }
}