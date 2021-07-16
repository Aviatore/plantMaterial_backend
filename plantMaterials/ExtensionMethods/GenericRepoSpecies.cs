using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using plantMaterials.DTOs;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace plantMaterials.ExtensionMethods
{
    public static class GenericRepoSpecies
    {
        public static IEnumerable<SpeciesWithAliasDto> GetAllWithAliases(this IGenericRepository<Species> repo)
        {
            return repo.DbContext.Species.Include(p => p.SpeciesAliases).Select(p => repo.Mapper.Map<Species, SpeciesWithAliasDto>(p)).AsEnumerable();
        }
        
        public static SpeciesWithAliasDto GetWithAliases(this IGenericRepository<Species> repo, string speciesId)
        {
            var species = repo.DbContext.Species.Include(p => p.SpeciesAliases)
                .SingleOrDefault(p => p.SpeciesId == Guid.Parse(speciesId));

            return repo.Mapper.Map<Species, SpeciesWithAliasDto>(species);
        }

        public static async Task<ProblemDetails> EditWithAliases(this IGenericRepository<Species> repo, SpeciesWithAliasDto species, List<SpeciesAlias> aliases)
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Detail = "A problem occur while editing species",
                Status = 500
            };

            try
            {
                var aliasesToRemove = aliases.Where(p => !species.SpeciesAliases.Contains(p.Alias));
                var aliasesToAdd = species.SpeciesAliases.Where(p => !aliases.Select(a => a.Alias).Contains(p));

                foreach (var alias in aliasesToAdd)
                {
                    SpeciesAlias speciesAlias = new SpeciesAlias()
                    {
                        SpeciesAliasId = Guid.Empty,
                        SpeciesId = species.SpeciesId,
                        Alias = alias
                    };

                    repo.DbContext.SpeciesAliases.Add(speciesAlias);
                }
                
                await repo.DbContext.SaveChangesAsync();

                repo.DbContext.SpeciesAliases.RemoveRange(aliasesToRemove);

                var currentSpecies = repo.GetAll().SingleOrDefault(p => p.SpeciesId == species.SpeciesId);

                if (currentSpecies is null)
                {
                    throw new Exception($"Cannot find species of id: {species.SpeciesId} in the database");
                }

                var updatedSpecies = repo.Mapper.Map(species, new Species());

                if (updatedSpecies is null)
                {
                    throw new Exception("Updated species is null");
                }
                
                updatedSpecies.SpeciesId = species.SpeciesId;

                var result = await repo.Edit(updatedSpecies, species.SpeciesId.ToString());

                return result;

                /*repo.DbContext.Species.Update(updatedSpecies); 

                var c = await repo.DbContext.SaveChangesAsync();

                if (c == 0)
                {
                    throw new Exception("Species could not be updated");
                }

                problemDetails.Detail = "Species was updated";
                problemDetails.Status = 200;
                
                return problemDetails;*/
            }
            catch (Exception e)
            {
                problemDetails.Detail = e.Message;
                await Console.Out.WriteLineAsync($"err: {e.InnerException.Message}");
                return problemDetails;
            }
        }

        public static async Task<ProblemDetails> AddSpecies(this IGenericRepository<Species> repo,
            SpeciesWithAliasDto speciesWithAliasDto)
        {
            await using var transaction = await repo.DbContext.Database.BeginTransactionAsync();
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Detail = "Provided id is not valid",
                Status = 500
            };

            try
            {
                
                var species = repo.Mapper.Map(speciesWithAliasDto, new Species());
                var result = repo.DbContext.Species.Add(species);

                if (result is null)
                {
                    throw new Exception("Problem with adding a species");
                }

                await repo.DbContext.SaveChangesAsync();

                foreach (var speciesAlias in speciesWithAliasDto.SpeciesAliases)
                {
                    var speciesAliasAddResult =
                        repo.DbContext.SpeciesAliases.Add(new SpeciesAlias()
                        {
                            Alias = speciesAlias,
                            SpeciesId = result.Entity.SpeciesId
                        });

                    if (speciesAliasAddResult is null)
                    {
                        throw new Exception("Problem with adding a species alias");
                    }
                    
                    await repo.DbContext.SaveChangesAsync();
                }
                    
                await transaction.CommitAsync();

                problemDetails.Detail = "Species added successfully";
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