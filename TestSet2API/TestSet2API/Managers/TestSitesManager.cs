using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestSet2API.Models;

namespace TestSet2API.Managers {
    public class TestSitesManager{
        private static int nextId = 1;
        private static List<TestSite> _sites = new List<TestSite>(){
            new TestSite(){Id = nextId++, Name = "Roskilde", WaitingTime = 10},
            new TestSite(){Id = nextId++, Name = "Vejle", WaitingTime = 7},
            new TestSite(){Id = nextId++, Name = "Copenhagen", WaitingTime = 23},
            new TestSite(){Id = nextId++, Name = "Hvidovre", WaitingTime = 5},
            new TestSite(){Id = nextId++, Name = "Hundig", WaitingTime = 3},
        };

        public IEnumerable<TestSite> GetSites(string filterString){
            IEnumerable<TestSite> result = _sites;
            if (filterString == null) return _sites;
            if (filterString == "name"){
                return result = result.OrderBy(t => t.Name);
            }
            else if (filterString == "time"){
                return result = result.OrderBy(t => t.WaitingTime);
            }
            else{
                return result = _sites.FindAll(t => t.Name.Contains(filterString, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }

        public TestSite AddSite(TestSite site){
            site.Id = nextId++;
            _sites.Add(site);
            return site;
        }

        public TestSite DeleteSite(int id){
            var toBeRemoved = _sites.Find(t => t.Id == id);
            if (toBeRemoved != null){
                _sites.Remove(toBeRemoved);
            }
            return toBeRemoved;
        }

        public TestSite GetSiteById(int id){
            return _sites.Find(t => t.Id == id);
        }

        public TestSite UpdateSite(int id, TestSite updatedTestSite){
            int index = _sites.FindIndex(t => t.Id == id);
            updatedTestSite.Id = id;
            _sites[index] = updatedTestSite;
            return updatedTestSite;
        }
    }
}
