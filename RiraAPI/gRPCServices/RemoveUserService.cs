using Grpc.Core;
using MediatR;
using RiragRPCAPI;

namespace RiraAPI.gRPCServices;

public class RemoveUserService: RiragRPCAPI.UserRemoveService.UserRemoveServiceBase
{
    private readonly ISender _sender;
    public RemoveUserService(ISender sender)
    {
        _sender = sender;
    }
    public async override Task<RemoveserResponse> RemoveUser(RemoveUserRequest request, ServerCallContext context)
    {
        await _sender.Send(request);
        return new RemoveserResponse();
    }
}
