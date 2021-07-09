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
        private PlantMaterialsContext _dbContext;
        private DbSet<T> _objectSet;
        private readonly IMapper _mapper;

        public GenericRepository(PlantMaterialsContext plantMaterialsContext, IMapper mapper)
        {
            _dbContext = plantMaterialsContext;
            _objectSet = plantMaterialsContext.Set<T>();
            _mapper = mapper;
        }
        
        public IEnumerable<T> GetAll()
        {
            return _objectSet.AsNoTracking().AsEnumerable();
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

                await _dbContext.SaveChangesAsync();

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
        
        public async Task<ProblemDetails> Remove(string item_id)
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Detail = "An error occured",
                Status = 500
            };

            try
            {
                if (item_id is null)
                {
                    throw new Exception("Id cannot be empty");
                }

                Guid id;
                if (!Guid.TryParse(item_id, out id))
                {
                    throw new Exception("Id was provided in the wrong format");
                }

                var itemToRemove = await _objectSet.FindAsync(id);

                if (itemToRemove is null)
                {
                    throw new Exception("Item was not found in the database");
                }

                _objectSet.Remove(itemToRemove);

                if (!(await _dbContext.SaveChangesAsync() > 0))
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
                
                
                var editedTissue = await _objectSet.FindAsync(itemId);

                if (editedTissue is null)
                {
                    throw new Exception("Could not find an item of the specified Id");
                }

                _mapper.Map<T, T>(item, editedTissue);
                // editedTissue.CopyPropertiesFrom(item);

                await _dbContext.SaveChangesAsync();

                problemDetails.Detail = "Tissue name changed successfully";
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