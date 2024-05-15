using UnitOfWorks.Interfaces.Base;
using Repositorios.Interfaces;

namespace UnitOfWorks.Interfaces
{
    public interface IUnitOfWork : Base.IUnitOfWork
    {
        IUsuarioRepositorio Usuario { get; }
    }
}