using Grpc.Core;
using MediatR;
using RiragRPCAPI;

namespace RiraAPI.gRPCServices;

public class CreateUserService: RiragRPCAPI.UserCreateService.UserCreateServiceBase
{
    private readonly ISender _sender;
    public CreateUserService(ISender sender)
    {
        _sender = sender;
    }
    public async override Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
    {
        await _sender.Send(request);
        return new CreateUserResponse();
    }
}