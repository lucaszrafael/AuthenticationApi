using Servicos.Base;
using Servicos.Exceptions;
using System.Net;

namespace Servicos.Extensoes;

public static class ValidacaoExtensoes
{
    public static async Task Validar<TValidador, TValidacao>(this TValidacao objetoValidacao, params object[] parametros)
        where TValidador : ValidacaoBase<TValidacao>, new()
        where TValidacao : class
    {
        if (objetoValidacao == null)
            return;

        var validacao = new TValidador
        {
            Parametros = new List<object>(parametros)
        };
        var resultados = await validacao.ValidateAsync(objetoValidacao);

        var mensagensErro = resultados.Errors.Select(e => e.ErrorMessage).ToList();

        if (!resultados.IsValid)
            throw new ErroGenericoException(mensagensErro, (int)HttpStatusCode.BadRequest);
    }
}