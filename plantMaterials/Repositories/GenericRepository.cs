using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using plantMaterials.ExtensionMethods;
using plantMaterials.Models;

namespace plantMaterials.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public PlantMaterialsContext DbContext { get; }
        private DbSet<T> _objectSet;
        public IMapper Mapper { get; }

        public GenericRepository(PlantMaterialsContext plantMaterialsContext, IMapper mapper)
        {
            DbContext = plantMaterialsContext;
            _objectSet = plantMaterialsContext.Set<T>();
            Mapper = mapper;
        }
        
        public IQueryable<T> GetAll()
        {
            return _objectSet.AsNoTracking();
        }

        public async Task<T> Get(string itemId)
        {
            if (!Guid.TryParse(itemId, out Guid id))
            { 
                return null;
            }

            return await _objectSet.FindAsync(id);
        }
        
        public async Task<ProblemDetails> Add(T item)
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Detail = "An error occured",
                Status = 500
            };

            try
            {
                if (item is null)
                {
                    throw new Exception("Item cannot be empty");
                }

                _objectSet.Add(item);

                await DbContext.SaveChangesAsync();

                problemDetails.Detail = "Item added successfully";
                problemDetails.Status = 200;

                return problemDetails;
            }
            catch (Exception e)
            {
                problemDetails.Detail = e.Message;
                return problemDetails;
            }
        }
        
        public async Task<ProblemDetails> Remove(string itemId)
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Detail = "An error occured",
                Status = 500
            };

            try
            {
                if (itemId is null)
                {
                    throw new Exception("Id cannot be empty");
                }

                Guid id;
                if (!Guid.TryParse(itemId, out id))
                {
                    throw new Exception("Id was provided in the wrong format");
                }

                var itemToRemove = await _objectSet.FindAsync(id);

                if (itemToRemove is null)
                {
                    throw new Exception("Item was not found in the database");
                }

                _objectSet.Remove(itemToRemove);

                if (!(await DbContext.SaveChangesAsync() > 0))
                {
                    throw new Exception("Something went wrong during item removal");
                }

                problemDetails.Detail = "Item removed successfully";
                problemDetails.Status = 200;

                return problemDetails;
            }
            catch (Exception e)
            {
                problemDetails.Detail = e.Message;
                return problemDetails;
            }
        }
        
        public async Task<ProblemDetails> Edit(T item, string id)
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Detail = "Something went wrong",
                Status = 500
            };

            try
            {
                Guid itemId;
                if (!Guid.TryParse(id, out itemId))
                {
                    throw new Exception("Id is in wrong format");
                }

                if (item is null)
                {
                    throw new Exception("Item cannot be empty");
                }

                _objectSet.Update(item);

                await DbContext.SaveChangesAsync();

                problemDetails.Detail = "Item changed successfully";
                problemDetails.Status = 200;

                return problemDetails;
            }
            catch (Exception e)
            {
                problemDetails.Detail = e.Message;
                return problemDetails;
            }
        }
    }
}