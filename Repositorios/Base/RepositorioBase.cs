using Entidades.Base;
using Repositorios.Interfaces.Base;
using System.Linq.Expressions;
using Dommel;
using static Dommel.DommelMapper;

namespace Repositorios.Base
{
    public abstract class RepositorioBase<TEntidade> : IRepositorioContexto, IRepositorio<TEntidade>
        where TEntidade : EntidadeBase<TEntidade>, new()
    {
        protected TimeSpan TempoCache = new(0, 30, 0, 0);
        public IContextoBanco Contexto { get; set; }

        public async Task<TEntidade> ObterPrimeiraPorExpressao(Expression<Func<TEntidade, bool>> expressao)
        {
            var listaEntidades = await ObterPorExpressao(expressao);
            return listaEntidades?.FirstOrDefault();
        }
        public async Task<IEnumerable<TEntidade>> ObterPorExpressao(Expression<Func<TEntidade, bool>> expressao)
        {
            return await Contexto.Conexao.SelectAsync(expressao, Contexto.Transacao);
        }
        public async Task<long> ContarPorExpressao(Expression<Func<TEntidade, bool>> expressao)
        {
            return await Contexto.Conexao.CountAsync(expressao, Contexto.Transacao);
        }

        public async Task<int> Inserir(TEntidade entidade)
        {
            var idObject = await Contexto.Conexao.InsertAsync(entidade, Contexto.Transacao);
            return Convert.ToInt32(idObject?.ToString());
        }
      
        public async Task<bool> Excluir(TEntidade entidade)
        {
            return await Contexto.Conexao.DeleteAsync(entidade, Contexto.Transacao);
        }

        public async Task<bool> Atualizar(TEntidade entidade)
        {
            return await Contexto.Conexao.UpdateAsync(entidade, Contexto.Transacao);
        }

    }
}