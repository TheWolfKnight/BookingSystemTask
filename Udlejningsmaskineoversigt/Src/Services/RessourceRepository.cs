﻿
using Udlejningsmaskineoversigt.Src.Interfaces;
using Udlejningsmaskineoversigt.Src.Models;

namespace Udlejningsmaskineoversigt.Src.Services {
    public class RessourceRepository : IRessourceRepository {

        private readonly static List<Ressource> _Ressources = new List<Ressource>();
        private static int _Id = -1;

        public RessourceRepository() {}

        public IEnumerable<Ressource> GetAllElements() {
            return _Ressources;
        }

        public Ressource GetById(int id) {
            Ressource result = _Ressources.Find(re => re.Id == id) ?? throw new Exception($"Could not find item with id: {id}");
            return result;
        }

        public void Add(RessourceDTO resource) {
            Ressource result = new Ressource(++_Id, resource);
            _Ressources.Add(result);
        }

        public void Delete(int id) {
            Ressource to_be_deleted = _Ressources.Find(re => re.Id == id) ?? throw new Exception($"Could not find the item with id: {id}");
            _Ressources.Remove(to_be_deleted);
        }

        public void Update(RessourceDTO ressource) {
            Ressource old = _Ressources.Find(re => re.Id == ressource.Id) ?? throw new Exception("Not in repo");
            Ressource _new = new Ressource(ressource);
            int idx = _Ressources.IndexOf(old);
            _Ressources[idx] = _new;
        }
    }
}
