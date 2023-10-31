using SweetCreativity.Core.Entities;
using SweetCreativity.Reposotories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Reposotories.Repos
{
    internal class OrderNoSQLReposotory : IOrderReposotory
    {
        //private readonly MongoDbConnection connection;
        public OrderNoSQLReposotory()
        {

        }
        public void Add(Order obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order obj)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}
