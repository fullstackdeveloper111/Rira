using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users;

public interface IUserRepository
{
    Task<User?> GetById(UserId Id);
    void Add(User user);
    void Update(User user);
    void Delete(User user);
    IEnumerable<User> Get(Func<IQueryable<User>, IQueryable<User>> predicate);
}
