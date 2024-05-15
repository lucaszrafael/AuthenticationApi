using Entidades.Base;
using System.Linq.Expressions;

namespace Repositorios.Interfaces.Base
{
    public interface IRepositorio<TEntidade> where TEntidade : EntidadeBase<TEntidade>, new()
    {
        Task<TEntidade> ObterPrimeiraPorExpressao(Expression<Func<TEntidade, bool>> expressao);
        Task<IEnumerable<TEntidade>> ObterPorExpressao(Expression<Func<TEntidade, bool>> expressao);
        Task<long> ContarPorExpressao(Expression<Func<TEntidade, bool>> expressao);
        Task<int> Inserir(TEntidade entidade);
        Task<bool> Excluir(TEntidade entidade);
        Task<bool> Atualizar(TEntidade entidade);
    }
}
