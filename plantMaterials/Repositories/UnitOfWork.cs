using plantMaterials.Models;

namespace plantMaterials.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public PlantMaterialsContext DbContext { get; }
        public ITissueRepository TissueRepository { get; }
        
        public UnitOfWork(PlantMaterialsContext plantMaterialsContext)
        {
            DbContext = plantMaterialsContext;
            TissueRepository = new TissueRepository(plantMaterialsContext);
        }
    }
}