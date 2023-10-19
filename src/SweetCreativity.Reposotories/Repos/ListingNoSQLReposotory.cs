using SweetCreativity.Core.Entities;
using SweetCreativity.Reposotories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Reposotories.Repos
{
    internal class ListingNoSQLReposotory : IListingReposotory
    {
        //private readonly MongoDbConnection connection;
        public ListingNoSQLReposotory()
        {

        }
        public void Add(Listing obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Listing obj)
        {
            throw new NotImplementedException();
        }

        //public void Find(int obj)
        //{
        //    throw new NotImplementedException();
        //}

        public Listing Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Listing> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Listing obj)
        {
            throw new NotImplementedException();
        }
    }
}