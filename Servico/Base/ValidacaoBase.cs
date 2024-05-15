using FluentValidation;
using UnitOfWorks.Interfaces;

namespace Servicos.Base
{
    public class ValidacaoBase<TValidacao> : AbstractValidator<TValidacao>
    {
        protected IUnitOfWork UnitOfWork { get { return Parametros?.OfType<IUnitOfWork>()?.FirstOrDefault(); } }
        public List<object> Parametros { get; set; }
    }
}
