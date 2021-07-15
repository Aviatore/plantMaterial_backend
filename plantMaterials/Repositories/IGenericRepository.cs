using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using plantMaterials.Models;

namespace plantMaterials.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        PlantMaterialsContext DbContext { get; }
        IMapper Mapper { get; }
        IQueryable<T> GetAll();
        Task<ProblemDetails> Add(T item);
        Task<ProblemDetails> Remove(string item_id);
        Task<ProblemDetails> Edit(T item, string id);
    }
}