using DTOs.Usuario;
using FluentValidation;
using Servicos.Base;

namespace Servicos.Validacoes.Usuario;

public class InserirUsuarioValidacoes : ValidacaoBase<InserirUsuarioDto>
{
    public InserirUsuarioValidacoes()
    {
        RuleFor(x => x.Chave).
               Must((nome) => !string.IsNullOrWhiteSpace(nome)).
               WithMessage("A senha deve ser preenchida");

        RuleFor(x => x).
            MustAsync(async (model, contexto) =>
            {
                var usuariosMesmoNick = await UnitOfWork.Usuario.ContarPorExpressao(u => u.NickName == model.NickName);

                if (usuariosMesmoNick > 0)
                    return false;

                return true;
            }).
            WithMessage("Já existe um usuário com o mesmo nick name");
    }
}
