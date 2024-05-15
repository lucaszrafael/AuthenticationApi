using System.ComponentModel.DataAnnotations;
using Entidades.Base;

namespace Entidades;

public class Usuario : EntidadeBase<Usuario>
{
    [Key]
    public int UsuarioId { get; set; }
    public string NickName { get; set; }
    public string Chave { get; set; }
}
