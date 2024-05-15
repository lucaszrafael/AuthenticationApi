using DTOs.Usuario;

namespace Servicos.Interfaces;

public interface IUsuarioServico
{
    Task<int> CriarUsuario(InserirUsuarioDto dto);
    Task<int> AutenticarUsuario(AutenticarUsuarioDto dto);
    Task AlterarUsuario(AtualizarUsuarioDto dto);
    Task ApagarUsuario(int usuarioId);

}