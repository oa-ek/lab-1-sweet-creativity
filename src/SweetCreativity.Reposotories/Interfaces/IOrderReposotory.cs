using SweetCreativity.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Reposotories.Interfaces
{
    public interface IOrderReposotory : ISave
    {
        Order Get(int id);
        IEnumerable<Order> GetAll();
        void Add(Order obj);
        void Update(Order obj);
        void Delete(Order obj);

        //int Find(int id);
    }
}
