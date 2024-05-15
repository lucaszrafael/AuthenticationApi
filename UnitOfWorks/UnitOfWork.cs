using Repositorios.Interfaces.Base;
using UnitOfWorks.Base;
using UnitOfWorks.Interfaces;
using Repositorios.Interfaces;

namespace UnitOfWorks;

public class UnitOfWork : UnitOfWorkBase, IUnitOfWork
{

    public UnitOfWork(IServiceProvider serviceProvider, IMeusGastosContexto contextoBanco) : base(serviceProvider, contextoBanco) { }

    public IUsuarioRepositorio Usuario { get => Configurar<IUsuarioRepositorio>(); }
}
