using SweetCreativity.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Reposotories.Interfaces
{
    public interface IListingReposotory : ISave
    {
        Listing Get(int id);
        IEnumerable<Listing> GetAll();
        void Add(Listing obj);
        void Update(Listing obj);
        void Delete(int id);
    }
}