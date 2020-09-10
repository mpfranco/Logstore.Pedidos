using Logstore.Pedidos.Infrastructure.Shared.DomainObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;


namespace Easydocs.GetImagem.Api.Filter
{
    public class RequestFilterAttribute : IActionFilter
    {
        private readonly IConfiguration _configuration;
        public RequestFilterAttribute(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context == null)
                return;

            try
            {
                var token = _configuration["ApplicationToken"];

                context.HttpContext.Request.Headers.TryGetValue("ApplicationToken", out StringValues applicationToken);
                if (string.IsNullOrEmpty(applicationToken.ToString()) || !applicationToken.Equals(token))
                {                    
                    context.Result = new OkObjectResult(new ResultCommand("Token Inválido!",Logstore.Pedidos.Infrastructure.Shared.Constants.StatusCode.Invalid));

                }

            }
            catch (Exception ex)
            {                
                context.Result = new BadRequestObjectResult(new ResultCommand(new List<string>() { ex.Message },Logstore.Pedidos.Infrastructure.Shared.Constants.StatusCode.Invalid));
            }
        }
    }
}
