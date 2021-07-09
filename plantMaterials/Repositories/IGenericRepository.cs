using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace plantMaterials.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<ProblemDetails> Add(T item);
        Task<ProblemDetails> Remove(string item_id);
        Task<ProblemDetails> Edit(T item, string id);
    }
}