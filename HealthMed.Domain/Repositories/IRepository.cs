using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task Adicionar(T entity);

        Task<List<T>> ObterTodos();

        Task<T?> ObterPorId(Guid id);

        Task Atualizar(T entity);

        Task Remover(Guid id);

        T Find(params object[] Keys);

        T Find(Expression<Func<T, bool>> where);

        T Find(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, object> includes);

        IQueryable<T> Query(Expression<Func<T, bool>> where);

        IQueryable<T> Query(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, object> includes);
    }
}
