using plantMaterials.Models;

namespace plantMaterials.Repositories
{
    public interface IUnitOfWork
    {
        PlantMaterialsContext DbContext { get; }
        ITissueRepository TissueRepository { get; }
    }
}