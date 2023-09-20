using System.Data;
using Udlejningsmaskineoversigt.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace Udlejningsmaskineoversigt.Src.Interfaces
{
    public interface IRessourceRepository
    {
        IEnumerable<Ressource> GetAllElements();
        Ressource GetById(int id);

        void Add(Ressource resource);
        void Delete(int id);
        void Update(Ressource resource);

    }
}
