using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get(Func<IQueryable<User>, IQueryable<User>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetById(UserId Id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
