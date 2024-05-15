using Api.Models.Global;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Servicos.Exceptions;

namespace Api.Core
{
    public class ErroGenericoFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ErroGenericoException ex)
            {
                var resposta = new ObjectResult(new ExcecaoModel
                {
                    Mensagens = ex.MensagensErro
                })
                {
                    StatusCode = ex.StatusCode
                };

                context.Result = resposta;
                context.ExceptionHandled = true;
            }
        }
    }
}