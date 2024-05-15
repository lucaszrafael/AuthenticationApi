using Api.Models.Usuario;
using DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;
using Servicos.Interfaces;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    protected IUsuarioServico UsuarioServico { get; set; }

    public UsuarioController(IUsuarioServico usuarioServico)
    {
        UsuarioServico = usuarioServico;
    }

    /// <summary>
    /// Cria um novo usuário
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> PostUsuario([FromBody] PostUsuarioRequestModel model)
    {
        int? usuarioId = await UsuarioServico.CriarUsuario(
            new InserirUsuarioDto()
            {
                NickName = model.NickName,
                Chave = model.Chave
            }
        );

        return Ok(usuarioId);
    }

    /// <summary>
    /// Autentica um usuário
    /// </summary>
    /// <returns></returns>
    [HttpPost("Autenticar")]
    public async Task<IActionResult> AutenticarUsuario([FromBody] PostAutenticarUsuarioRequestModel model)
    {
        int? usuarioId = await UsuarioServico.AutenticarUsuario(
            new AutenticarUsuarioDto()
            {
                NickName = model.NickName,
                Chave = model.Chave
            }
        );

        return Ok(usuarioId);
    }

    /// <summary>
    /// Atualiza um usuário
    /// </summary>
    /// <returns></returns>
    [HttpPatch("{usuarioId:int}")]
    public async Task<IActionResult> AlterarUsuario([FromBody] PutUsuarioRequestModel model, int usuarioId)
    {
        await UsuarioServico.AlterarUsuario(
            new AtualizarUsuarioDto()
            {
                NickName = model.NickName,
                Chave = model.Chave,
                UsuarioId = usuarioId
            }
        );

        return Ok();
    }

    /// <summary>
    /// Exclui um usuário
    /// </summary>
    /// <returns></returns>
    [HttpDelete("{usuarioId:int}")]
    public async Task<IActionResult> DeleteUsuario([FromRoute] int usuarioId)
    {
        await UsuarioServico.ApagarUsuario(usuarioId);

        return Ok();
    }
}
