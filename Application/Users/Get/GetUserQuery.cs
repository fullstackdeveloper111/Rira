using MediatR;

namespace Application.Users.Create;

public record GetUserQuery(string? Name, string? Family, string? NationalCode, DateTime? FromDateOfBirth, DateTime? ToDateOfBirth) : IRequest<IList<GetUserResponse>>;


public record GetUserResponse(Guid UserId, string Name, string Family, string NationalCode, DateTime DateOfBirth);