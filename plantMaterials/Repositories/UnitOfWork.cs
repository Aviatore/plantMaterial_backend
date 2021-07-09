using System;
using System.Collections.Generic;
using AutoMapper;
using plantMaterials.Models;

namespace plantMaterials.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public PlantMaterialsContext DbContext { get; }
        public ITissueRepository TissueRepository { get; }
        private readonly Dictionary<Type, object> _repositories;
        private readonly IMapper _mapper;
        
        public UnitOfWork(PlantMaterialsContext plantMaterialsContext, IMapper mapper)
        {
            DbContext = plantMaterialsContext;
            TissueRepository = new TissueRepository(plantMaterialsContext);
            _repositories = new Dictionary<Type, object>();
            _mapper = mapper;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return _repositories[typeof(T)] as IGenericRepository<T>;
            }

            var repo = new GenericRepository<T>(DbContext, _mapper);
            _repositories.Add(typeof(T), repo);

            return repo;
        }
    }
}