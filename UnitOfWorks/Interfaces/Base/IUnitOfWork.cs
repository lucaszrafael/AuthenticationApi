namespace UnitOfWorks.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void InicializarTransacao();
        void ConfirmarTransacao();
        void DesfazerTransacao();
        void Cache(bool status);
    }
}
