using DTOs.Usuario;
using FluentValidation;
using Servicos.Base;

namespace Servicos.Validacoes.Usuario;

public class AutenticarUsuarioValidacoes : ValidacaoBase<AutenticarUsuarioDto>
{
    public AutenticarUsuarioValidacoes()
    {
        RuleFor(x => x).
            MustAsync(async (model, contexto) =>
            {
                var usuarioBanco = await UnitOfWork.Usuario.ObterPrimeiraPorExpressao(u => u.NickName == model.NickName);

                if (usuarioBanco == null)
                    return false;

                if (usuarioBanco.Chave != model.Chave)
                    return false;

                return true;
            }).
            WithMessage("Nick name e/ou senha inválidos;");
    }
}
