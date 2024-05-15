using DTOs.Usuario;
using Entidades;
using Servicos.Base;
using Servicos.Extensoes;
using Servicos.Interfaces;
using Servicos.Validacoes.Usuario;
using UnitOfWorks.Interfaces;

namespace Servicos;

public class UsuarioServico : ServicoBase, IUsuarioServico
{
    public UsuarioServico(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<int> CriarUsuario(InserirUsuarioDto dto)
    {
        await dto.Validar<InserirUsuarioValidacoes, InserirUsuarioDto>(MeusGastosUnitOfWork);

        var usuarioId = await MeusGastosUnitOfWork.Usuario.Inserir(new Usuario()
        {
            NickName = dto.NickName,
            Chave = dto.Chave,
        });

        return usuarioId;
    }

    public async Task<int> AutenticarUsuario(AutenticarUsuarioDto dto)
    {
        await dto.Validar<AutenticarUsuarioValidacoes, AutenticarUsuarioDto>(MeusGastosUnitOfWork);

        Usuario usuario = await MeusGastosUnitOfWork.Usuario.ObterPrimeiraPorExpressao(u => u.NickName == dto.NickName);

        return usuario.UsuarioId;
    }

    public async Task AlterarUsuario(AtualizarUsuarioDto dto)
    {
        await dto.Validar<AtualizarUsuarioValidacoes, AtualizarUsuarioDto>(MeusGastosUnitOfWork);

        Usuario usuario = await MeusGastosUnitOfWork.Usuario.ObterPrimeiraPorExpressao(e => e.UsuarioId == dto.UsuarioId);

        usuario.NickName = dto.NickName ?? usuario.NickName;
        usuario.Chave = dto.Chave ?? usuario.Chave;

        await MeusGastosUnitOfWork.Usuario.Atualizar(usuario);
    }

    public async Task ApagarUsuario(int usuarioId)
    {
        Usuario usuario = new()
        {
            UsuarioId = usuarioId,
        };

        await MeusGastosUnitOfWork.Usuario.Excluir(usuario);
    }
}
