using MediatR;

namespace Application.Users.Create;

public record CreateUserCommand(string Name, string Family, string NationalCode, DateTime DateOfBirth) : IRequest;
