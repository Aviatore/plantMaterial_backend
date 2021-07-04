using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plantMaterials.Models;

namespace plantMaterials.Repositories
{
    public interface ITissueRepository
    {
        IEnumerable<Tissue> GetAllTissues();
        Task<ProblemDetails> AddTissue(string tissueName);
        Task<ProblemDetails> RemoveTissue(string tissueId);
    }
}