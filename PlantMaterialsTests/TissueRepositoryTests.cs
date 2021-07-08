using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using plantMaterials.Models;
using plantMaterials.Repositories;

namespace PlantMaterialsTests
{
    [TestFixture]
    public class TissueRepositoryTests
    {
        private IUnitOfWork _uow;
        
        [OneTimeSetUp]
        public void Setup()
        {
            _uow = new UnitOfWork(new PlantMaterialsContext());
        }

        [Order(1)]
        [TestCaseSource(nameof(NewTissueItems))]
        public async Task AddTissue_NewItem(Tissue tissue)
        {
            await _uow.TissueRepository.AddTissue(tissue);
            
            Assert.That(_uow.DbContext.Tissues.SingleOrDefault(p => p.TissueName.Equals(tissue.TissueName)), Is.Not.Null);
        }
        
        [Order(2)]
        [TestCaseSource(nameof(ChangeTissueName))]
        public async Task EditTissueName(Tissue tissue1, Tissue tissue2)
        {
            var id = _uow.DbContext.Tissues.Single(p => p.TissueName.Equals(tissue1.TissueName)).TissueId;
            tissue2.TissueId = id;
            
            await _uow.TissueRepository.EditTissueName(tissue2);
            
            Assert.That(_uow.DbContext.Tissues.Single(p => p.TissueId == id).TissueName, Is.EqualTo(tissue2.TissueName));
        }
        
        [Order(3)]
        [TestCaseSource(nameof(ChangeTissueName))]
        public async Task RemoveTissue(Tissue tissue1, Tissue tissue2)
        {
            var id = _uow.DbContext.Tissues.Single(p => p.TissueName.Equals(tissue2.TissueName)).TissueId;

            await _uow.TissueRepository.RemoveTissue(id.ToString());
            
            Assert.That(_uow.DbContext.Tissues.SingleOrDefault(p => p.TissueName.Equals(tissue2.TissueName)), Is.Null);
        }
        
        

        [OneTimeTearDown]
        public void CleanUp()
        {
            List<Tissue> tissuesToRemove = new List<Tissue>();
            foreach (var item in NewTissueItems)
            {
                var tissues = _uow.DbContext.Tissues.Where(p => p.TissueName.Equals(item.TissueName)).ToList();
                tissuesToRemove.AddRange(tissues);
            }
            
            foreach (var item in ChangeTissueName)
            {
                foreach (var name in item)
                {
                    var tissues = _uow.DbContext.Tissues.Where(p => p.TissueName.Equals(name.TissueName)).ToList();
                    tissuesToRemove.AddRange(tissues);
                }
            }
            
            if (tissuesToRemove.Count > 0)
            {
                _uow.DbContext.Tissues.RemoveRange(tissuesToRemove);
                _uow.DbContext.SaveChanges();
            }
            
            _uow.DbContext.Dispose();
        }

        private static IEnumerable<Tissue> NewTissueItems
        {
            get
            {
                yield return new Tissue() {TissueName = "Tissue1", TissueDescription = "Description1"};
            }
        }

        private static IEnumerable<Tissue[]> ChangeTissueName
        {
            get
            {
                yield return new []
                {
                    new Tissue() {TissueName = "Tissue1"},
                    new Tissue() {TissueName = "Tissue2"}
                };
            }
        }
    }
}