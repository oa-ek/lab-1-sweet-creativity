using SweetCreativity.Core.Context;
using SweetCreativity.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SweetCreativity.Core.Context;
using SweetCreativity.Core.Entities;
using SweetCreativity.Reposotories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Reposotories.Repos
{
    public class OrderReposotory : IOrderReposotory
    {
        private SweetCreativityContext _context;
        public OrderReposotory(SweetCreativityContext context)
        {
            _context = context;
        }
        public void Add(Order obj)
        {
            _context.Orders.Add(obj);
            Save();
        }

        public void Delete(Order obj)
        {
            _context.Set<Order>().Remove(obj);
            Save();
        }

        public Order Get(int id)
        {
            return _context.Orders.Find(id);
           
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Order obj)
        {
            _context.Orders.Update(obj);
        }
    }
}

