using Entidades;
using Repositorios.Interfaces.Base;

namespace Repositorios.Interfaces;

public interface IUsuarioRepositorio : IRepositorio<Usuario>, IRepositorioContexto { }
