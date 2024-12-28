using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users;

public class UserNotFoundException:Exception
{
    public UserNotFoundException(UserId id):base($"the user with the id {id.Value} was not found") { }
}
