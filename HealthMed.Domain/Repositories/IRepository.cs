using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
