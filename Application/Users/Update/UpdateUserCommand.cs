using MediatR;

namespace Application.Users.Create;

public record UpdateUserCommand(Guid UserId,string Name, string Family, string NationalCode, DateTime DateOfBirth) : IRequest;
