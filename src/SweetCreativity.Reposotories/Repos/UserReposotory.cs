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
    public class UserReposotory : IUserReposotory
    {
        private SweetCreativityContext _context;
        public UserReposotory(SweetCreativityContext context)
        {
            _context = context;
        }
        public void Add(User obj)
        {
            _context.Users.Add(obj);
            Save();
        }

        public void Delete(User obj)
        {
            _context.Set<User>().Remove(obj);
            Save();
        }

        public User Get(string id)
        {
           return _context.Users.Find(id);
            //return _context.Set<Listing>().Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User obj)
        {
            _context.Users.Update(obj);
        }
    }
}