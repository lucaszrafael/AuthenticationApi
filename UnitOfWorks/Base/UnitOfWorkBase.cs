using Repositorios.Interfaces.Base;
using UnitOfWorks.Interfaces.Base;

namespace UnitOfWorks.Base
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        protected readonly IServiceProvider ServiceProvider;
        protected readonly IContextoBanco Contexto;
        protected readonly Dictionary<Type, IRepositorioContexto> Repositorios = new Dictionary<Type, IRepositorioContexto>();

        protected UnitOfWorkBase(IServiceProvider serviceProvider, IContextoBanco contextoBanco)
        {
            ServiceProvider = serviceProvider;
            Contexto = contextoBanco;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Contexto != null)
                Contexto.Dispose();
        }

        protected virtual TRepositorio Configurar<TRepositorio>() where TRepositorio : IRepositorioContexto
        {
            var chave = typeof(TRepositorio);

            lock (Repositorios)
            {
                if (!Repositorios.ContainsKey(chave))
                {
                    var repositorio = (IRepositorioContexto)ServiceProvider.GetService(chave);
                    repositorio.Contexto = Contexto;

                    Repositorios.Add(chave, repositorio);
                }
            }

            return (TRepositorio)Repositorios[chave];
        }

        public void InicializarTransacao()
        {
            Contexto.InicializarTransacao();
        }

        public void ConfirmarTransacao()
        {
            Contexto.ConfirmarTransacao();
        }

        public void DesfazerTransacao()
        {
            Contexto.DesfazerTransacao();
        }

        public void Cache(bool status)
        {
            Contexto.Cache(status);
        }
    }
}
