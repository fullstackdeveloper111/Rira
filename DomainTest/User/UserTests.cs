using Domain.Users;
using System;
using Xunit;
namespace DomainTest.User;



public class UserTests
{
    [Fact]
    public void Constructor_ShouldCreateUserWithExpectedProperties()
    {
        // Arrange
        var name = "Alireza";
        var family = "Salehi";
        var nationalCode = "123456789";
        var dateOfBirth = new DateTime(2000, 1, 1);

        // Act
        var user = new Domain.Users.User(name, family, nationalCode, dateOfBirth);

        // Assert
        Assert.NotNull(user.UserId);
        Assert.Equal(name, user.Name);
        Assert.Equal(family, user.Family);
        Assert.Equal(nationalCode, user.NationalCode);
        Assert.Equal(dateOfBirth, user.DateOfBirth);
    }

    [Fact]
    public void Update_ShouldUpdateUserProperties()
    {
        // Arrange
        var initialName = "Alireza";
        var initialFamily = "Salehi";
        var initialNationalCode = "123456789";
        var initialDateOfBirth = new DateTime(2000, 1, 1);

        var user = new Domain.Users.User(initialName, initialFamily, initialNationalCode, initialDateOfBirth);


        var newUserId = new UserId(Guid.NewGuid());
        var newName = "Mehosen";
        var newFamily = "Rezaii";
        var newNationalCode = "987654321";
        var newDateOfBirth = new DateTime(1995, 5, 15);

        // Act
        user.Update(newUserId, newName, newFamily, newNationalCode, newDateOfBirth);

        // Assert
        Assert.Equal(newUserId, user.UserId);
        Assert.Equal(newName, user.Name);
        Assert.Equal(newFamily, user.Family);
        Assert.Equal(newNationalCode, user.NationalCode);
        Assert.Equal(newDateOfBirth, user.DateOfBirth);
    }

    [Fact]
    public void Constructor_ShouldGenerateUniqueUserId()
    {
        // Arrange
        var user1 = new Domain.Users.User("Alireza", "Salehi", "123456789", DateTime.Now);
        var user2 = new Domain.Users.User("Mohsen", "Rezaii", "987654321", DateTime.Now);

        // Act & Assert
        Assert.NotEqual(user1.UserId, user2.UserId);
    }


}
