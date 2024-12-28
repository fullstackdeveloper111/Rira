using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users;

public class User
{
    public User(string name, string family, string nationalCode, DateTime dateOfBirth)
    {
        UserId = new UserId(Guid.NewGuid());
        Name = name;
        Family = family;
        NationalCode = nationalCode;
        DateOfBirth = dateOfBirth;
    }
    [Key]
    public UserId UserId { get; set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public void Update(UserId userId,string name, string family, string nationalCode, DateTime dateOfBirth)
    {
        UserId = userId;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
        DateOfBirth = dateOfBirth;
    }
}
