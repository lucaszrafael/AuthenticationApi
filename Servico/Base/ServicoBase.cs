using UnitOfWorks.Interfaces;

namespace Servicos.Base
{
    public abstract class ServicoBase
    {
        protected IUnitOfWork MeusGastosUnitOfWork { get; set; }

        protected ServicoBase(IUnitOfWork unitOfWork)
        {
            MeusGastosUnitOfWork = unitOfWork;
        }

    }
}
