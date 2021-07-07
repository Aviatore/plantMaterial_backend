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
        public async Task AddTissue_NewItem(string tissueName)
        {
            await _uow.TissueRepository.AddTissue(tissueName);
            
            Assert.That(_uow.DbContext.Tissues.SingleOrDefault(p => p.TissueName.Equals(tissueName)), Is.Not.Null);
        }
        
        [Order(2)]
        [TestCaseSource(nameof(ChangeTissueName))]
        public async Task EditTissueName(string oldName, string newName)
        {
            var id = _uow.DbContext.Tissues.Single(p => p.TissueName.Equals(oldName)).TissueId;
            
            await _uow.TissueRepository.EditTissueName(id.ToString(), newName);
            
            Assert.That(_uow.DbContext.Tissues.Single(p => p.TissueId == id).TissueName, Is.EqualTo(newName));
        }
        
        [Order(3)]
        [TestCaseSource(nameof(ChangeTissueName))]
        public async Task RemoveTissue(string oldName, string newName)
        {
            var id = _uow.DbContext.Tissues.Single(p => p.TissueName.Equals(newName)).TissueId;
            
            await _uow.TissueRepository.RemoveTissue(id.ToString());
            
            Assert.That(_uow.DbContext.Tissues.SingleOrDefault(p => p.TissueName.Equals(newName)), Is.Null);
        }
        
        

        [OneTimeTearDown]
        public void CleanUp()
        {
            List<Tissue> tissuesToRemove = new List<Tissue>();
            foreach (var item in NewTissueItems)
            {
                foreach (var name in item.Arguments)
                {
                    var tissues = _uow.DbContext.Tissues.Where(p => p.TissueName.Equals(name)).ToList();
                    tissuesToRemove.AddRange(tissues);
                }
            }
            
            foreach (var item in ChangeTissueName)
            {
                foreach (var name in item.Arguments)
                {
                    var tissues = _uow.DbContext.Tissues.Where(p => p.TissueName.Equals(name)).ToList();
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

        private static IEnumerable<TestCaseData> NewTissueItems
        {
            get
            {
                yield return new TestCaseData("Tissue1");
            }
        }

        private static IEnumerable<TestCaseData> ChangeTissueName
        {
            get
            {
                yield return new TestCaseData("Tissue1", "Tissue2");
            }
        }
    }
}