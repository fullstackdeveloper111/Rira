using Grpc.Core;
using MediatR;
using RiragRPCAPI;

namespace RiraAPI.gRPCServices;

public class UpdateUserService: RiragRPCAPI.UserUpdateService.UserUpdateServiceBase
{
    private readonly ISender _sender;
    public UpdateUserService(ISender sender)
    {
        _sender = sender;
    }
    public async override Task<UpdateserResponse> UpdateUser(UpdateUserRequest request, ServerCallContext context)
    {
        await _sender.Send(request);
        return new UpdateserResponse();
    }
}
