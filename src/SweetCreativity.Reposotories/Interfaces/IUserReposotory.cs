using SweetCreativity.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Reposotories.Interfaces
{
    public interface IUserReposotory : ISave
    {
        User Get(int id);
        IEnumerable<User> GetAll();
        void Add(User obj);
        void Update(User obj);
        void Delete(User obj);

        //int Find(int id);
    }
}