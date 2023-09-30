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
    public class ListingReposotory : IListingReposotory
    {
        private SweetCreativityContext _context;
        public ListingReposotory(SweetCreativityContext context)
        {
            _context = context;
        }
        public void Add(Listing obj)
        {
            _context.Listings.Add(obj);
            Save();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Listing Get(int id)
        {
            return _context.Listings.Find(id);
        }

        public IEnumerable<Listing> GetAll()
        {
            return _context.Listings.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Listing obj)
        {
            _context.Listings.Update(obj);
        }
    }
}