using System.Data;
using Udlejningsmaskineoversigt.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace Udlejningsmaskineoversigt.Src.Interfaces
{
    public interface IRessourceRepository
    {
        IEnumerable<Ressource> GetAllElements();
        Ressource GetById(int id);

        void Add(RessourceDTO resource);
        void Delete(int id);
        void Update(RessourceDTO resource);

    }
}
