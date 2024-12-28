using MediatR;

namespace Application.Users.Create;

public record DeleteUserCommand(Guid UserId) : IRequest;
