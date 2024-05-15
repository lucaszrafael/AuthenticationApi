using System.Data;

namespace Repositorios.Interfaces.Base
{
    public interface IContextoBanco : IDisposable
    {
        IDbConnection Conexao { get; }
        IDbTransaction Transacao { get; }
        bool CacheAtivo { get; }
        int TransacoesAbertas { get; }
        void InicializarTransacao();
        void ConfirmarTransacao();
        void DesfazerTransacao();
        void Cache(bool status);
    }
}
