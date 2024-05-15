using Repositorios.Interfaces.Base;
using System.Data;

namespace Repositorios.Base
{
    public abstract class ContextoBancoBase : IContextoBanco
    {
        public string ConnectionString { get; set; }
        public IDbConnection Conexao { get; protected set; }
        public IDbTransaction Transacao { get; private set; }
        public bool CacheAtivo { get; private set; } = false;
        public int TransacoesAbertas { get; set; }

        public void InicializarTransacao()
        {
            TransacoesAbertas++;

            if (TransacoesAbertas != 1)
                return;

            if (Conexao.State != ConnectionState.Open)
                Conexao.Open();

            Transacao = Conexao.BeginTransaction();
        }

        public void ConfirmarTransacao()
        {
            if (TransacoesAbertas == 0)
                throw new Exception("A transação precisa ser iniciada");

            TransacoesAbertas--;

            if (TransacoesAbertas != 0)
                return;

            Transacao.Commit();
        }

        public void DesfazerTransacao()
        {
            TransacoesAbertas = 0;
            Transacao.Rollback();
            Transacao.Dispose();

            Transacao = null;
        }

        public void Cache(bool status)
        {
            CacheAtivo = status;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (Conexao != null)
            {
                if (Transacao != null)
                {
                    if (Conexao.State == ConnectionState.Open && TransacoesAbertas > 0)
                        Transacao.Rollback();

                    Transacao.Dispose();
                }

                Conexao.Dispose();
            }
        }

    }
}
