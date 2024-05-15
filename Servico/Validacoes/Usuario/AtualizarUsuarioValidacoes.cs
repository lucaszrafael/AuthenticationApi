using DTOs.Usuario;
using FluentValidation;
using Servicos.Base;

namespace Servicos.Validacoes.Usuario;

public class AtualizarUsuarioValidacoes : ValidacaoBase<AtualizarUsuarioDto>
{
    public AtualizarUsuarioValidacoes()
    {
        RuleFor(x => x).
            MustAsync(async (model, contexto) =>
            {
                if (model.NickName == null)
                    return true;

                var usuariosMesmoNick = await UnitOfWork.Usuario.ContarPorExpressao(u => u.NickName == model.NickName);

                if (usuariosMesmoNick > 0)
                    return false;

                return true;
            }).
            WithMessage("Já existe um usuário com o mesmo nick name;");
    }
}
